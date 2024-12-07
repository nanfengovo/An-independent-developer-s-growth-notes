using Infrastructure;
using Model;
using Model.BusinessModel;
using Subdomain.DomainCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Utility;

namespace Domain
{
    /// <summary>
    /// 用户接口实现 
    /// </summary>
    public class SysUserService : ISysUserService
    {
        #region 构造实列化

        //仓储接口
        private readonly ISysUserRepository _userRepository;
        private readonly ISysUserRoleRelationRepository _sysUserRoleRelationRepository;
        //仓储接口
        private readonly ISysMenuTableColsRepository _sysMenuTableColsRepository;

        /// <summary>
        /// 构造函数，依赖注入
        /// </summary>
        /// <param name="userRepository"></param>
        public SysUserService(ISysUserRepository userRepository, ISysUserRoleRelationRepository sysUserRoleRelationRepository, ISysMenuTableColsRepository sysMenuTableColsRepository)
        {
            _userRepository = userRepository;
            _sysUserRoleRelationRepository = sysUserRoleRelationRepository;
            _sysMenuTableColsRepository = sysMenuTableColsRepository;
        }

        #endregion

        #region 接口实现

        /// <summary>
        /// 根据用户名称和密码获取用户信息
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="password">用户密码</param>
        /// <returns></returns>
        public ReceiveStatus<LoginResult> GetUserMsg(string userName, string password)
        {
            ReceiveStatus<LoginResult> receiveStatus = new ReceiveStatus<LoginResult>();
            List<LoginResult> loginResultsList = new List<LoginResult>();
            if (string.IsNullOrEmpty(userName))
                return ExceptionHelper<LoginResult>.CustomExceptionData("用户名不能为空！");
            if (string.IsNullOrEmpty(password))
                return ExceptionHelper<LoginResult>.CustomExceptionData("密码不能为空！");
            var result = _userRepository.GetUserMsg(userName, password);
            if (result == null)
                return ExceptionHelper<LoginResult>.CustomExceptionData(string.Format("用户【{0}】不存在", userName));
            var userRoleList = _sysUserRoleRelationRepository.GetSysUserRoleRelationsByUserId(result.UserId);
            if (userRoleList == null || userRoleList.Count == 0)
                return ExceptionHelper<LoginResult>.CustomExceptionData(string.Format("用户【{0}】未分配角色", result.UserName));
            LoginResult loginResults = new LoginResult()
            {
                UserId = result.UserId,
                UserName = result.UserName,
                RoleIds = string.Join(",", userRoleList.Select(f => f.RoleId)),
                Token = string.Empty,
                ExpiresDate = string.Empty
            };
            loginResultsList.Add(loginResults);
            receiveStatus.data = loginResultsList;
            receiveStatus.msg = "登录成功";
            return receiveStatus;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="pageResultModel">分页模型</param>
        /// <param name="loginResult">登录人员信息</param>
        /// <returns></returns>
        public PageResultModel<UserOrRoleOutPut> GetUserList(PageResultModel pageResultModel, LoginResult loginResult)
        {
            var authWhere = DataAuthCore.GetRowDataAuthRoleSql("su", pageResultModel.menuId, loginResult);
            pageResultModel.selectWhere = authWhere;
            pageResultModel.tableField = " su.*,sr.RoleName,sr.RoleId ";
            pageResultModel.tableName = @" Sys_User as su 
                                            left join Sys_UserRoleRelation as ur on su.UserId = ur.UserId
                                            left join Sys_Role as sr on sr.RoleId = ur.RoleId ";
            pageResultModel.orderByField = " su.CreateTime ";
            var list = _userRepository.GetPageList<UserOrRoleOutPut>(pageResultModel);
            var data = list.data.GroupBy(f => f.UserId).Select(s => new UserOrRoleOutPut
            {
                UserId = s.First().UserId,
                UserName = s.First().UserName,
                Password = s.First().Password,
                Age = s.First().Age,
                Sex = s.First().Sex,
                DepartmentId = s.First().DepartmentId,
                RoleId = string.Join(",", s.Select(f => f.RoleId)),
                RoleName = string.Join(",", s.Select(f => f.RoleName)),
                CreateTime = s.First().CreateTime,
                CreateUser = s.First().CreateUser
            }).ToList();
            list.data = data.Where(f => f.UserId != 1).ToList();
            return list;
        }

        /// <summary>
        /// 设置用户角色
        /// </summary>
        /// <param name="userOrRoleInput">传入模型</param>
        /// <param name="userId">修改用户id</param>
        public ReceiveStatus SetUserRole(UserOrRoleInput userOrRoleInput, int userId)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            var userModel = _userRepository.GetByKey(userOrRoleInput.UserId.ToString(), BaseSqlRepository.sysUser_selectByKeySql);
            if (userModel == null)
                return ExceptionHelper.CustomException("该用户不存在");
            _sysUserRoleRelationRepository.DeleteByUserId(userOrRoleInput.UserId);
            var dateTime = DateTime.Now;
            foreach (var item in userOrRoleInput.RoleId)
            {
                SysUserRoleRelation sysUserRoleRelation = new SysUserRoleRelation
                {
                    RoleId = item,
                    UserId = userOrRoleInput.UserId,
                    CreateUser = userId.ToString(),
                    CreateTime = dateTime
                };
                _sysUserRoleRelationRepository.Insert(sysUserRoleRelation, BaseSqlRepository.sysUserRoleRelation_insertSql);
            }
            return receiveStatus;
        }

