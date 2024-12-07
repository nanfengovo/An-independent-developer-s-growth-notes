using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Infrastructure
{
    /// <summary>
    /// 用户仓储
    /// </summary>
    public interface ISysUserRepository : IRepository<SysUser>
    {
        /// <summary>
        /// 根据用户名称和密码获取用户信息
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="password">用户密码</param>
        /// <returns></returns>
        SysUser GetUserMsg(string userName,string password);
    }
}
