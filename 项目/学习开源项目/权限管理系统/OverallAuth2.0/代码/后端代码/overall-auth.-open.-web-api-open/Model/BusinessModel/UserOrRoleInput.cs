using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 用户角色传入模型
    /// </summary>
    public class UserOrRoleInput
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 角色id集合
        /// </summary>
        public List<int> RoleId { get; set; }
    }
}
