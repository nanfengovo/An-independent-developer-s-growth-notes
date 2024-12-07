using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{
    /// <summary>
    /// 菜单行权限配置输入模型
    /// </summary>
    public class SysMenuTableRowAuthConfigInput
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ConfigId { get; set; }

        /// <summary>
        /// 菜单id
        /// </summary>
        public int MenuId { get; set; }

        /// <summary>
        /// 是否开启
        /// </summary>
        public bool IsOpen { get; set; }

        /// <summary>
        /// 显示控件数据源
        /// </summary>
        public string ShowControlDataSource { get; set; }

        /// <summary>
        /// 显示控件样式
        /// </summary>
        public string ShowControl { get; set; }

        /// <summary>
        /// 字段
        /// </summary>
        public string PermissionsField { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string PermissionsFieldName { get; set; }

        /// <summary>
        /// 等式条件值
        /// </summary>
        public List<string> ConditionalEquationValue { get; set; }
    }
}
