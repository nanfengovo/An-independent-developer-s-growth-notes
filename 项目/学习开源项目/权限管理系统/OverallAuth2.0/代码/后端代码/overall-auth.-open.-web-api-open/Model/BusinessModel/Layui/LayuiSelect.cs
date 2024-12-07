using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{
    /// <summary>
    /// layui对应下拉框模型
    /// </summary>
    public class LayuiSelect
    {
        /// <summary>
        /// 显示名称
        /// </summary>
        public string label { get; set; }

        /// <summary>
        /// 对应值
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool disabled { get; set; }
    }
}
