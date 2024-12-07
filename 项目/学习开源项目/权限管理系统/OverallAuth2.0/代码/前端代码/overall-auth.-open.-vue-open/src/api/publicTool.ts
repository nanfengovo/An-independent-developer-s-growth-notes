import { Ref, ref } from 'vue';
import Http from '../api/http';
import { layer } from '@layui/layui-vue';
import { LayuiSelectModel } from '../model/publicModel';


//获取地址栏参数
export const GetParamUrl = function (name: string) {
  return (
    decodeURIComponent(
      (new RegExp("[?|&]" + name + "=" + "([^&;]+?)(&|#|;|$)").exec(
        location.href
      ) || [, ""])[1].replace(/\+/g, "%20")
    ) || ""
  );
};

//根据菜单id获取登陆人员菜单数据列
const GetTableColsRoleByMenuId = function (params?: { menuId: number; }) {
  return Http.get('/api/SysMenuTableColsRole/GetTableColsRoleByMenuId', params);
}

//根据菜单id获取对应数据列
export const GetMenuColsByMenuId = async function () {
  let data = await GetMenuCols();
  return data.value;
}

//获取菜单数据列
async function GetMenuCols() {
  const columns: Ref<SysMenuTableColsDataOutPut[]> = ref([{ title: "选项", width: "55px", key: "", type: "checkbox", fixed: "left", sort: '', customSlot: '', align: '' }]);
  await GetTableColsRoleByMenuId({ menuId: parseInt(GetParamUrl("MneuId")) }).then(
    ({ data, code, msg }) => {
      if (code == 200) {
        data.forEach((element: { fieldTitle: string; fieldName: string; fieldWidth: string, fieldSort: string, fieldCustomSlot: string, fieldAlign: string, fieldFixed: string }) => {
          const model = ref<SysMenuTableColsDataOutPut>({
            key: '',
            title: '',
            width: '',
            fixed: undefined,
            sort: '',
            customSlot: '',
            align: ''
          });
          model.value.key = element.fieldName;
          model.value.title = element.fieldTitle;
          if (element.fieldWidth != null && element.fieldWidth != "")
            model.value.width = element.fieldWidth + "px";
          if (element.fieldSort != null && element.fieldSort != "")
            model.value.sort = element.fieldSort;
          if (element.fieldCustomSlot != null && element.fieldCustomSlot != "")
            model.value.customSlot = element.fieldCustomSlot;
          if (element.fieldAlign != null && element.fieldAlign != "")
            model.value.align = element.fieldAlign;
          if (element.fieldFixed != null && element.fieldFixed != "")
            model.value.fixed = element.fieldFixed;
          columns.value.push(model.value);
        });
      } else {
        layer.confirm(msg, { icon: 2, title: "获取菜单数据列错误" });
      }
    }
  )
  return columns;
}

//菜单列模型
export interface SysMenuTableColsDataOutPut {
  key: string;
  title: string;
  width: string;
  fixed: string | undefined;
  sort: string;
  customSlot: string;
  align: string;
}

//公式匹配模型
export interface matchingData {

  id: string;
  // 父级id
  pid: string;
  //匹配组（and,or） 
  matchGroup: string;
  //层级
  level: number;
  //匹配条件
  matchingWhere: matchingWhereData[];
  //子集
  children: matchingData[];
}

//匹配条件模型
export interface matchingWhereData {
  //主键
  id: string;
  //字段key（选中的字段）
  fieldKey: string;
  //符号key（选中的符号）
  matchSymbolKey: string;
  //字段对应匹配符
  matchSymbolOptions: LayuiSelectModel[] | undefined,
  //等式结果显示控件格式
  showControl: showControlEnum | undefined;
  //匹配数据（等式结果集）
  matchData: LayuiSelectModel[] | undefined;
  //匹配数据key（选中的等式结果--单值）
  matchDataKey: string ;
  //匹配数据key（选中的等式结果--多值）
  matchDataKeys: string[] | undefined

}

export enum showControlEnum {

  /// <summary>
  /// 输入框
  /// </summary>
  Input = 1,

  /// <summary>
  /// 单选下拉框
  /// </summary>
  RadioSelect = 2,

  /// <summary>
  /// 多选下拉框
  /// </summary>
  MultipleSelect = 3,

  /// <summary>
  /// 树形下拉框
  /// </summary>
  TreeSelect = 4,

  /// <summary>
  /// 弹出层
  /// </summary>
  Layer = 5,

  //时间
  DateTimes=6,
}

export enum authTypeEnum
{
  //菜单权限
  menuAuth = 1,
  //列权限
  colsAuth = 2,
  //按钮权限
  buttonAuth = 3,
}
