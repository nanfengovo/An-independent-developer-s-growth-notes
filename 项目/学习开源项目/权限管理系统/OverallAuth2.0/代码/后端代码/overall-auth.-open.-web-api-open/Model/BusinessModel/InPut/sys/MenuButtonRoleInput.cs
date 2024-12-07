using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{
    /// <summary>
    /// 菜单按钮权限接收模型
    /// </summary>
    public class MenuButtonRoleInput
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
        /// 按钮id集合
        /// </summary>
        public List<int> buttonIds { get; set; }
    }
}
