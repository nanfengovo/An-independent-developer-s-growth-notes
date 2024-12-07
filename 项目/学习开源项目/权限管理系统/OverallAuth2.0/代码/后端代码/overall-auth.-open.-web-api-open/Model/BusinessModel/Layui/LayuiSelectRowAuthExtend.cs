using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{
    /// <summary>
    /// 对layui对应下拉框模型的扩展
    /// </summary>
    public class LayuiSelectRowAuthExtend : LayuiSelect
    {

        public int Id { get; set; }

        /// <summary>
        /// 等式结果显示控件格式
        /// </summary>
        public int ShowControl { get; set; }

        /// <summary>
        /// 等式结果显示控件格式名称
        /// </summary>
        public string ShowControlName { get; set; }

        /// <summary>
        /// 等式结果显示控件数据源
        /// </summary>
        public string ShowControlDataSource { get; set; }

        /// <summary>
        /// 等式结果显示控件数据源名称
        /// </summary>
        public string ShowControlDataSourceName { get; set; }

        /// <summary>
        /// 条件等式下拉值
        /// </summary>
        public List<LayuiSelect> ConditionalEquationList { get; set; } = new List<LayuiSelect>();

        /// <summary>
        /// 等式结果下拉框值
        /// </summary>
        public List<LayuiSelect> ConditionalEquationValueList { get; set; } = new List<LayuiSelect>();
    }
}
