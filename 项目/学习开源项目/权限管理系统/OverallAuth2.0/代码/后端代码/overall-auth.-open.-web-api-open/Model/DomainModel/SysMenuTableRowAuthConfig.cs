using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 菜单数据行权限配置模型
    /// </summary>
    public class SysMenuTableRowAuthConfig
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 菜单id
        /// </summary>
        public int MenuId { get; set; }

        /// <summary>
        /// 权限字段
        /// </summary>
        public string PermissionsField { get; set; }

        /// <summary>
        /// 权限字段名称
        /// </summary>
        public string PermissionsFieldName { get; set; }

        /// <summary>
        /// 条件等式值
        /// </summary>
        public int ConditionalEquationValue { get; set; }

        /// <summary>
        /// 显示控件
        /// </summary>
        public int ShowControl { get; set; }

        /// <summary>
        /// 显示控件的数据源
        /// </summary>
        public int ShowControlDataSource { get; set; }

        /// <summary>
        /// 是否使用
        /// </summary>
        public bool IsOpen { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人员
        /// </summary>
        public string CreateUser { get; set; }
    }
}
