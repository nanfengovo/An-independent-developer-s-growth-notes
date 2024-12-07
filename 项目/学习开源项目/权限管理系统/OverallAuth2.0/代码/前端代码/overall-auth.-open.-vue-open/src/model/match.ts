import { LayuiSelectModel } from "../model/publicModel"
export const matchingGroup = [
    {
        label: '且',
        value: 'And',
        disabled: false
    },
    {
        label: '或',
        value: 'Or',
        disabled: false
    }
]

//layui Select扩展模型
//数据行权限
export interface LayuiSelectRowAuthExtend extends LayuiSelectModel {

    /// <summary>
    /// 等式结果显示控件格式
    /// </summary>
    showControl: number;

    /// <summary>
    /// 等式结果显示控件数据源
    /// </summary>
    showControlDataSource: string;

    /// <summary>
    /// 条件等式下拉值
    /// </summary>
    conditionalEquationList: LayuiSelectModel[];

    /// <summary>
    /// 等式结果下拉框值
    /// </summary>
    conditionalEquationValueList: LayuiSelectModel[];
}

