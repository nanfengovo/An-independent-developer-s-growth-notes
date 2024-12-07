using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{
    /// <summary>
    /// 匹配数据输入
    /// </summary>
    public class MatchingDataInput
    {
        /// <summary>
        /// 组id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 上级id
        /// </summary>
        public string pid { get; set; }

        /// <summary>
        /// 匹配组
        /// </summary>
        public string matchGroup { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        public int level { get; set; }

        /// <summary>
        /// 匹配条件
        /// </summary>
        public List<MatchingWhereData> matchingWhere { get; set; } = new List<MatchingWhereData>();

        /// <summary>
        /// 子集
        /// </summary>
        public List<MatchingDataInput> children { get; set; } = new List<MatchingDataInput>();
    }

    public class MatchingWhereData
    {
        /// <summary>
        /// 项id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 字段key（选中的字段）
        /// </summary>
        public string fieldKey { get; set; }

        /// <summary>
        /// 符号key（选中的符号）
        /// </summary>
        public string matchSymbolKey { get; set; }

        /// <summary>
        /// 字段对应匹配符
        /// </summary>
        public List<LayuiSelect> matchSymbolOptions { get; set; } = new List<LayuiSelect>();

        /// <summary>
        /// 等式结果显示控件格式
        /// </summary>
        public int showControl { get; set; }

        /// <summary>
        /// 匹配数据（等式结果集）
        /// </summary>
        public List<LayuiSelect> matchData { get; set; } = new List<LayuiSelect>();

        /// <summary>
        /// 匹配数据key（选中的等式结果--单值）
        /// </summary>
        public string matchDataKey { get; set; }

        /// <summary>
        /// 匹配数据key（选中的等式结果--多值）
        /// </summary>
        public List<string> matchDataKeys { get; set; } = new List<string>();
    }
}
