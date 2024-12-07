using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 自定义特性 属性或者类可用  支持继承
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = true)]
    public class EnitityMappingAttribute : Attribute
    {
        /// <summary>
        /// 实体实际对应的表名
        /// </summary>
        public string TableName
        {
            get;set;
        }

        /// <summary>
        /// 菜单id
        /// </summary>
        public string MenuId
        {get;set;
        }
    }
}
