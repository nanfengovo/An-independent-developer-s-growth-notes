using System;
using System.ComponentModel;

namespace Model.BusinessModel
{
    /// <summary>
    /// 菜单数据行权限输出模型
    /// </summary>
    [EnitityMapping(MenuId = "72")]
    public class SysMenuTableRowAuthOutPut
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Description("主键")]
        public int Id { get; set; }

        /// <summary>
        /// 菜单id
        /// </summary>
        [Description("菜单id")]
        public int MenuId { get; set; }

        /// <summary>
        /// 规则json
        /// </summary>
        [Description("规则json")]
        public string RuleJson { get; set; }

        /// <summary>
        /// 是否使用
        /// </summary>
        [Description("是否使用")]
        public bool IsOpen { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Description("排序")]
        public int Sort { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人员
        /// </summary>
        [Description("创建人员")]
        public string CreateUser { get; set; }
    }
}
