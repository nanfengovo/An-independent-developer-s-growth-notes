using Domain.IService;
using Infrastructure;
using Model;
using Model.BusinessModel;
using Subdomain.DomainCore;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace Domain.Service
{
    /// <summary>
    /// 菜单服务实现
    /// </summary>
    public class SysMenuService : ISysMenuService
    {
        #region 构造实例化

        //仓储接口
        private readonly ISysMenuRepository _menuRepository;
        private readonly ISysUserRepository _userRepository;
        private readonly ISysUserRoleRelationRepository _sysUserRoleRelationRepository;
        private readonly ISysMenuRoleRelationRepository _sysMenuRoleRelationRepository;

        /// <summary>
        /// 构造函数 实现依赖注入
        /// </summary>
        /// <param name="userRepository">仓储对象</param>
        public SysMenuService(ISysMenuRepository menuRepository, ISysUserRepository userRepository, ISysUserRoleRelationRepository sysUserRoleRelationRepository, ISysMenuRoleRelationRepository sysMenuRoleRelationRepository)
        {
            _menuRepository = menuRepository;
            _userRepository = userRepository;
            _sysUserRoleRelationRepository = sysUserRoleRelationRepository;
            _sysMenuRoleRelationRepository = sysMenuRoleRelationRepository;
        }

        #endregion

        #region 服务实现

        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="menu"></param>
        public void Insert(Menu menu)
        {
            menu.Path = menu.MenuUrl;
            menu.Name = string.Empty;
            menu.Redirect = string.Empty;
            menu.RequireAuth = true;
            _menuRepository.Insert(menu, BaseSqlRepository.menu_insertSql);
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="menu"></param>
        public void Update(Menu menu)
        {
            menu.Path = menu.MenuUrl;
            _menuRepository.Update(menu, BaseSqlRepository.menu_updateSql);
        }

        /// <summary>
        /// 根据key获取菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Menu GetByKey(string id)
        {
            return _menuRepository.GetByKey(id, BaseSqlRepository.menu_selectByKeySql);
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public List<Menu> GetAll()
        {
            return _menuRepository.GetAll(BaseSqlRepository.menu_selectAllSql);
        }
        /// <summary>
        /// 获取菜单--上下级关系
        /// </summary>
        /// <returns></returns>
        public List<MenuDao> GetAllChildren()
        {
            var list = _menuRepository.GetMenusList();
            var menuDaoList = MenuCore.GetMenuDao(list);
            return menuDaoList;
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public PageResultModel<MenuOutput> GetMenusList(PageResultModel pageResultModel, LoginResult loginResult)
        {
            PageResultModel<MenuOutput> resultModel = new();
            var authWhere = DataAuthCore.GetRowDataAuthRoleSql("sm", pageResultModel.menuId, loginResult);
            var list = _menuRepository.GetAllMenusList(authWhere).ToList();
            //pageResultModel.selectWhere = authWhere;
            //pageResultModel.tableField = "*";
            //pageResultModel.tableName = "sys_Menu sm ";
            //pageResultModel.orderByField = " id ";
            //var list = _menuRepository.GetPageList<MenuOutput>(pageResultModel);
            var parentList = MenuCore.GetTableTreeMenuDao(list).OrderByDescending(x => x.CreateTime).Skip((pageResultModel.pageIndex - 1) * pageResultModel.pageSize).Take(pageResultModel.pageSize).ToList();
            resultModel.total = parentList.Count;
            resultModel.data = parentList;
            return resultModel;
        }

        /// <summary>
        /// 获取用户所属菜单
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns>返回用户所属菜单</returns>
        public ReceiveStatus<MenuDao> GetMenuByUserId(string userId)
        {
            ReceiveStatus<MenuDao> receiveStatus = new ReceiveStatus<MenuDao>();
            //获取用户，并验证
            var userModel = _userRepository.GetByKey(userId, BaseSqlRepository.sysUser_selectByKeySql);
            if (userModel == null)
                return ExceptionHelper<MenuDao>.CustomExceptionData(string.Format("用户Id【{0}】不存在", userId));

            //获取用户角色，并验证
            var userRoleList = _sysUserRoleRelationRepository.GetSysUserRoleRelationsByUserId(userModel.UserId);
            if (userRoleList == null || userRoleList.Count == 0)
                return ExceptionHelper<MenuDao>.CustomExceptionData(string.Format("用户【{0}】未分配角色", userModel.UserName));
            var roleIdList = userRoleList.Select(f => f.RoleId).ToList();

            //获取角色菜单
            var menuRoleList = _sysMenuRoleRelationRepository.GetSysMenuRoleRelationByRoleId(roleIdList);
            if (menuRoleList == null || menuRoleList.Count == 0)
                return ExceptionHelper<MenuDao>.CustomExceptionData(string.Format("用户【{0}】未分配菜单", userModel.UserName));

            //递归菜单并返回
            var menuIdList = menuRoleList.GroupBy(f => f.MenuId).Select(f => f.Key).ToList();
            var menuList = _menuRepository.GetMenusByMenuIdList(menuIdList);
            var menuDaoList = MenuCore.GetMenuDao(menuList);
            receiveStatus.data = menuDaoList;
            receiveStatus.msg = "获取成功";
            return receiveStatus;
        }
        #endregion

    }
}
