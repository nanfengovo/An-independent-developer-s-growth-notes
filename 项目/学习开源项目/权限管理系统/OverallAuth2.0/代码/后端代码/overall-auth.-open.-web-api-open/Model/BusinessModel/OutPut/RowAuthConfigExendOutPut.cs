using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{
    /// <summary>
    /// 行权限配置扩展模型
    /// </summary>
    public class RowAuthConfigExendOutPut
    {
        /// <summary>
        /// 字段集合
        /// </summary>
        public List<LayuiSelect> PermissionsFieldList { get; set; } = new List<LayuiSelect>();

        /// <summary>
        /// 条件等式集合
        /// </summary>
        public List<LayuiSelect> ConditionalEquationValueList { get; set; } = new List<LayuiSelect>();

        /// <summary>
        /// 显示控件集合
        /// </summary>
        public List<LayuiSelect> ShowControlList { get; set; } = new List<LayuiSelect>();

        /// <summary>
        /// 显示控件数据来源集合
        /// </summary>
        public List<LayuiSelect> ShowControlDataSourceList { get; set; } = new List<LayuiSelect>();

    }
}
