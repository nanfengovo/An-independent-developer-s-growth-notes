using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{
    /// <summary>
    /// 菜单数据列输出模型
    /// </summary>
    [EnitityMapping(MenuId = "71")]
    public class SysMenuTableColsDataOutPut
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Description("主键")]
        public string Id { get; set; }

        /// <summary>
        /// 菜单id
        /// </summary>
        [Description("菜单id")]
        public int MenuId { get; set; }

        /// <summary>
        /// 所在菜单标题
        /// </summary>
        [Description("所属菜单")]
        public string MenuTitle { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        [Description("字段名称")]
        public string FieldName { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        [Description("字段类型")]
        public string FieldType { get; set; }

        /// <summary>
        /// 字段标题
        /// </summary>
        [Description("字段标题")]
        public string FieldTitle { get; set; }

        /// <summary>
        /// 字段排序
        /// </summary>
        [Description("字段排序")]
        public int FieldOrderBy { get; set; }

        /// <summary>
        /// 字段所占宽度
        /// </summary>
        [Description("字段宽度")]
        public string FieldWidth { get; set; }

        /// <summary>
        /// 字段排序方式（desc、asc）为空不排序
        /// </summary>
        [Description("排序方式")]
        public string FieldSort { get; set; }

        /// <summary>
        /// 自定义插槽
        /// </summary>
        [Description("自定义插槽")]
        public string FieldCustomSlot { get; set; }

        /// <summary>
        /// 字段对齐方式（left right center）
        /// </summary>
        [Description("对齐方式")]
        public string FieldAlign { get; set; }

        /// <summary>
        /// 字段列固定（left right）
        /// </summary>
        [Description("固定方式")]
        public string FieldFixed { get; set; }

        /// <summary>
        /// 字段所占最小宽度
        /// </summary>
        [Description("最小宽度")]
        public string FieldMinWidth { get; set; }

        /// <summary>
        /// 字段过长是否隐藏
        /// </summary>
        [Description("是否隐藏提示")]
        public bool FieldEllipsisTooltip { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人员
        /// </summary>
        [Description("创建人员id")]
        public string CreateUser { get; set; }

        /// <summary>
        /// 是否系统数据
        /// </summary>
        [Description("是否系统数据")]
        public int IsSystemData { get; set; }

        /// <summary>
        /// 1:属于数据行权限字段 2:不属于数据行权限字段
        /// </summary>
        [Description("数据权限类型")]
        public int DataRowAuthType { get; set; }

        /// <summary>
        /// 数据行权限字段（必须和查询表中的字段对应）
        /// </summary>
        [Description("数据行权限字段")]
        public string DataRowAuthField { get; set; }

        /// <summary>
        /// 数据行权限字段名称
        /// </summary>
        [Description("数据行权限字段名称")]
        public string DataRowAuthFieldName { get; set; }
    }
}
