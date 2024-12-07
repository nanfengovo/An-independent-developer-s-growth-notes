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
    /// 按钮仓储
    /// </summary>
    public class SysButtonRepository : Repository<SysButton>, ISysButtonRepository
    {
        
        /// <summary>
        /// 根据菜单id获取按钮
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns>返回对应按钮集合</returns>
        public List<SysButtonDataOutPut> GetButtonByMenuId(int menuId)
        {
            string sql = @" select b.ButtonId,b.ButtonName,b.ButtonKey,s.BordersStyle,s.[Size],s.Types,s.Icon,s.ButtonStyleName,s.Borders,s.IsRadius,b.OrderBy,(select d.MenuTitle+'->' +m.MenuTitle from Sys_Menu as d where  d.Id = m.Pid ) MenuTitle  from  Sys_Button as b  
                            inner join  Sys_ButtonStyle as s  on b.ButtonStyleId = s.ButtonStyleId
                            inner join  Sys_Menu as m  on b.MenuId = m.Id
                            where MenuId = @MenuId ";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Query<SysButtonDataOutPut>(sql, new { MenuId = menuId }).ToList();
        }
    }
}
