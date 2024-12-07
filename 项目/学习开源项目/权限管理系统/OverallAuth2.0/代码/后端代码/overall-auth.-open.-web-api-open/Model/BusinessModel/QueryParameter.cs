using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 查询条件
    /// </summary>
    public class QueryParameter
    {
        /// <summary>
        /// 实例化查询条件
        /// </summary>
        public QueryParameter()
        {
            listWhere = new StringBuilder();
            dynamicParameter = new DynamicParameters();
        }

        /// <summary>
        /// 条件
        /// </summary>
        public StringBuilder listWhere { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public DynamicParameters dynamicParameter { get; set; }

    }
}
