using Infrastructure;
using Model;
using Model.BusinessModel;
using Subdomain.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Domain
{
    /// <summary>
    /// 角色接口实现
    /// </summary>
    public class SysRoleService : ISysRoleService
    {
        #region 构造实列化 

        //仓储接口
        private readonly ISysRoleRepository _sysRoleRepository;
        private readonly ISysMenuRepository _menuRepository;
        private readonly ISysUserRepository _userRepository;
        private readonly ISysUserRoleRelationRepository _sysUserRoleRelationRepository;
        private readonly ISysMenuRoleRelationRepository _sysMenuRoleRelationRepository;

        /// <summary>
        /// 构造函数，依赖注入
        /// </summary>
        /// <param name="sysRoleRepository"></param>
        public SysRoleService(ISysRoleRepository sysRoleRepository, ISysMenuRepository menuRepository, ISysUserRepository userRepository, ISysUserRoleRelationRepository sysUserRoleRelationRepository, ISysMenuRoleRelationRepository sysMenuRoleRelationRepository)
        {
            _sysRoleRepository = sysRoleRepository;
            _menuRepository = menuRepository;
            _userRepository = userRepository;
            _sysUserRoleRelationRepository = sysUserRoleRelationRepository;
            _sysMenuRoleRelationRepository = sysMenuRoleRelationRepository;
        }

        #endregion

        #region 接口实现

        /// <summary>
        /// 获取所有用户数据
        /// </summary>
        /// <returns></returns>
        public List<SysRole> GetAll()
        {
            return _sysRoleRepository.GetAll(BaseSqlRepository.sysRole_selectAllSql);
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="sysRole"></param>
        public ReceiveStatus Insert(SysRole sysRole)
        {
            ReceiveStatus receiveStatus = new();
            var result = Validate(sysRole);
            if (!result.success)
                return result;
            _sysRoleRepository.Insert(sysRole, BaseSqlRepository.sysRole_insertSql);
            return receiveStatus;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="sysRole"></param>
        public ReceiveStatus Update(SysRole sysRole)
        {
            ReceiveStatus receiveStatus = new();
            var result = Validate(sysRole);
            if (!result.success)
                return result;
            _sysRoleRepository.Update(sysRole, BaseSqlRepository.sysRole_updateSql);
            return receiveStatus;
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="sysMenuTableCols"></param>
        /// <returns></returns>
        public ReceiveStatus Validate(SysRole sysRole)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            /*
            新增/修改前验证
            1、角色名不能相同
            */
            var roleList = _sysRoleRepository.GetAll(BaseSqlRepository.sysRole_selectAllSql);
            foreach (var item in roleList)
            {
                if (sysRole.RoleName.ToLower() == item.RoleName.ToLower() && Convert.ToInt32(item.RoleId) != sysRole.RoleId)
                    return ExceptionHelper.CustomException(string.Format("角色名称【{0}】已存在,请重新输入", sysRole.RoleName));
            }

            return receiveStatus;
        }

        /// <summary>
        /// 根据key获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysRole GetByKey(string id)
        {
            return _sysRoleRepository.GetByKey(id, BaseSqlRepository.sysRole_selectByKeySql);
        }

        /// <summary>
        /// 获取所有角色（分页）
        /// </summary>
        /// <param name="pageResultModel">分页模型</param>
        /// <param name="loginResult">登陆人员信息</param>
        /// <returns></returns>
        public PageResultModel<SysRoleOutPut> GetRoleList(PageResultModel pageResultModel, LoginResult loginResult)
        {
            var authWhere = DataAuthCore.GetRowDataAuthRoleSql("sr", pageResultModel.menuId, loginResult);
            pageResultModel.selectWhere = authWhere;
            pageResultModel.tableField = "*";
            pageResultModel.tableName = "Sys_Role sr";
            pageResultModel.orderByField = " RoleId ";
            var list = _sysRoleRepository.GetPageList<SysRoleOutPut>(pageResultModel);
            return list;
        }

        /// <summary>
        /// 根据角色id获取权限菜单
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="isDisabledGroup">是否禁用组</param>
        /// <param name="isDisabledItem">是否禁用项</param>
        /// <returns>返回角色所属菜单</returns>
        public ReceiveStatus<LayuiTreeModel> GetMenuByRoleId(int roleId, bool isDisabledGroup, bool isDisabledItem)
        {
            ReceiveStatus<LayuiTreeModel> receiveStatus = new ReceiveStatus<LayuiTreeModel>();
            LayuiTreeModel layuiTreeModel = new LayuiTreeModel();
            //获取所有菜单，并转换成tree
            var list = _menuRepository.GetMenusList();
            layuiTreeModel.TreeItems = MenuCore.GetRoleMenuDao(list, isDisabledGroup, isDisabledItem);
            if (roleId > 0)
            {
                //获取角色
                var roleModel = _sysRoleRepository.GetByKey(roleId.ToString(), BaseSqlRepository.sysRole_selectByKeySql);
                if (roleModel == null)
                    return ExceptionHelper<LayuiTreeModel>.CustomExceptionData(string.Format("角色id为【{0}】的角色不存在", roleId));

                //获取角色菜单
                var menuRoleList = _sysMenuRoleRelationRepository.GetSysMenuRoleRelationByRoleId(new List<int> { roleId });
                if (menuRoleList != null || menuRoleList.Count >= 0)
                {
                    //递归菜单并返回角色对应菜单id
                    var menuIdList = menuRoleList.GroupBy(f => f.MenuId).Select(f => f.Key).ToList();
                    layuiTreeModel.CheckedKeys = _menuRepository.GetMenusByMenuIdList(menuIdList).Select(s => s.Id).ToArray();
                }
            }
            receiveStatus.data = new List<LayuiTreeModel>() { layuiTreeModel };
            receiveStatus.msg = "获取成功";
            return receiveStatus;
        }

        /// <summary>
        /// 修改角色权限
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="menuIds">菜单id集合</param>
        /// <param name="userId">操作人员id</param>
        public void UpdataRoleAuthority(int roleId, List<int> menuIds, int userId)
        {
            //获取角色
            var roleModel = _sysRoleRepository.GetByKey(roleId.ToString(), BaseSqlRepository.sysRole_selectByKeySql);
            if (roleModel == null)
                ExceptionHelper<LayuiTreeModel>.CustomExceptionData(string.Format("角色id为【{0}】的角色不存在", roleId));

            TransactionHelper.ExecuteTransaction(() =>
            {
                _sysMenuRoleRelationRepository.DeleteByRoleId(roleId);
                var dateTime = DateTime.Now;

                foreach (var item in menuIds)
                {
                    SysMenuRoleRelation sysMenuRoleRelation = new SysMenuRoleRelation
                    {
                        CreateTime = dateTime,
                        RoleId = roleId,
                        CreateUser = userId.ToString(),
                        MenuId = item,
                    };
                    _sysMenuRoleRelationRepository.Insert(sysMenuRoleRelation, BaseSqlRepository.sysMenuRoleRelation_insertSql);
                }
            });
        }
        #endregion
    }
}
