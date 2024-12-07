using Dapper;
using Model;
using Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    /// <summary>
    /// 菜单数据行权限仓储接口实现
    /// </summary>
    public class SysMenuTableRowAuthRepository : Repository<SysMenuTableRowAuth>, ISysMenuTableRowAuthRepository
    {
        /// <summary>
        /// 根据菜单id，获取菜单行权限
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <returns></returns>
        public List<SysMenuTableRowAuthOutPut> GetTableRowAuthByMenuId(int menuId)
        {
            string sql = " select * from  Sys_MenuTableRowAuth where MenuId = @Key  ";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Query<SysMenuTableRowAuthOutPut>(sql, new { Key = menuId }).ToList();
        }

        /// <summary>
        /// 批量更新IsOpen字段
        /// </summary>
        /// <param name="menuId">主键集合</param>
        /// <param name="isOpen">是否开启</param>
        public void UpdateIsOpenByMenuId(int menuId, bool isOpen)
        {
            string sql = " update Sys_MenuTableRowAuth set IsOpen=@IsOpen  where MenuId =@MenuId  ";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            connection.Execute(sql, new { MenuId = menuId, IsOpen = isOpen });
        }

        /// <summary>
        /// 批量更新IsOpen字段
        /// </summary>
        /// <param name="id">主键集合</param>
        /// <param name="isOpen">是否开启</param>
        public void UpdateIsOpenById(int id, bool isOpen)
        {
            string sql = " update  Sys_MenuTableRowAuth set IsOpen=@IsOpen  where Id =@Id  ";
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            connection.Execute(sql, new { Id = id, IsOpen = isOpen });
        }
    }
}