        /// <summary>
        /// 获取所有用户数据
        /// </summary>
        /// <returns></returns>
        public List<SysUser> GetAll()
        {
            return _userRepository.GetAll(BaseSqlRepository.sysUser_selectAllSql);
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="sysUser"></param>
        public ReceiveStatus Insert(SysUser sysUser)
        {
            ReceiveStatus receiveStatus = new();
            var result = Validate(sysUser);
            if (!result.success)
                return result;
            _userRepository.Insert(sysUser, BaseSqlRepository.sysUser_insertSql);
            return receiveStatus;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="sysUser"></param>
        public ReceiveStatus Update(SysUser sysUser)
        {
            ReceiveStatus receiveStatus = new();
            var result = Validate(sysUser);
            if (!result.success)
                return result;
            _userRepository.Update(sysUser, BaseSqlRepository.sysUser_updateSql);
            return receiveStatus;
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="sysMenuTableCols"></param>
        /// <returns></returns>
        public ReceiveStatus Validate(SysUser sysUser)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            /*
            新增/修改前验证
            1、用户名不能相同
            */
            var userList = _userRepository.GetAll(BaseSqlRepository.sysUser_selectAllSql);
            foreach (var item in userList)
            {
                if (sysUser.UserName.ToLower() == item.UserName.ToLower() && Convert.ToInt32(item.UserId) != sysUser.UserId)
                    return ExceptionHelper.CustomException(string.Format("用户名称【{0}】已存在,请重新输入", sysUser.UserName));
            }

            return receiveStatus;
        }

        /// <summary>
        /// 根据key获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysUser GetByKey(string id)
        {
            return _userRepository.GetByKey(id, BaseSqlRepository.sysUser_selectByKeySql);
        }

        /// <summary>
        /// 反射
        /// </summary>
        public ReceiveStatus test()
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();

            //反射
            Assembly assembly = Assembly.Load("Model");
            List<Type> types = assembly.GetTypes().Where(p => p.FullName.Contains("OutPut")).ToList<Type>();
            var currentAssembly = Assembly.LoadFrom(assembly.Location);
            var geoEntityTypes = currentAssembly.ExportedTypes.Where(p => p.FullName.StartsWith("Model.BusinessModel")).ToList();

            ///进行便利获取的所有的程序集中的类
            foreach (var geoEntityType in geoEntityTypes)
            {
                var property = geoEntityType.GetProperties();
                var i = 0;
                var dateTime = DateTime.Now;

                //取类上的自定义特性
                var menuId = string.Empty;
                object[] objs = geoEntityType.GetCustomAttributes(typeof(EnitityMappingAttribute), true);
                foreach (object obj in objs)
                {
                    EnitityMappingAttribute attr = obj as EnitityMappingAttribute;
                    if (attr != null)
                    {
                        menuId = attr.MenuId;//菜单id
                        break;
                    }
                }

                if (!string.IsNullOrWhiteSpace(menuId))
                {
                    foreach (var item in property)
                    {
                        //描述/注释 属性上
                        DescriptionAttribute descriptionAttribute = (DescriptionAttribute)item.GetCustomAttribute(typeof(DescriptionAttribute));
                        string propertyDescription = descriptionAttribute?.Description ?? item.Name; // 如果没有描述/注释，则使用属性名作为默认值

                        var fieldName = item.Name.Substring(0, 1).ToLower() + item.Name.Substring(1);

                        SysMenuTableCols sysMenuTableCols = new SysMenuTableCols()
                        {
                            MenuId = Convert.ToInt32(menuId),
                            FieldName = fieldName,
                            FieldType = item.PropertyType.Name,
                            FieldTitle = propertyDescription,
                            FieldOrderBy = i++,
                            FieldEllipsisTooltip = false,
                            CreateTime = dateTime,
                            CreateUser = "1",
                            IsSystemData = (int)ColsDataTypeEnum.SystemData,
                        };
                        var model = _sysMenuTableColsRepository.GetTableColsByMenuIdOrFieldName(Convert.ToInt32(menuId), item.Name);

                        //没有就新增，有就修改
                        if (model == null)
                            _sysMenuTableColsRepository.Insert(sysMenuTableCols, BaseSqlRepository.sysMenuTableCols_insertSql);
                        else
                        {
                            model.FieldName = fieldName;
                            model.FieldType = item.PropertyType.Name;
                            _sysMenuTableColsRepository.UpdateTableCols(model);
                        }

                    }

                    var ddd = geoEntityType;
                }
            }
            return receiveStatus;
        }

        #endregion
    }
}
