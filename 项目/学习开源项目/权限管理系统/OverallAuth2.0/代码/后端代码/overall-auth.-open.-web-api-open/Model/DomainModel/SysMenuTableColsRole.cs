using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 菜单数据列权限模型
    /// </summary>
    public class SysMenuTableColsRole
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 菜单id
        /// </summary>
        public int MenuId { get; set; }

        /// <summary>
        /// 菜单数据列id
        /// </summary>
        public int MenuTableColsId { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人员
        /// </summary>
        public string CreateUser { get; set; }
    }
}
