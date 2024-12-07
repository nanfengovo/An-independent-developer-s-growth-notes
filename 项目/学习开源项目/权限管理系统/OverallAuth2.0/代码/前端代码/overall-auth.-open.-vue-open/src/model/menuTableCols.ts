//菜单数据列模型
export interface menuTableColsModel {
    /// <summary>
    /// 主键
    /// </summary>
    Id: Number;

    /// <summary>
    /// 菜单id
    /// </summary>
    MenuId: Number | undefined;

    /// <summary>
    /// 所在菜单标题
    /// </summary>
    //MenuTitle: string;

    /// <summary>
    /// 字段名称
    /// </summary>
    FieldName: string;

    /// <summary>
    /// 字段类型
    /// </summary>
    FieldType: string;

    /// <summary>
    /// 字段标题
    /// </summary>
    FieldTitle: string;

    /// <summary>
    /// 字段排序
    /// </summary>
    FieldOrderBy: number;

    /// <summary>
    /// 字段所占宽度
    /// </summary>
    FieldWidth: number;

    /// <summary>
    /// 字段排序方式（desc、asc）为空不排序
    /// </summary>
    FieldSort: string;

    /// <summary>
    /// 自定义插槽
    /// </summary>
    FieldCustomSlot: string;

    /// <summary>
    /// 字段对齐方式（left right center）
    /// </summary>
    FieldAlign: string;

    /// <summary>
    /// 字段列固定（left right）
    /// </summary>
    FieldFixed: string;

    /// <summary>
    /// 字段所占最小宽度
    /// </summary>
    FieldMinWidth: number;

    /// <summary>
    /// 字段过长是否隐藏
    /// </summary>
    FieldEllipsisTooltip: boolean;

    //是否系统数据 1:是 2：否
    IsSystemData:number;

    /// <summary>
    /// 字段过长是否隐藏
    /// </summary>
    FieldEllipsisTooltips: number;
    
    ///1:属于数据行权限字段 2:不属于数据行权限字段
    DataRowAuthType:number;

    ///数据行权限字段（必须和查询表中的字段对应）
    DataRowAuthField:string;

    ///数据行权限字段
    DataRowAuthFieldName:string;

    /// <summary>
    /// 创建时间
    /// </summary>
    //CreateTime :Date;

    /// <summary>
    /// 创建人员
    /// </summary>
    // CreateUser:string;
}

//字段排序方式
export const fieldSortList = [
    {
        key: '',
        value: '不排序'
    },
    {
        key: 'desc',
        value: '倒序'
    },
    {
        key: 'asc',
        value: '正序'
    }
]

//字段对齐方式
export const fieldAlignList = [
    {
        key: '',
        value: '无'
    },
    {
        key: 'left',
        value: '左对齐'
    },
    {
        key: 'right',
        value: '右对齐'
    },
    {
        key: 'center',
        value: '居中对齐'
    }
]

//字段列固定
export const fieldFixedList = [
    {
        key: '',
        value: '不固定'
    },
    {
        key: 'left',
        value: '左固定'
    },
    {
        key: 'right',
        value: '右固定'
    }
]