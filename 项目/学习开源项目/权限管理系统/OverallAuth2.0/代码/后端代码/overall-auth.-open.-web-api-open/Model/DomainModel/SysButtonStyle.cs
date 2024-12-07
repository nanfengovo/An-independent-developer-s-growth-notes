using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 按钮样式
    /// </summary>
    public class SysButtonStyle
    {
        public int ButtonStyleId { get; set; }

        /// <summary>
        /// 边框样式  soild dashed dotted
        /// </summary>
        public string BordersStyle { get; set; }

        /// <summary>
        /// 按钮大小  lg sm xs
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// 样式 primary normal warm danger
        /// </summary>
        public string Types { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 样式名称
        /// </summary>
        public string ButtonStyleName { get; set; }

        /// <summary>
        /// 边框颜色  green blue orange red
        /// </summary>
        public string Borders { get; set; }

        /// <summary>
        /// 是否圆角
        /// </summary>
        public bool IsRadius { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int OrderBy { get; set; }

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
