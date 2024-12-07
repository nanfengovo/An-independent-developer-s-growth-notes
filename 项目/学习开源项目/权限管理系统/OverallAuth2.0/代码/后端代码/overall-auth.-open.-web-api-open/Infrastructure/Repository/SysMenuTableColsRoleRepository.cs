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
    /// 菜单数据列权限仓储接口实现
    /// </summary>
    public class SysMenuTableColsRoleRepository : Repository<SysMenuTableColsRole>, ISysMenuTableColsRoleRepository
    {
        /// <summary>
        /// 根据角色id和菜单id获取菜单数据列
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="menuId">菜单id</param>
        /// <returns>返回对应菜单数据列集合</returns>
        public List<SysMenuTableColsRole> GetTableColsRoleByRoleIdOrMenuId(int roleId, int menuId)
        {
            string sql = @"select  * from  Sys_MenuTableColsRole where  MenuId = @MenuId and  RoleId =@RoleId";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Query<SysMenuTableColsRole>(sql, new { MenuId = menuId, RoleId = roleId }).ToList();
        }

        /// <summary>
        /// 根据角色id和菜单id获取菜单数据列
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="menuId">菜单id</param>
        /// <returns>返回对应菜单数据列集合</returns>
        public List<SysMenuTableColsDataOutPut> GetTableColsRoleByRoleIdOrMenuId(List<int> roleId, int menuId)
        {
            string sql = @"select distinct b.*,(select d.MenuTitle+'->' +m.MenuTitle from Sys_Menu as d where  d.Id = m.Pid ) MenuTitle  from  Sys_MenuTableCols as b  
                         inner join  Sys_Menu as m  on b.MenuId = m.Id
						 inner join  Sys_MenuTableColsRole as  mc on mc.MenuTableColsId = b.Id
                         where mc.MenuId=@MenuId and  mc.RoleId in @RoleId order by b.FieldOrderBy asc ";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Query<SysMenuTableColsDataOutPut>(sql, new { MenuId = menuId, RoleId = roleId }).ToList();
        }

        /// <summary>
        /// 根据角色id和菜单id删除菜单列权限
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="menuId">菜单id</param>
        public void DeleteMenuTableColsByRoleIdOrMenuId(int roleId, int menuId)
        {
            string sql = " delete from  Sys_MenuTableColsRole where RoleId=@RoleId and  MenuId=@MenuId ";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            connection.Execute(sql, new { RoleId = roleId, MenuId = menuId });
        }
    }
}
