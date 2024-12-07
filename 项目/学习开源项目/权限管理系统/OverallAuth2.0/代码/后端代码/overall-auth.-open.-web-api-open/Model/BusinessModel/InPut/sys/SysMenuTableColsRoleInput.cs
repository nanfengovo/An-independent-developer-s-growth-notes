using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{

    /// <summary>
    /// 菜单列权限接收模型
    /// </summary>
    public class SysMenuTableColsRoleInput
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public int roleId { get; set; }

        /// <summary>
        /// 菜单id集合
        /// </summary>
        public int menuId { get; set; }

        /// <summary>
        /// 菜单列id集合
        /// </summary>
        public List<int> menuTableColsIds { get; set; }
    }
}
