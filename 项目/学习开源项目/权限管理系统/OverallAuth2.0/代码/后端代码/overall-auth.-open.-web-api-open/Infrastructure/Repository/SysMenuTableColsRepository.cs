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
    /// 菜单数据列仓储接口实现
    /// </summary>
    public class SysMenuTableColsRepository : Repository<SysMenuTableCols>, ISysMenuTableColsRepository
    {
        /// <summary>
        /// 根据菜单id获取列
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns>返回对应列集合</returns>
        public List<SysMenuTableColsDataOutPut> GetTableColsByMenuId(int menuId)
        {
            string sql = @" select b.*,(select d.MenuTitle+'->' +m.MenuTitle from Sys_Menu as d where  d.Id = m.Pid ) MenuTitle  from  Sys_MenuTableCols as b  
                            inner join  Sys_Menu as m  on b.MenuId = m.Id
                            where MenuId = @MenuId ";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Query<SysMenuTableColsDataOutPut>(sql, new { MenuId = menuId }).ToList();
        }

        /// <summary>
        /// 根据菜单id和数据权限类型获取列
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <param name="dataRowAuthType">数据权限类型</param>
        /// <returns>返回对应列集合</returns>
        public List<SysMenuTableColsDataOutPut> GetTableColsByMenuIdOrDataRowAuthType(int menuId, int dataRowAuthType)
        {
            string sql = @" select  DataRowAuthType,DataRowAuthField,DataRowAuthFieldName  from  Sys_MenuTableCols 
                            where MenuId = @MenuId  and DataRowAuthType =@DataRowAuthType";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Query<SysMenuTableColsDataOutPut>(sql, new { MenuId = menuId, DataRowAuthType = dataRowAuthType }).ToList();
        }

        /// <summary>
        /// 根据菜单id和字段名称获取数据列
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <param name="fieldName">字段名称</param>
        /// <returns>返回数据列</returns>
        public SysMenuTableCols GetTableColsByMenuIdOrFieldName(int menuId, string fieldName)
        {
            string sql = @" select  * from  Sys_MenuTableCols where  MenuId =@MenuId and FieldName=@FieldName ";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.QueryFirstOrDefault<SysMenuTableCols>(sql, new { MenuId = menuId, FieldName = fieldName });
        }

        /// <summary>
        /// 修改字段信息
        /// </summary>
        /// <param name="sysMenuTableCols"></param>
        public void UpdateTableCols(SysMenuTableCols sysMenuTableCols)
        {
            string sql = @" update  Sys_MenuTableCols set  FieldName = @FieldName,FieldType=@FieldType  where  Id = @Id ";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            connection.Execute(sql, new { Id = sysMenuTableCols.Id, FieldName = sysMenuTableCols.FieldName, FieldType = sysMenuTableCols.FieldType });
        }
    }
}
