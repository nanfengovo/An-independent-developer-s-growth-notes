using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{
    /// <summary>
    /// 匹配条件输入模型
    /// </summary>
    public class MatchingWhereInput
    {
        /// <summary>
        /// json匹配条件
        /// </summary>
        public string jsonWhere { get; set; }

        /// <summary>
        /// 菜单id
        /// </summary>
        public int menuId { get; set; }

        /// <summary>
        /// 行权限id
        /// </summary>
        public int rowAuthId { get; set; }

        /// <summary>
        /// 规则备注
        /// </summary>
        public string ruleRemark { get; set; }

        /// <summary>
        /// 是否开启
        /// </summary>
        public bool isOpen { get; set; }
    }
}
