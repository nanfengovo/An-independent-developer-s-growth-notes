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
    /// 按钮样式仓储
    /// </summary>
    public class SysButtonStyleRepository : Repository<SysButtonStyle>, ISysButtonStyleRepository
    {
        /// <summary>
        /// 根据按钮样式名称获取数据
        /// </summary>
        /// <param name="buttonStyleName">按钮样式名称</param>
        /// <param name="authWhere">权限条件</param>
        /// <returns></returns>
        public List<SysButtonStyleOutPut> GetByButtonStyleNameList(string buttonStyleName, string authWhere)
        {
            StringBuilder sql = new(@" select bs.*,su.UserName from Sys_ButtonStyle as bs
                                        inner join Sys_User as su on bs.CreateUser = su.UserId ");
            var qp = new QueryParameter();
            if (!string.IsNullOrWhiteSpace(buttonStyleName))
            {
                qp.listWhere.Append(" and bs.ButtonStyleName = @ButtonStyleName ");
                qp.dynamicParameter.Add("@ButtonStyleName", buttonStyleName);
            }
            if (!string.IsNullOrWhiteSpace(authWhere))
            {
                qp.listWhere.Append(authWhere);
            }
            if (!string.IsNullOrEmpty(qp.listWhere.ToString()))
            {
                sql.Append(" WHERE 1=1 " + qp.listWhere.ToString());
            }
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Query<SysButtonStyleOutPut>(sql.ToString(), qp.dynamicParameter).ToList();
        }
    }
}
