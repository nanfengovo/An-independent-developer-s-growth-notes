using Infrastructure;
using Model;
using Model.BusinessModel;
using System;
using System.Collections.Generic;
using Utility;

namespace Domain
{
    /// <summary>
    /// 菜单数据列权限服务接口实现
    /// </summary>
    public class SysMenuTableColsRoleService : ISysMenuTableColsRoleService
    {
        #region 构造实例化

        //仓储接口
        private readonly ISysMenuTableColsRoleRepository _sysMenuTableColsRoleRepository;
        private readonly ISysRoleRepository _sysRoleRepository;
        private readonly ISysMenuRepository _menuRepository;

        /// <summary>
        /// 构造实例化 实现依赖注入
        /// </summary>
        /// <param name="sysMenuTableColsRoleRepository"></param>
        public SysMenuTableColsRoleService(ISysMenuTableColsRoleRepository sysMenuTableColsRoleRepository, ISysRoleRepository sysRoleRepository, ISysMenuRepository menuRepository)
        {
            _sysMenuTableColsRoleRepository = sysMenuTableColsRoleRepository;
            _sysRoleRepository = sysRoleRepository;
            _menuRepository = menuRepository;
        }

        #endregion

        #region  服务实现

        /// <summary>
        /// 新增数据列
        /// </summary>
        /// <param name="sysMenuTableColsRole">数据列数据</param>
        /// <param name="loginResult">登陆人员信息</param>
        public ReceiveStatus Insert(SysMenuTableColsRoleInput sysMenuTableColsRole, LoginResult loginResult)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            //获取角色
            var roleModel = _sysRoleRepository.GetByKey(sysMenuTableColsRole.roleId.ToString(), BaseSqlRepository.sysRole_selectByKeySql);
            if (roleModel == null)
                return ExceptionHelper.CustomException(string.Format("角色id为【{0}】的角色不存在", sysMenuTableColsRole.roleId));
            var menuModel = _menuRepository.GetByKey(sysMenuTableColsRole.menuId.ToString(), BaseSqlRepository.menu_selectByKeySql);
            if (menuModel == null)
                return ExceptionHelper.CustomException(string.Format("菜单id为【{0}】的角色不存在", sysMenuTableColsRole.menuId));

            _sysMenuTableColsRoleRepository.DeleteMenuTableColsByRoleIdOrMenuId(sysMenuTableColsRole.roleId, sysMenuTableColsRole.menuId);
            //新增菜单列权限
            var dateTime = DateTime.Now;
            foreach (var item in sysMenuTableColsRole.menuTableColsIds)
            {
                SysMenuTableColsRole sysMenuColsRole = new SysMenuTableColsRole
                {
                    MenuId = sysMenuTableColsRole.menuId,
                    MenuTableColsId = item,
                    RoleId = sysMenuTableColsRole.roleId,
                    CreateTime = dateTime,
                    CreateUser = loginResult.UserId.ToString()
                };
                _sysMenuTableColsRoleRepository.Insert(sysMenuColsRole, BaseSqlRepository.sysMenuTableColsRole_insertSql);
            }

            return receiveStatus;
        }

        /// <summary>
        /// 修改按钮数据
        /// </summary>
        /// <param name="sysMenuTableColsRole"></param>
        public void Update(SysMenuTableColsRole sysMenuTableColsRole)
        {
            _sysMenuTableColsRoleRepository.Update(sysMenuTableColsRole, BaseSqlRepository.sysMenuTableColsRole_updateSql);
        }

        /// <summary>
        /// 删除数据列
        /// </summary>
        /// <param name="id">主键</param>
        public void Delete(int id)
        {
            _sysMenuTableColsRoleRepository.Delete(id.ToString(), BaseSqlRepository.sysMenuTableColsRole_delete);
        }

        /// <summary>
        /// 根据角色id和菜单id获取菜单数据列
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="menuId">菜单id</param>
        /// <returns>返回对应菜单数据列集合</returns>
        public ReceiveStatus<SysMenuTableColsDataOutPut> GetTableColsRoleByRoleIdOrMenuId(List<int> roleId, int menuId)
        {
            ReceiveStatus<SysMenuTableColsDataOutPut> receiveStatus = new ReceiveStatus<SysMenuTableColsDataOutPut>();
            receiveStatus.data = _sysMenuTableColsRoleRepository.GetTableColsRoleByRoleIdOrMenuId(roleId, menuId);
            receiveStatus.msg = "获取成功";
            return receiveStatus;
        }
        #endregion
    }
}
