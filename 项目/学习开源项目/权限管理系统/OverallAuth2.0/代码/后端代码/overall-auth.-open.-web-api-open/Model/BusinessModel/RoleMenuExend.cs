using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// 角色和菜单关系扩展模型
    /// </summary>
    public class RoleMenuExend
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public int roleId { get; set; }

        /// <summary>
        /// 菜单id集合
        /// </summary>
        public List<int> menuIds { get; set; }
    }
}
