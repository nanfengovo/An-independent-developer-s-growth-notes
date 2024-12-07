using Infrastructure;
using Model;
using Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace Domain
{
    /// <summary>
    /// 菜单数据行权限服务接口实现
    /// </summary>
    public class SysMenuTableRowAuthService : ISysMenuTableRowAuthService
    {

        #region 构造示例化

        //仓储接口
        private readonly ISysMenuTableRowAuthRepository _sysMenuTableRowAuthRepository;
        private readonly ISysMenuTableRowAuthConfigRepository _sysMenuTableRowAuthConfigRepository;
        private readonly ISysUserRepository _sysUserRepository;
        private readonly ISysRoleRepository _sysRoleRepository;
        private readonly ISysMenuTableColsRepository _sysMenuTableColsRepository;

        /// <summary>
        /// 数据集合
        /// </summary>
        private List<SysUser> sysUserList = new List<SysUser>();
        private List<SysRole> sysRoleList = new List<SysRole>();

        /// <summary>
        /// 构造示例化
        /// </summary>
        /// <param name="sysMenuTableRowRoleRepository"></param>
        /// <param name="sysMenuTableRowRoleConfigRepository"></param>
        /// <param name="sysUserRepository"></param>
        /// <param name="sysRoleRepository"></param>
        /// <param name="sysMenuTableColsRepository"></param>
        public SysMenuTableRowAuthService(ISysMenuTableRowAuthRepository sysMenuTableRowRoleRepository, ISysMenuTableRowAuthConfigRepository sysMenuTableRowRoleConfigRepository
            , ISysUserRepository sysUserRepository, ISysRoleRepository sysRoleRepository, ISysMenuTableColsRepository sysMenuTableColsRepository)
        {
            _sysMenuTableRowAuthRepository = sysMenuTableRowRoleRepository;
            _sysMenuTableRowAuthConfigRepository = sysMenuTableRowRoleConfigRepository;
            _sysUserRepository = sysUserRepository;
            _sysRoleRepository = sysRoleRepository;
            _sysMenuTableColsRepository = sysMenuTableColsRepository;
        }

        #endregion

        #region 服务实现

        /// <summary>
        /// 根据菜单id，获取菜单行权限配置
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns></returns>
        public ReceiveStatus<LayuiSelectRowAuthExtend> GetTableRowAuthConfigByMenuId(int menuId)
        {
            ReceiveStatus<LayuiSelectRowAuthExtend> receiveStatus = new ReceiveStatus<LayuiSelectRowAuthExtend>();
            var list = _sysMenuTableRowAuthConfigRepository.GetTableRowAuthConfigByMenuId(menuId);
            var configList = GetMenuRowAuthConfig(list);
            receiveStatus.data = configList;
            receiveStatus.msg = "获取成功";
            return receiveStatus;
        }

        /// <summary>
        /// 获取菜单行权限配置-->layui可识别模型
        /// </summary>
        /// <param name="sysMenuTableRowRoleConfigList">行权限配置</param>
        /// <returns></returns>
        public List<LayuiSelectRowAuthExtend> GetMenuRowAuthConfig(List<SysMenuTableRowAuthConfig> sysMenuTableRowRoleConfigList)
        {
            List<LayuiSelectRowAuthExtend> layuiSelectExtendList = new List<LayuiSelectRowAuthExtend>();
            if (sysMenuTableRowRoleConfigList == null || sysMenuTableRowRoleConfigList.Count == 0)
                return layuiSelectExtendList;
            foreach (var item in sysMenuTableRowRoleConfigList.Where(f => f.IsOpen))
            {
                LayuiSelectRowAuthExtend model = new LayuiSelectRowAuthExtend();
                model.Id = item.Id;
                model.label = item.PermissionsFieldName;
                model.value = item.PermissionsField;
                model.ShowControl = item.ShowControl;
                if (item.ShowControl != (int)ShowControlEnum.Input)
                    model.ConditionalEquationValueList = GetConditionalEquationValueList(item.ShowControlDataSource);
                model.ConditionalEquationList = GetConditionalEquationList(item.ConditionalEquationValue);
                model.disabled = !item.IsOpen;
                model.ShowControlName = EnumHelper.GetName<ShowControlEnum>(item.ShowControl);
                model.ShowControlDataSourceName = EnumHelper.GetName<ShowControlDataSourceEnum>(item.ShowControlDataSource);
                layuiSelectExtendList.Add(model);
            }

            return layuiSelectExtendList;
        }

        /// <summary>
        /// 获取条件等式下拉项
        /// </summary>
        /// <param name="conditionalEquation">位域枚举值</param>
        /// <returns></returns>
        public List<LayuiSelect> GetConditionalEquationList(int conditionalEquation)
        {
            List<LayuiSelect> layuiSelectList = new List<LayuiSelect>();
            ConditionalEquationValueEnum conditionalEquationEnum = (ConditionalEquationValueEnum)conditionalEquation;
            if (conditionalEquationEnum.HasFlag(ConditionalEquationValueEnum.等于))
                layuiSelectList.Add(new LayuiSelect { label = ConditionalEquationValueEnum.等于.ToString(), value = EnumHelper.GetDescription(ConditionalEquationValueEnum.等于) });
            if (conditionalEquationEnum.HasFlag(ConditionalEquationValueEnum.不等于))
                layuiSelectList.Add(new LayuiSelect { label = ConditionalEquationValueEnum.不等于.ToString(), value = EnumHelper.GetDescription(ConditionalEquationValueEnum.不等于) });
            if (conditionalEquationEnum.HasFlag(ConditionalEquationValueEnum.大于))
                layuiSelectList.Add(new LayuiSelect { label = ConditionalEquationValueEnum.大于.ToString(), value = EnumHelper.GetDescription(ConditionalEquationValueEnum.大于) });
            if (conditionalEquationEnum.HasFlag(ConditionalEquationValueEnum.大于等于))
                layuiSelectList.Add(new LayuiSelect { label = ConditionalEquationValueEnum.大于等于.ToString(), value = EnumHelper.GetDescription(ConditionalEquationValueEnum.大于等于) });
            if (conditionalEquationEnum.HasFlag(ConditionalEquationValueEnum.小于))
                layuiSelectList.Add(new LayuiSelect { label = ConditionalEquationValueEnum.小于.ToString(), value = EnumHelper.GetDescription(ConditionalEquationValueEnum.小于) });
            if (conditionalEquationEnum.HasFlag(ConditionalEquationValueEnum.小于等于))
                layuiSelectList.Add(new LayuiSelect { label = ConditionalEquationValueEnum.小于等于.ToString(), value = EnumHelper.GetDescription(ConditionalEquationValueEnum.小于等于) });
            if (conditionalEquationEnum.HasFlag(ConditionalEquationValueEnum.包含))
                layuiSelectList.Add(new LayuiSelect { label = ConditionalEquationValueEnum.包含.ToString(), value = EnumHelper.GetDescription(ConditionalEquationValueEnum.包含) });
            if (conditionalEquationEnum.HasFlag(ConditionalEquationValueEnum.不包含))
                layuiSelectList.Add(new LayuiSelect { label = ConditionalEquationValueEnum.不包含.ToString(), value = EnumHelper.GetDescription(ConditionalEquationValueEnum.不包含) });
            return layuiSelectList;
        }

        /// <summary>
        /// 等式结果下拉框值
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public List<LayuiSelect> GetConditionalEquationValueList(int enumValue)
        {
            List<LayuiSelect> list = new List<LayuiSelect>();
            switch ((ShowControlDataSourceEnum)enumValue)
            {
                case ShowControlDataSourceEnum.Personnel:
                    list.AddRange(GetUserList());
                    break;
                case ShowControlDataSourceEnum.UserRole:
                    list.AddRange(GetRoleList());
                    break;
                case ShowControlDataSourceEnum.Department:
                    list.AddRange(new List<LayuiSelect>());
                    break;
                case ShowControlDataSourceEnum.CurrentUser:
                case ShowControlDataSourceEnum.CurrentRole:
                case ShowControlDataSourceEnum.CurrentDepartment:
                    list.AddRange(GetCurrentLoginDataList());
                    break;
            }
            return list;
        }

        /// <summary>
        /// 人员下拉框数据源
        /// </summary>
        /// <returns></returns>
        public List<LayuiSelect> GetUserList()
        {
            List<LayuiSelect> layuiSelectList = new List<LayuiSelect>();
            if (sysUserList.Count == 0)
                sysUserList = _sysUserRepository.GetAll(BaseSqlRepository.sysUser_selectAllSql);
            foreach (var item in sysUserList)
            {
                LayuiSelect model = new LayuiSelect
                {
                    label = item.UserName,
                    value = item.UserId.ToString()
                };
                layuiSelectList.Add(model);
            }
            return layuiSelectList;
        }

        /// <summary>
        /// 角色下拉框数据源
        /// </summary>
        /// <returns></returns>
        public List<LayuiSelect> GetRoleList()
        {
            List<LayuiSelect> layuiSelectList = new List<LayuiSelect>();
            if (sysRoleList.Count == 0)
                sysRoleList = _sysRoleRepository.GetAll(BaseSqlRepository.sysRole_selectAllSql);
            foreach (var item in sysRoleList)
            {
                LayuiSelect model = new LayuiSelect
                {
                    label = item.RoleName,
                    value = item.RoleId.ToString()
                };
                layuiSelectList.Add(model);
            }
            return layuiSelectList;
        }

        /// <summary>
        /// 当前登录下拉框数据源
        /// </summary>
        /// <returns></returns>
        public List<LayuiSelect> GetCurrentLoginDataList()
        {
            List<LayuiSelect> layuiSelectList = new()
            {
                new LayuiSelect()
                {
                    label = EnumHelper.GetDescription(ShowControlDataSourceEnum.CurrentUser) + "数据",
                    value = ShowControlDataSourceEnum.CurrentUser.ToString() + "Data"
                },
                new LayuiSelect()
                {
                    label = EnumHelper.GetDescription(ShowControlDataSourceEnum.CurrentRole) + "数据",
                    value = ShowControlDataSourceEnum.CurrentRole.ToString() + "Data"
                }
                ,
                new LayuiSelect()
                {
                    label = EnumHelper.GetDescription(ShowControlDataSourceEnum.CurrentDepartment) + "数据",
                    value = ShowControlDataSourceEnum.CurrentDepartment.ToString() + "Data"
                }
            };

            return layuiSelectList;
        }

        /// <summary>
        /// 根据菜单id，获取菜单行权限
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns></returns>
        public ReceiveStatus<SysMenuTableRowAuthOutPut> GetTableRowAuthByMenuId(int menuId)
        {
            ReceiveStatus<SysMenuTableRowAuthOutPut> receiveStatus = new();
            var list = _sysMenuTableRowAuthRepository.GetTableRowAuthByMenuId(menuId);
            foreach (var item in list)
            {
                if (!string.IsNullOrWhiteSpace(item.RuleJson))
                {
                    //转换最新的显示数据
                    var ruleList = JsonHelper.DeserializeJsonToObj<List<MatchingDataInput>>(item.RuleJson);
                    item.RuleJson = JsonHelper.SerializeObjToJson(GetNewRuleMatchData(ruleList));
                }
            }
            receiveStatus.data = list;
            receiveStatus.msg = "获取成功";
            return receiveStatus;
        }

        /// <summary>
        /// 保存规则
        /// </summary>
        /// <param name="input">输入参数</param>
        /// <param name="loginResult">操作人员信息</param>
        public void SaveRule(MatchingWhereInput input, LoginResult loginResult)
        {
            var ruleList = JsonHelper.DeserializeJsonToObj<List<MatchingDataInput>>(input.jsonWhere);
            var jsonWhere = JsonHelper.SerializeObjToJson(GetNewRuleMatchData(ruleList, true));
            SysMenuTableRowAuth model = new()
            {
                MenuId = input.menuId,
                CreateTime = DateTime.Now,
                CreateUser = loginResult.UserId.ToString(),
                IsOpen = input.isOpen,
                Remark = input.ruleRemark,
                RuleJson = jsonWhere,
                Sort = 0
            };
            if (input.rowAuthId > 0)
            {
                model.Id = input.rowAuthId;
                _sysMenuTableRowAuthRepository.Update(model, BaseSqlRepository.sysMenuTableRowAuth_updateSql);
            }
            else
            {
                _sysMenuTableRowAuthRepository.Insert(model, BaseSqlRepository.sysMenuTableRowAuth_insertSql);
            }
        }

        /// <summary>
        /// 递归替换字符
        /// </summary>
        /// <param name="matchingDataInput">规则数据</param>
        /// <param name="isAdd">是否新增和编辑</param>
        /// <returns></returns>
        public List<MatchingDataInput> GetNewRuleMatchData(List<MatchingDataInput> matchingDataInput, bool isAddOrEdit = false)
        {
            foreach (var entity in matchingDataInput)
            {
                //项条件
                if (entity.matchingWhere.Count > 0)
                {
                    foreach (var item in entity.matchingWhere)
                    {
                        if (isAddOrEdit)
                        {
                            //如果是新增把显示结果存空,因为里面的数据，可能名称会有变动，比如用户名可能修改，那么显示可能是修改前的用户名。
                            item.matchData = new List<LayuiSelect>();
                        }
                        else
                        {
                            item.matchData = new List<LayuiSelect>();
                            //最新的用户数据
                            if (item.fieldKey == PermissionsFieldEnum.CurrentUser.ToString() || item.fieldKey == PermissionsFieldEnum.CreateUser.ToString())
                                item.matchData.AddRange(GetUserList());
                            //最新的角色数据
                            if (item.fieldKey == PermissionsFieldEnum.CurrentRole.ToString())
                                item.matchData.AddRange(GetRoleList());
                            //最新的部门数据
                            if (item.fieldKey == PermissionsFieldEnum.CurrentDepartment.ToString())
                                item.matchData.AddRange(GetRoleList());
                        }

                    }
                }

                //有子集
                if (entity.children.Count > 0)
                    GetNewRuleMatchData(entity.children, isAddOrEdit);
            }
            return matchingDataInput;
        }

        /// <summary>
        /// 设置规则是否启用
        /// 同一个菜单，只能启用一个规则
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="menuId">菜单id</param>
        /// <param name="isOpen">是否打开</param>
        public ReceiveStatus SetRuleIsOpenById(int id, int menuId, bool isOpen)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            if (id == 0)
                return ExceptionHelper.CustomException("参数传入不正确,主键不能为空或0!");
            if (menuId == 0)
                return ExceptionHelper.CustomException("参数{0}传入不正确,菜单主键不能为空或0");

            //先把当前菜单下所有的规则改为false
            _sysMenuTableRowAuthRepository.UpdateIsOpenByMenuId(menuId, false);
            //在设置当前数据是否开启状态
            _sysMenuTableRowAuthRepository.UpdateIsOpenById(id, isOpen);
            return receiveStatus;
        }

        /// <summary>
        /// 保存规则配置
        /// </summary>
        /// <param name="input">输入参数</param>
        /// <param name="loginResult">操作人员信息</param>
        public ReceiveStatus SaveRuleConfig(SysMenuTableRowAuthConfigInput input, LoginResult loginResult)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            //验证是否提交重复规则字段数据
            var rowAuthConfigList = _sysMenuTableRowAuthConfigRepository.GetTableRowAuthConfigByMenuId(input.MenuId);
            foreach (var item in rowAuthConfigList)
            {
                if (item.PermissionsField == input.PermissionsField && input.ConfigId <= 0)
                    return ExceptionHelper.CustomException(string.Format("该菜单已存在字段名称为【{0}】的规则数据,请重新输入!", item.PermissionsFieldName));
            }

            SysMenuTableRowAuthConfig model = new()
            {
                ShowControlDataSource = (int)(ShowControlDataSourceEnum)Enum.Parse(typeof(ShowControlDataSourceEnum), input.ShowControlDataSource),
                PermissionsField = input.PermissionsField,
                PermissionsFieldName = input.PermissionsFieldName,
                ShowControl = (int)(ShowControlEnum)Enum.Parse(typeof(ShowControlEnum), input.ShowControl),
                CreateTime = DateTime.Now,
                CreateUser = loginResult.UserId.ToString(),
                MenuId = input.MenuId,
                IsOpen = true
            };
            var conditionalEquationValue = 0;
            foreach (var item in input.ConditionalEquationValue)
            {
                var count = EnumHelper.GetValueByDescription<ConditionalEquationValueEnum>(typeof(ConditionalEquationValueEnum), item); ;
                conditionalEquationValue = count + conditionalEquationValue;
            }
            model.ConditionalEquationValue = conditionalEquationValue;
            if (input.ConfigId > 0)
            {
                model.Id = input.ConfigId;
                _sysMenuTableRowAuthConfigRepository.Update(model, BaseSqlRepository.sysMenuTableRowAuthConfig_updateSql);
            }
            else
            {
                _sysMenuTableRowAuthConfigRepository.Update(model, BaseSqlRepository.sysMenuTableRowAuthConfig_insertSql);
            }

            return receiveStatus;
        }

        /// <summary>
        /// 删除规则
        /// </summary>
        /// <param name="id">规则id</param>
        public ReceiveStatus DeleteRule(int id)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            if (id == 0)
                return ExceptionHelper.CustomException("id不能为空或者0!");
            _sysMenuTableRowAuthRepository.Delete(id.ToString(), BaseSqlRepository.sysMenuTableRowAuth_delete);
            return receiveStatus;
        }

        /// <summary>
        /// 删除规则配置
        /// </summary>
        /// <param name="id">规则配置id</param>
        public ReceiveStatus DeleteRuleConfig(int id)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            if (id == 0)
                return ExceptionHelper.CustomException("id不能为空或者0!");
            _sysMenuTableRowAuthConfigRepository.Delete(id.ToString(), BaseSqlRepository.sysMenuTableRowAuthConfig_delete);
            return receiveStatus;
        }

        /// <summary>
        /// 根据菜单id，获取权限行配置信息数据源
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns></returns>
        public ReceiveStatus<RowAuthConfigExendOutPut> GetRowAuthConfigByMenuId(int menuId)
        {
            ReceiveStatus<RowAuthConfigExendOutPut> receiveStatus = new();
            RowAuthConfigExendOutPut rowAuthConfigExendOutPut = new();

            //数据行权限字段
            var fieldList = _sysMenuTableColsRepository.GetTableColsByMenuIdOrDataRowAuthType(menuId, (int)DataRowAuthTypeEnum.DataRowAuthField);
            List<LayuiSelect> layuiSelectList = new List<LayuiSelect>();
            foreach (var item in fieldList)
            {
                LayuiSelect model = new();
                model.label = item.DataRowAuthFieldName;
                model.value = item.DataRowAuthField;
                layuiSelectList.Add(model);
            }
            //权限字段
            rowAuthConfigExendOutPut.PermissionsFieldList = EnumHelper.GetListAllEnumType<PermissionsFieldEnum>(typeof(PermissionsFieldEnum));
            rowAuthConfigExendOutPut.PermissionsFieldList.AddRange(layuiSelectList);
            //条件等式集合
            rowAuthConfigExendOutPut.ConditionalEquationValueList = EnumHelper.GetListAllEnumType<ConditionalEquationValueEnum>(typeof(ConditionalEquationValueEnum), false);
            //显示控件风格
            rowAuthConfigExendOutPut.ShowControlList = EnumHelper.GetListAllEnumType<ShowControlEnum>(typeof(ShowControlEnum));
            //显示控件结果数据源枚举
            rowAuthConfigExendOutPut.ShowControlDataSourceList = EnumHelper.GetListAllEnumType<ShowControlDataSourceEnum>(typeof(ShowControlDataSourceEnum));

            receiveStatus.data = new List<RowAuthConfigExendOutPut> { rowAuthConfigExendOutPut };
            receiveStatus.msg = "获取成功";
            return receiveStatus;
        }

        #endregion
    }
}
