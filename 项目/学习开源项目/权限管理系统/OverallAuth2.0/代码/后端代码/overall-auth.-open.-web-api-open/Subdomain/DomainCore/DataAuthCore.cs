using Infrastructure;
using Infrastructure.Repository;
using Model;
using Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using Utility;

namespace Subdomain.DomainCore
{
    /// <summary>
    /// 数据权限核心
    /// </summary>
    public static class DataAuthCore
    {

       private static SysMenuTableRowAuthRepository sysMenuTableRowAuthRepository = new SysMenuTableRowAuthRepository();

        /// <summary>
        /// 解析行数据权限规则，并转换成对应的sql
        /// </summary>
        /// <param name="_sysMenuTableRowRoleRepository">行数据权限仓储接口</param>
        /// <param name="mainTableAlias">主表数据库别名</param>
        /// <param name="menuId">菜单id</param>
        /// <param name="loginResult">登陆人员信息</param>
        /// <returns></returns>
        public static string GetRowDataAuthRoleSql(string mainTableAlias, string menuId, LoginResult loginResult)
        {
            if (string.IsNullOrWhiteSpace(menuId))
                return string.Empty;
            if (string.IsNullOrWhiteSpace(mainTableAlias))
                ExceptionHelper.ThrowBusinessException("主表别名不能为空");
            if (loginResult == null)
                ExceptionHelper.ThrowBusinessException("登录人员信息不能为空");
            if (string.IsNullOrWhiteSpace(loginResult.RoleIds) || string.IsNullOrWhiteSpace(loginResult.UserId.ToString()))
                ExceptionHelper.ThrowBusinessException("登录人员角色和用户id不能为空");

            mainTableAlias += ".";
            //解析规则sql
            string selectWhere = string.Empty;
            var menuTableRow = sysMenuTableRowAuthRepository.GetTableRowAuthByMenuId(Convert.ToInt32(menuId)).Where(f => f.IsOpen == true).FirstOrDefault();
            if (menuTableRow != null)
            {
                var ruleList = JsonHelper.DeserializeJsonToObj<List<MatchingDataInput>>(menuTableRow.RuleJson);
                var ruleSql = GetRuleString(ruleList, mainTableAlias.Trim(), loginResult);
                selectWhere = ruleSql;
            }
            return selectWhere;
        }

