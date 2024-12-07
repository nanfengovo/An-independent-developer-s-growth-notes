using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{
    /// <summary>
    /// layuiTable 默认返回列,使用table绑定必须继承该内,如果模型中本身有id就不用继承
    /// </summary>
    public abstract class LayuiTableOutPut
    {
        /// <summary>
        /// 主键（layui中table的固定格式）
        /// </summary>
        public abstract string Id { get; }
    }
}
