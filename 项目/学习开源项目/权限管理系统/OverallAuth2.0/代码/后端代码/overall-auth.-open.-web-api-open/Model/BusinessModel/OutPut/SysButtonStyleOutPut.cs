using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{
    /// <summary>
    /// 按钮样式输出类
    /// </summary>
    [EnitityMapping(MenuId = "35")]
    public class SysButtonStyleOutPut : LayuiTableOutPut
    {
        /// <summary>
        /// 按钮样式id
        /// </summary>
        [Description("按钮样式id")]
        public int ButtonStyleId { get; set; }

        /// <summary>
        /// 边框样式  soild dashed dotted
        /// </summary>
        [Description("边框颜色")]
        public string BordersStyle { get; set; }

        /// <summary>
        /// 按钮大小  lg sm xs
        /// </summary>
        [Description("按钮大小")]
        public string Size { get; set; }

        /// <summary>
        /// 样式 primary normal warm danger
        /// </summary>
        [Description("按钮样式")]
        public string Types { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Description("按钮图标")]
        public string Icon { get; set; }

        /// <summary>
        /// 样式名称
        /// </summary>
        [Description("样式名称")]
        public string ButtonStyleName { get; set; }

        /// <summary>
        /// 边框颜色  green blue orange red
        /// </summary>
        [Description("边框颜色")]
        public string Borders { get; set; }

        /// <summary>
        /// 是否圆角
        /// </summary>
        [Description("是否圆角")]
        public bool IsRadius { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Description("排序")]
        public int OrderBy { get; set; }

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

        /// <summary>
        /// 创建人姓名
        /// </summary>
        [Description("创建人姓名")]
        public string UserName { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        [Description("主键")]
        public override string Id { get { return ButtonStyleId.ToString(); } }

    }
}
