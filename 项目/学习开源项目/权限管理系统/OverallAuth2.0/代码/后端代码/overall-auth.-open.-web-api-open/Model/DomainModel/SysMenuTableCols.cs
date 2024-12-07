using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 菜单表格列
    /// </summary>
    public class SysMenuTableCols
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
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        public string FieldType { get; set; }

        /// <summary>
        /// 字段标题
        /// </summary>
        public string FieldTitle { get; set; }

        /// <summary>
        /// 字段排序
        /// </summary>
        public int FieldOrderBy { get; set; }

        /// <summary>
        /// 字段所占宽度
        /// </summary>
        public int FieldWidth { get; set; }

        /// <summary>
        /// 字段排序方式（desc、asc）为空不排序
        /// </summary>
        public string FieldSort { get; set; }

        /// <summary>
        /// 自定义插槽
        /// </summary>
        public string FieldCustomSlot { get; set; }

        /// <summary>
        /// 字段对齐方式（left right center）
        /// </summary>
        public string FieldAlign { get; set; }

        /// <summary>
        /// 字段列固定（left right）
        /// </summary>
        public string FieldFixed { get; set; }

        /// <summary>
        /// 字段所占最小宽度
        /// </summary>
        public int FieldMinWidth { get; set; }

        /// <summary>
        /// 字段过长是否隐藏
        /// </summary>
        public bool FieldEllipsisTooltip { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人员
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 1:系统数据 2:创建数据
        /// </summary>
        public int IsSystemData { get; set; }

        /// <summary>
        /// 1:属于数据行权限字段 2:不属于数据行权限字段
        /// </summary>
        public int DataRowAuthType { get; set; }

        /// <summary>
        /// 数据行权限字段（必须和查询表中的字段对应）
        /// </summary>
        public string DataRowAuthField { get; set; }

        /// <summary>
        /// 数据行权限字段名称
        /// </summary>
        public string DataRowAuthFieldName { get; set; }

    }
}
