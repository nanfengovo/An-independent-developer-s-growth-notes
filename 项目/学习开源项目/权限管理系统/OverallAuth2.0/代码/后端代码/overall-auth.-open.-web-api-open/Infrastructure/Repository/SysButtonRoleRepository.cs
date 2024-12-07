using Dapper;
using Model;
using Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// 按钮角色仓储
    /// </summary>
    public class SysButtonRoleRepository : Repository<SysButtonRole>, ISysButtonRoleRepository
    {

        /// <summary>
        /// 根据角色id和菜单id获取按钮
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="menuId">菜单id</param>
        /// <returns>返回对应按钮集合</returns>
        public List<SysButtonRole> GetButtonByRoleIdOrMenuId(int roleId, int menuId)
        {
            string sql = @"select  * from  Sys_ButtonRole where  MenuId = @MenuId and  RoleId =@RoleId";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Query<SysButtonRole>(sql, new { MenuId = menuId, RoleId = roleId }).ToList();
        }

        /// <summary>
        /// 根据角色id和菜单id获取按钮
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="menuId">菜单id</param>
        /// <returns>返回对应按钮集合</returns>
        public List<SysButtonDataOutPut> GetButtonByRoleIdOrMenuId(List<int> roleId, int menuId)
        {
            string sql = @"select
	                       distinct b.MenuId,b.ButtonStyleId,b.ButtonId,b.ButtonName,b.ButtonKey,s.BordersStyle,s.[Size],s.Types,s.Icon,s.ButtonStyleName,s.Borders,s.IsRadius,b.OrderBy,(select d.MenuTitle+'->' +m.MenuTitle from Sys_Menu as d where  d.Id = m.Pid ) MenuTitle
                         from  Sys_Button as b  
                         inner join  Sys_ButtonStyle as s  on b.ButtonStyleId = s.ButtonStyleId
                         inner join Sys_ButtonRole as r on r.ButtonId = b.ButtonId 
                         inner join  Sys_Menu as m  on b.MenuId = m.Id
                         where r.MenuId=@MenuId and  r.RoleId in @RoleId";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Query<SysButtonDataOutPut>(sql, new { MenuId = menuId, RoleId = roleId }).ToList();
        }

        /// <summary>
        /// 根据角色id和菜单id删除菜单按钮权限
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="menuId">菜单id</param>
        public void DeleteButtonByRoleIdOrMenuId(int roleId, int menuId)
        {
            string sql = " delete from  Sys_ButtonRole where RoleId=@RoleId and  MenuId=@MenuId ";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            connection.Execute(sql, new { RoleId = roleId, MenuId = menuId });
        }
    }
}
