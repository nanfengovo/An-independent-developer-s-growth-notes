using Infrastructure;
using Model;
using Model.BusinessModel;
using Subdomain.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace Domain
{

    /// <summary>
    /// 按钮服务实现
    /// </summary>
    public class SysButtonService : ISysButtonService
    {
        #region 构造实例化

        //仓储接口
        private readonly ISysButtonRepository _sysButtonRepository;
        private readonly ISysButtonRoleRepository _sysButtonRoleRepository;
        private readonly ISysMenuRepository _menuRepository;
        private readonly ISysRoleRepository _sysRoleRepository;

        /// <summary>
        /// 构造函数 实现依赖注入
        /// </summary>
        /// <param name="userRepository">仓储对象</param>
        public SysButtonService(ISysButtonRepository sysButtonRepository, ISysButtonRoleRepository sysButtonRoleRepository, ISysMenuRepository menuRepository, ISysRoleRepository sysRoleRepository)
        {
            _sysButtonRepository = sysButtonRepository;
            _sysButtonRoleRepository = sysButtonRoleRepository;
            _menuRepository = menuRepository;
            _sysRoleRepository = sysRoleRepository;
        }

        #endregion

        #region 服务实现

        /// <summary>
        /// 新增按钮数据
        /// </summary>
        /// <param name="sysButton"></param>
        public ReceiveStatus Insert(SysButton sysButton)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            var result = Validate(sysButton);
            if (!result.success)
                return result;
            _sysButtonRepository.Insert(sysButton, BaseSqlRepository.sysButton_insertSql);
            return receiveStatus;
        }

        /// <summary>
        /// 修改按钮数据
        /// </summary>
        /// <param name="sysButton"></param>
        public ReceiveStatus Update(SysButton sysButton)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            var result = Validate(sysButton);
            if (!result.success)
                return result;
            _sysButtonRepository.Update(sysButton, BaseSqlRepository.sysButton_updateSql);
            return receiveStatus;
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="sysMenuTableCols"></param>
        /// <returns></returns>
        public ReceiveStatus Validate(SysButton sysButton)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            /*
            新增/修改前验证
            1、相同菜单下不能有重复的按钮名称和事件key
            */
            var buttonList = _sysButtonRepository.GetButtonByMenuId(sysButton.MenuId);
            foreach (var item in buttonList)
            {
                if (sysButton.ButtonName.ToLower() == item.ButtonName.ToLower() && Convert.ToInt32(item.Id) != sysButton.ButtonId)
                    return ExceptionHelper.CustomException(string.Format("该菜单已存在按钮名称为【{0}】的按钮,请重新输入", sysButton.ButtonName));
                if (sysButton.ButtonKey.ToLower() == item.ButtonKey.ToLower() && Convert.ToInt32(item.Id) != sysButton.ButtonId)
                    return ExceptionHelper.CustomException(string.Format("该菜单已存在按钮Key为【{0}】的按钮,请重新输入", sysButton.ButtonKey));
            }

            return receiveStatus;
        }
        /// <summary>
        /// 新增按钮角色权限
        /// </summary>
        /// <param name="menuButtonRoleInput"></param>
        /// <param name="loginResult">操作人员信息</param>
        public ReceiveStatus InsertButtonRole(MenuButtonRoleInput menuButtonRoleInput, LoginResult loginResult)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            //获取角色
            var roleModel = _sysRoleRepository.GetByKey(menuButtonRoleInput.roleId.ToString(), BaseSqlRepository.sysRole_selectByKeySql);
            if (roleModel == null)
                return ExceptionHelper.CustomException(string.Format("角色id为【{0}】的角色不存在", menuButtonRoleInput.roleId));
            var menuModel = _menuRepository.GetByKey(menuButtonRoleInput.menuId.ToString(), BaseSqlRepository.menu_selectByKeySql);
            if (menuModel == null)
                return ExceptionHelper.CustomException(string.Format("菜单id为【{0}】的角色不存在", menuButtonRoleInput.menuId));

            _sysButtonRoleRepository.DeleteButtonByRoleIdOrMenuId(menuButtonRoleInput.roleId, menuButtonRoleInput.menuId);
            //新增菜单按钮权限
            var dateTime = DateTime.Now;
            foreach (var item in menuButtonRoleInput.buttonIds)
            {
                SysButtonRole sysButtonRole = new SysButtonRole
                {
                    MenuId = menuButtonRoleInput.menuId,
                    ButtonId = item,
                    RoleId = menuButtonRoleInput.roleId,
                    CreateTime = dateTime,
                    CreateUser = loginResult.UserId.ToString()
                };
                _sysButtonRoleRepository.Insert(sysButtonRole, BaseSqlRepository.sysButtonRole_insertSql);
            }
            return receiveStatus;
        }

        /// <summary>
        /// 获取菜单拥有按钮
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <param name="roleId">角色id</param>
        /// <returns>返回对应按钮集合</returns>
        public ReceiveStatus<SysButtonOutPut> GetMenuHaveButton(int menuId, int roleId)
        {
            ReceiveStatus<SysButtonOutPut> receiveStatus = new();
            SysButtonOutPut sysButtonOutPut = new();
            sysButtonOutPut.SysButtonData = _sysButtonRepository.GetButtonByMenuId(menuId);
            //取对应角色菜单拥有的按钮权限
            var buttonRoleList = _sysButtonRoleRepository.GetButtonByRoleIdOrMenuId(roleId, menuId);
            if (buttonRoleList != null || buttonRoleList.Count > 0)
                sysButtonOutPut.SelectedKeys = buttonRoleList.Select(f => f.ButtonId.ToString()).ToArray();

            receiveStatus.data = new List<SysButtonOutPut>() { sysButtonOutPut };
            receiveStatus.msg = "获取成功";
            return receiveStatus;
        }

        /// <summary>
        /// 获取按钮
        /// </summary>
        /// <param name="pageResultModel">分页模型</param>
        /// <param name="loginResult">登陆人员信息</param>
        /// <returns>返回按钮集合</returns>
        public PageResultModel<SysButtonDataOutPut> GetButtonList(PageResultModel pageResultModel, LoginResult loginResult)
        {
            var selectWhere = DataAuthCore.GetRowDataAuthRoleSql("b", pageResultModel.menuId, loginResult);
            pageResultModel.selectWhere = selectWhere;
            pageResultModel.tableField = " su.CreateTime,su.UserName,b.MenuId,b.ButtonStyleId,b.ButtonId,b.ButtonName,b.ButtonKey,s.BordersStyle,s.[Size],s.Types,s.Icon,s.ButtonStyleName,s.Borders,s.IsRadius,b.OrderBy,(select d.MenuTitle+'->' +m.MenuTitle from Sys_Menu as d where  d.Id = m.Pid ) MenuTitle,b.CreateUser  ";
            pageResultModel.tableName = @" Sys_Button as b  
                                            inner join  Sys_ButtonStyle as s  on b.ButtonStyleId = s.ButtonStyleId
                                            inner join  Sys_Menu as m  on b.MenuId = m.Id
                                            inner  join Sys_User as su on su.UserId = b.CreateUser ";
            pageResultModel.orderByField = " b.CreateTime desc ";
            var list = _sysButtonRepository.GetPageList<SysButtonDataOutPut>(pageResultModel);
            return list;
        }

        /// <summary>
        /// 根据菜单和角色获取按钮
        /// </summary>
        /// <param name="roleId">角色集合</param>
        /// <param name="menuId">菜单id</param>
        /// <returns></returns>
        public ReceiveStatus<SysButtonDataOutPut> GetButtonByRoleIdOrMenuId(List<int> roleId, int menuId)
        {
            ReceiveStatus<SysButtonDataOutPut> receiveStatus = new ReceiveStatus<SysButtonDataOutPut>();
            receiveStatus.data = _sysButtonRoleRepository.GetButtonByRoleIdOrMenuId(roleId, menuId);
            receiveStatus.msg = "获取成功";
            return receiveStatus;
        }

        /// <summary>
        /// 获取所有下拉树菜单
        /// </summary>
        /// <returns></returns>
        public ReceiveStatus<LayuiTree> GetMenuSelectTree()
        {
            ReceiveStatus<LayuiTree> receiveStatus = new ReceiveStatus<LayuiTree>();
            //获取所有菜单，并转换成tree
            var list = _menuRepository.GetMenusList();
            receiveStatus.data = MenuCore.GetRoleMenuDao(list, true, false);
            receiveStatus.msg = "获取成功";
            return receiveStatus;
        }
        #endregion
    }
}