        /// <summary>
        /// 递归获取规则字符
        /// 转换好的sql
        /// </summary>
        /// <param name="matchingDataInput">规则数据</param>
        /// <param name="mainTableAlias">主表别名</param>
        /// <param name="loginResult">登录人员信息</param>
        /// <param name="isChildren">是否子集</param>
        /// <returns></returns>
        public static string GetRuleString(List<MatchingDataInput> matchingDataInput, string mainTableAlias, LoginResult loginResult, bool isChildren = false)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var i = 0;
            foreach (var entity in matchingDataInput)
            {
                //项条件
                if (entity.matchingWhere.Count > 0)
                {
                    foreach (var item in entity.matchingWhere)
                    {
                        //如果是子集且是第一次进入，不写匹配组关系（and or）,在递归时写入
                        var matchGroup = string.Empty;
                        if (i == 0 && isChildren)
                            matchGroup = string.Empty;
                        else
                            matchGroup = entity.matchGroup;

                        //匹配结果为当前登录数据要特殊处理
                        var currentLoginData = IsCurrentLoginData(item, loginResult);
                        var currentFieldData = IsCurrentFieldData(item, loginResult);
                        if (!string.IsNullOrWhiteSpace(currentLoginData.Item1))
                        {
                            //匹配数据为当前登录角色
                            if (currentLoginData.Item2 == ShowControlDataSourceEnum.CurrentRole)
                                stringBuilder.Append(GetSplitCurrentRoleDataSql(matchGroup, mainTableAlias, currentLoginData.Item1));
                            //匹配数据为当前登录用户
                            if (currentLoginData.Item2 == ShowControlDataSourceEnum.CurrentUser)
                                stringBuilder.Append(GetSplitCurrentUserDataSql(matchGroup, mainTableAlias, currentLoginData.Item1));
                        }
                        //匹配字段为当前字段数据要特殊处理
                        else if (!string.IsNullOrWhiteSpace(currentFieldData.Item1))
                        {
                            if (currentFieldData.Item2 == false)
                                stringBuilder.Append(string.Format(" {0} 1!=1 ", matchGroup));
                        }
                        else
                        {
                            stringBuilder.Append(string.Format(" {0} {1} {2} ",
                                matchGroup, GetMatchingField(item.fieldKey, mainTableAlias), GetMatchingValue(item)));
                        }
                        i++;
                    }
                }

                //有子集
                if (entity.children.Count > 0)
                    stringBuilder.Append(string.Format(" {0} ({1}) ", entity.matchGroup, GetRuleString(entity.children, mainTableAlias, loginResult, true)));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// 获取匹配字段
        /// </summary>
        /// <param name="fieldKey">字段key</param>
        /// <param name="mainTableAlias">主表别名</param>
        /// <returns></returns>
        private static string GetMatchingField(string fieldKey, string mainTableAlias)
        {
            string fieldStr = fieldKey;
            if (fieldKey == PermissionsFieldEnum.CurrentUser.ToString())
                fieldStr = " CreateUser ";
            if (fieldKey == PermissionsFieldEnum.CurrentRole.ToString())
                fieldStr = " RoleId ";
            if (fieldKey == PermissionsFieldEnum.CurrentDepartment.ToString())
                fieldStr = " DepartmentId ";
            if (fieldKey == PermissionsFieldEnum.CreateUser.ToString())
                fieldStr = " CreateUser ";
            if (fieldKey == PermissionsFieldEnum.CreateTime.ToString())
                fieldStr = " CreateTime ";
            if (!string.IsNullOrWhiteSpace(mainTableAlias) && fieldKey != ShowControlDataSourceEnum.UserRole.ToString())
                fieldStr = mainTableAlias + fieldStr;
            return fieldStr;
        }

        /// <summary>
        /// 获取匹配符号
        /// </summary>
        /// <param name="matchSymbolKey">符号key</param>
        /// <returns></returns>
        private static string GetMatchingSymbol(string matchSymbolKey)
        {
            string matchSymbolStr = matchSymbolKey;

            if (matchSymbolKey == EnumHelper.GetDescription(ConditionalEquationValueEnum.包含))
                matchSymbolStr = " in ";
            if (matchSymbolKey == EnumHelper.GetDescription(ConditionalEquationValueEnum.不包含))
                matchSymbolStr = " not in ";
            return matchSymbolStr;
        }

        /// <summary>
        /// 获取匹配值
        /// </summary>
        /// <param name="matchingWhereData">匹配条件</param>
        /// <returns></returns>
        private static string GetMatchingValue(MatchingWhereData matchingWhereData)
        {
            string matchingValue = GetSplitSelectResultValue(matchingWhereData);
            return matchingValue;
        }

        /// <summary>
        /// 是否是当前登录数据
        /// </summary>
        /// <param name="matchingWhereData">匹配条件数据</param>
        /// <param name="loginResult">登录人员信息</param>
        /// <returns></returns>
        private static Tuple<string, ShowControlDataSourceEnum> IsCurrentLoginData(MatchingWhereData matchingWhereData, LoginResult loginResult)
        {
            var value = string.Empty;
            var enumValue = ShowControlDataSourceEnum.HandInput;
            if (matchingWhereData.matchDataKey == ShowControlDataSourceEnum.CurrentUser.ToString() + "Data")
            {
                matchingWhereData.matchDataKey = loginResult.UserId.ToString();
                value = GetSplitSelectResultValue(matchingWhereData);
                enumValue = ShowControlDataSourceEnum.CurrentUser;
            }
            if (matchingWhereData.matchDataKey == ShowControlDataSourceEnum.CurrentRole.ToString() + "Data")
            {
                matchingWhereData.matchDataKey = string.Empty;
                matchingWhereData.matchDataKeys = loginResult.RoleIds.Split(",").ToList();
                value = GetSplitSelectResultValue(matchingWhereData);
                enumValue = ShowControlDataSourceEnum.CurrentRole;
            }
            if (matchingWhereData.matchDataKey == ShowControlDataSourceEnum.CurrentDepartment.ToString() + "Data")
            {
                matchingWhereData.matchDataKey = string.Empty;
                value = "";
                enumValue = ShowControlDataSourceEnum.CurrentDepartment;
            }
            return new Tuple<string, ShowControlDataSourceEnum>(value, enumValue);
        }

        /// <summary>
        /// 是否是当前字段数据
        /// </summary>
        /// <param name="matchingWhereData">匹配条件数据</param>
        /// <param name="loginResult">当前登录人员信息</param>
        /// <returns></returns>
        private static Tuple<string, bool> IsCurrentFieldData(MatchingWhereData matchingWhereData, LoginResult loginResult)
        {
            if (matchingWhereData.fieldKey != PermissionsFieldEnum.CurrentUser.ToString() && matchingWhereData.fieldKey != PermissionsFieldEnum.CurrentRole.ToString()
                && matchingWhereData.fieldKey != PermissionsFieldEnum.CurrentDepartment.ToString())
                return new Tuple<string, bool>(string.Empty, false);

            var isTrue = GetSplitSelectResultValue(matchingWhereData, loginResult);
            string value;
            if (isTrue)
                value = "成功匹配";
            else
                value = "匹配失败";
            return new Tuple<string, bool>(value, isTrue);
        }

        /// <summary>
        /// 获取拼接当前用户角色数据sql
        /// </summary>
        /// <param name="matchGroup">组</param>
        /// <param name="mainTableAlias">主表别名</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        private static string GetSplitCurrentRoleDataSql(string matchGroup, string mainTableAlias, string value)
        {
            var sql = string.Format(" {0} EXISTS(select * from  Sys_UserRoleRelation where RoleId {1} and {2}CreateUser = UserId)  ", matchGroup, value, mainTableAlias);
            return sql;
        }

        /// <summary>
        /// 获取拼接当前用户数据sql
        /// </summary>
        /// <param name="matchGroup">组</param>
        /// <param name="mainTableAlias">主表别名</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        private static string GetSplitCurrentUserDataSql(string matchGroup, string mainTableAlias, string value)
        {
            var sql = string.Format(" {0} {1}CreateUser {2}   ", matchGroup, mainTableAlias, value);
            return sql;
        }

        /// <summary>
        /// 获取拼接查询结果值
        /// </summary>
        /// <param name="matchingWhereData">匹配条件数据</param>
        /// <returns></returns>
        private static string GetSplitSelectResultValue(MatchingWhereData matchingWhereData)
        {
            string splitValue = string.Empty;
            if (!string.IsNullOrEmpty(matchingWhereData.matchDataKey))
            {
                if (matchingWhereData.matchSymbolKey != EnumHelper.GetDescription(ConditionalEquationValueEnum.包含) && matchingWhereData.matchSymbolKey != EnumHelper.GetDescription(ConditionalEquationValueEnum.不包含))
                    splitValue = string.Format(" {0} '{1}' ", GetMatchingSymbol(matchingWhereData.matchSymbolKey), matchingWhereData.matchDataKey);
                else
                    splitValue = string.Format(" {0} ('{1}') ", GetMatchingSymbol(matchingWhereData.matchSymbolKey), matchingWhereData.matchDataKey);
            }
            else if (matchingWhereData.matchDataKeys.Count > 0)
            {
                if (matchingWhereData.matchSymbolKey == EnumHelper.GetDescription(ConditionalEquationValueEnum.等于))
                    splitValue = string.Format("{0} ({1}) ", " in ", GetSelectValue(matchingWhereData.matchDataKeys));
                if (matchingWhereData.matchSymbolKey == EnumHelper.GetDescription(ConditionalEquationValueEnum.不等于))
                    splitValue = string.Format("{0} ({1}) ", " not in ", GetSelectValue(matchingWhereData.matchDataKeys));
                if (matchingWhereData.matchSymbolKey == EnumHelper.GetDescription(ConditionalEquationValueEnum.包含) || matchingWhereData.matchSymbolKey == EnumHelper.GetDescription(ConditionalEquationValueEnum.不包含))
                    splitValue = string.Format(" {0} ({1}) ", GetMatchingSymbol(matchingWhereData.matchSymbolKey), GetSelectValue(matchingWhereData.matchDataKeys));

            }
            return splitValue;
        }


        /// <summary>
        /// 获取拼接查询结果值
        /// </summary>
        /// <param name="matchingWhereData">匹配条件数据</param>
        /// <returns></returns>
        private static bool GetSplitSelectResultValue(MatchingWhereData matchingWhereData, LoginResult loginResult)
        {
            //非条件（不包含、不等于）
            string unconditional = string.Empty;
            //是否匹配成功
            bool isTrue = false;
            //匹配符号
            string matchSymbol = string.Empty;
            //匹配模型值
            PermissionsFieldModel model = new();
            model.CurrentUser = loginResult.UserId.ToString();
            model.CurrentRole = matchingWhereData.matchDataKey;

            //单个值
            if (!string.IsNullOrEmpty(matchingWhereData.matchDataKey))
            {
                if (matchingWhereData.matchSymbolKey != EnumHelper.GetDescription(ConditionalEquationValueEnum.包含) && matchingWhereData.matchSymbolKey != EnumHelper.GetDescription(ConditionalEquationValueEnum.不包含))
                {
                    //登录用户只有一个，所以用原本符号（无包含和不包含关系）
                    if (matchingWhereData.fieldKey == PermissionsFieldEnum.CurrentUser.ToString())
                    {
                        var lambdaExpression = string.Format("{0}{1}\"{2}\"", matchingWhereData.fieldKey, matchingWhereData.matchSymbolKey, matchingWhereData.matchDataKey);
                        isTrue = MatchLambdaExpression(lambdaExpression, model);
                    }
                    //登录角色有多个，所以用包含（Contains）来匹配
                    if (matchingWhereData.fieldKey == PermissionsFieldEnum.CurrentRole.ToString())
                    {
                        matchSymbol = EnumHelper.GetDescription(ConditionalEquationValueEnum.包含);
                        if (matchingWhereData.matchSymbolKey == EnumHelper.GetDescription(ConditionalEquationValueEnum.不等于))
                            unconditional = "==false";
                        var lambdaExpression = string.Format("\"{0}\"{1}({2}){3}", loginResult.RoleIds, "." + matchSymbol, matchingWhereData.fieldKey, unconditional);
                        isTrue = MatchLambdaExpression(lambdaExpression, model);
                    }
                }
                else
                {
                    //只有包含和不包含关系，所以用（Contains）来匹配
                    if (matchingWhereData.fieldKey == PermissionsFieldEnum.CurrentUser.ToString())
                    {
                        var lambdaExpression = string.Format("\"{0}\"{1}({2})", loginResult.UserId, "." + matchSymbol, matchingWhereData.fieldKey);
                        isTrue = MatchLambdaExpression(lambdaExpression, model);
                    }
                    if (matchingWhereData.fieldKey == PermissionsFieldEnum.CurrentRole.ToString())
                    {
                        matchSymbol = EnumHelper.GetDescription(ConditionalEquationValueEnum.包含);
                        if (matchingWhereData.matchSymbolKey == EnumHelper.GetDescription(ConditionalEquationValueEnum.不包含))
                            unconditional = "==false";
                        var lambdaExpression = string.Format("\"{0}\"{1}({2}){3}", loginResult.RoleIds, "." + matchSymbol, matchingWhereData.fieldKey, unconditional);
                        isTrue = MatchLambdaExpression(lambdaExpression, model);
                    }
                }
            }
            //多个值
            else if (matchingWhereData.matchDataKeys.Count > 0)
            {
                //只要有一个匹配上，那么就匹配正确
                matchSymbol = EnumHelper.GetDescription(ConditionalEquationValueEnum.包含);
                if (matchingWhereData.matchSymbolKey == EnumHelper.GetDescription(ConditionalEquationValueEnum.不等于) || matchingWhereData.matchSymbolKey == EnumHelper.GetDescription(ConditionalEquationValueEnum.不包含))
                    unconditional = "==false";
                if (matchingWhereData.fieldKey == PermissionsFieldEnum.CurrentUser.ToString())
                {
                    var lambdaExpression = string.Format("\"{0}\"{1}({2}){3}", string.Join(",", matchingWhereData.matchDataKeys), "." + matchSymbol, matchingWhereData.fieldKey, unconditional);
                    isTrue = MatchLambdaExpression(lambdaExpression, model);
                }
                if (matchingWhereData.fieldKey == PermissionsFieldEnum.CurrentRole.ToString())
                {
                    if (!string.IsNullOrWhiteSpace(unconditional))
                        isTrue = !matchingWhereData.matchDataKeys.Any(item => loginResult.RoleIds.Split(',').ToList().Contains(item));
                    else
                        isTrue = matchingWhereData.matchDataKeys.Any(item => loginResult.RoleIds.Split(',').ToList().Contains(item));
                }
            }
            return isTrue;
        }


        /// <summary>
        /// 匹配lambda表达式
        /// </summary>
        /// <param name="lambdaExpression">匹配表达式</param>
        /// <param name="model">实体</param>
        /// <returns></returns>
        private static bool MatchLambdaExpression(string lambdaExpression, PermissionsFieldModel model)
        {
            var lambda = DynamicExpressionParser.ParseLambda<PermissionsFieldModel, bool>(ParsingConfig.Default, true, lambdaExpression).Compile(true);
            if (new List<PermissionsFieldModel> { model }.Count(lambda) > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// 获取查询值
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static string GetSelectValue(List<string> list)
        {
            var value = string.Empty;
            foreach (var item in list)
            {
                value = value + ",'" + item + "'";
            }
            return value.Trim(',');
        }


    }
}
