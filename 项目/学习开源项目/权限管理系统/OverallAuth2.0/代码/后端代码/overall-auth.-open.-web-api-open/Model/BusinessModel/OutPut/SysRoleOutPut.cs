using System;
using System.ComponentModel;

namespace Model.BusinessModel
{
    /// <summary>
    /// 角色输出模型
    /// </summary>
    [EnitityMapping(MenuId = "39")]
    public class SysRoleOutPut : LayuiTableOutPut
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Description("主键")]
        public override string Id { get { return RoleId.ToString(); } }

        /// <summary>
        /// 角色id
        /// </summary>
        [Description("角色id")]
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Description("角色名称")]
        public string RoleName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人员
        /// </summary>
        [Description("创建人员id")]
        public string CreateUser { get; set; }
    }
}
