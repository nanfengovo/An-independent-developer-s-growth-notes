using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 分页模型
    /// </summary>
    public class PageResultModel
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int pageIndex { get; set; }

        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int pageSize { get; set; }

        /// <summary>
        /// 查询表字段
        /// </summary>
        public string tableField { get; set; }

        /// <summary>
        /// 查询表
        /// </summary>
        public string tableName { get; set; }

        /// <summary>
        /// 查询条件
        /// </summary>
        public string selectWhere { get; set; }

        /// <summary>
        /// 查询条件json
        /// </summary>
        public string filterJson { get; set; }

        /// <summary>
        /// 当前菜单id
        /// </summary>
        public string menuId { get; set; }

        /// <summary>
        /// 排序字段（不能为空）
        /// </summary>
        public string orderByField { get; set; }

        /// <summary>
        /// 排序类型
        /// </summary>
        public string sortType { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int total { get; set; }
    }

    /// <summary>
    /// 查询数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResultModel<T> : PageResultModel 
    {
        /// <summary>
        /// 数据
        /// </summary>
        public List<T> data { get; set; }
    }
}
