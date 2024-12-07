<template>
  <div class="plandiv">
    <div v-for="item in pageList" :key="item.id" class="forDiv">
      <div
        class="groupDiv"
        :style="'margin-bottom: 10px;margin-left:' + item.level * 20 + 'px'"
      >
        <!-- 第一级 -->
        <div>
          <div class="groupBackColor">
            <lay-select
              v-model="item.matchGroup"
              :options="matchingGroup"
              placeholder="请选择"
              style="float: left; margin-right: 10px; margin-left: 10px"
            ></lay-select>
            <lay-button
              border="green"
              size="xs"
              prefix-icon="layui-icon-template-one"
              @click="addGroup(item)"
              >新增组</lay-button
            >
            <lay-button
              border="blue"
              size="xs"
              prefix-icon="layui-icon-file-b"
              @click="addItem(item)"
              >新增项</lay-button
            >
          </div>
          <div
            class="itemBackColor"
            v-for="whereItem in item.matchingWhere"
            :key="whereItem.fieldKey"
          >
            <!--字段-->
            <lay-select
              class="itemStyle"
              :options="configList"
              v-model="whereItem.fieldKey"
              placeholder="请选择"
              @change="fieldChange(whereItem)"
            >
            </lay-select>
            <!--等式符号-->
            <lay-select
              class="itemStyle"
              :options="
                configList.length > 0 && whereItem.fieldKey !== ''
                  ? configList.filter((f) => f.value == whereItem.fieldKey)[0]
                      .conditionalEquationList
                  : whereItem.matchSymbolOptions
              "
              v-model="whereItem.matchSymbolKey"
              placeholder="请选择"
            >
            </lay-select>
            <!--等式结果-->
            <!--输入框-->
            <span v-if="whereItem.showControl === showControlEnum.Input">
              <lay-input
                class="reslutShowControl"
                v-model="whereItem.matchDataKey"
                placeholder="请输入"
              ></lay-input>
            </span>
            <!--单选下拉框-->
            <div v-if="whereItem.showControl === showControlEnum.RadioSelect">
              <lay-select
                class="reslutShowControl"
                :options="whereItem.matchData"
                v-model="whereItem.matchDataKey"
                placeholder="请选择"
              >
              </lay-select>
            </div>
            <!--多选下拉框-->
            <div
              v-if="whereItem.showControl === showControlEnum.MultipleSelect"
            >
              <lay-select
                class="reslutShowControl"
                :multiple="true"
                :options="whereItem.matchData"
                :minCollapsedNum="2"
                v-model="whereItem.matchDataKeys"
                placeholder="请选择"
              >
              </lay-select>
            </div>
            <!--树形下拉框-->
            <span v-if="whereItem.showControl === showControlEnum.TreeSelect">
            </span>
            <!--弹出层-->
            <span v-if="whereItem.showControl === showControlEnum.Layer">
            </span>
            <!--时间-->
            <span v-if="whereItem.showControl === showControlEnum.DateTimes">
              <div class="reslutShowControl">
                <lay-date-picker
                  style="width: 100%"
                  v-model="whereItem.matchDataKey"
                ></lay-date-picker>
              </div>
            </span>

            <div style="line-height: 36px">
              <lay-button
                style="margin-left: 35px"
                border="red"
                size="xs"
                prefix-icon="layui-icon-delete"
                @click="deleteItem(whereItem, item)"
                >删除项</lay-button
              >
            </div>
          </div>
        </div>

        <!-- 第二级 -->
        <div
          v-for="childrenItem in item.children"
          class="groupDiv"
          :key="childrenItem.id"
          :style="'margin-bottom: 10px;margin-left:' + item.level * 20 + 'px'"
        >
          <div class="groupBackColor">
            <lay-select
              v-model="childrenItem.matchGroup"
              :options="matchingGroup"
              placeholder="请选择"
              style="float: left; margin-right: 10px; margin-left: 10px"
            ></lay-select>
            <lay-button
              border="green"
              size="xs"
              prefix-icon="layui-icon-template-one"
              @click="addGroup(childrenItem)"
              >新增组</lay-button
            >
            <lay-button
              border="blue"
              size="xs"
              prefix-icon="layui-icon-file-b"
              @click="addItem(childrenItem)"
              >新增项</lay-button
            >
            <lay-button
              border="red"
              size="xs"
              prefix-icon="layui-icon-delete"
              @click="deleteGroup(childrenItem, item)"
              >删除组</lay-button
            >
          </div>
          <div
            class="itemBackColor"
            v-for="whereItem in childrenItem.matchingWhere"
            :key="whereItem.id"
          >
            <!--字段-->
            <lay-select
              class="itemStyle"
              :options="configList"
              v-model="whereItem.fieldKey"
              placeholder="请选择"
              @change="fieldChange(whereItem)"
            >
            </lay-select>
            <!--等式符号-->
            <lay-select
              class="itemStyle"
              :options="
                configList.length > 0 && whereItem.fieldKey !== ''
                  ? configList.filter((f) => f.value == whereItem.fieldKey)[0]
                      .conditionalEquationList
                  : whereItem.matchSymbolOptions
              "
              v-model="whereItem.matchSymbolKey"
              placeholder="请选择"
            >
            </lay-select>
            <!--等式结果-->
            <!--输入框-->
            <span v-if="whereItem.showControl === showControlEnum.Input">
              <lay-input
                class="reslutShowControl"
                v-model="whereItem.matchDataKey"
                placeholder="请输入"
              ></lay-input>
            </span>
            <!--单选下拉框-->
            <div v-if="whereItem.showControl === showControlEnum.RadioSelect">
              <lay-select
                class="reslutShowControl"
                :options="whereItem.matchData"
                v-model="whereItem.matchDataKey"
                placeholder="请选择"
              >
              </lay-select>
            </div>
            <!--多选下拉框-->
            <div
              v-if="whereItem.showControl === showControlEnum.MultipleSelect"
            >
              <lay-select
                class="reslutShowControl"
                :multiple="true"
                :options="whereItem.matchData"
                :minCollapsedNum="2"
                v-model="whereItem.matchDataKeys"
                placeholder="请选择"
              >
              </lay-select>
            </div>
            <!--树形下拉框-->
            <span v-if="whereItem.showControl === showControlEnum.TreeSelect">
            </span>
            <!--弹出层-->
            <span v-if="whereItem.showControl === showControlEnum.Layer">
            </span>
            <!--时间-->
            <span v-if="whereItem.showControl === showControlEnum.DateTimes">
              <div class="reslutShowControl">
                <lay-date-picker
                  style="width: 100%"
                  v-model="whereItem.matchDataKey"
                ></lay-date-picker>
              </div>
            </span>
            <div style="line-height: 36px">
              <lay-button
                style="margin-left: 35px"
                border="red"
                size="xs"
                prefix-icon="layui-icon-delete"
                @click="deleteItem(whereItem, childrenItem)"
                >删除项</lay-button
              >
            </div>
          </div>

          <!-- 第三级 -->
          <div
            v-for="childrenItem2 in childrenItem.children"
            class="groupDiv"
            :key="childrenItem2.id"
            :style="'margin-bottom: 10px;margin-left:' + item.level * 20 + 'px'"
          >
            <div class="groupBackColor">
              <lay-select
                v-model="childrenItem2.matchGroup"
                :options="matchingGroup"
                placeholder="请选择"
                style="float: left; margin-right: 10px; margin-left: 10px"
              ></lay-select>
              <lay-button
                border="green"
                size="xs"
                prefix-icon="layui-icon-template-one"
                @click="addGroup(childrenItem2)"
                >新增组</lay-button
              >
              <lay-button
                border="blue"
                size="xs"
                prefix-icon="layui-icon-file-b"
                @click="addItem(childrenItem2)"
                >新增项</lay-button
              >
              <lay-button
                border="red"
                size="xs"
                prefix-icon="layui-icon-delete"
                @click="deleteGroup(childrenItem2, childrenItem)"
                >删除组</lay-button
              >
            </div>
            <div
              class="itemBackColor"
              v-for="whereItem in childrenItem2.matchingWhere"
              :key="whereItem.id"
            >
              <!--字段-->
              <lay-select
                class="itemStyle"
                :options="configList"
                v-model="whereItem.fieldKey"
                placeholder="请选择"
                @change="fieldChange(whereItem)"
              >
              </lay-select>
              <!--等式符号-->
              <lay-select
                class="itemStyle"
                :options="
                  configList.length > 0 && whereItem.fieldKey !== ''
                    ? configList.filter((f) => f.value == whereItem.fieldKey)[0]
                        .conditionalEquationList
                    : whereItem.matchSymbolOptions
                "
                v-model="whereItem.matchSymbolKey"
                placeholder="请选择"
              >
              </lay-select>
              <!--等式结果-->
              <!--输入框-->
              <span v-if="whereItem.showControl === showControlEnum.Input">
                <lay-input
                  class="reslutShowControl"
                  v-model="whereItem.matchDataKey"
                  placeholder="请输入"
                ></lay-input>
              </span>
              <!--单选下拉框-->
              <div v-if="whereItem.showControl === showControlEnum.RadioSelect">
                <lay-select
                  class="reslutShowControl"
                  :options="whereItem.matchData"
                  v-model="whereItem.matchDataKey"
                  placeholder="请选择"
                >
                </lay-select>
              </div>
              <!--多选下拉框-->
              <div
                v-if="whereItem.showControl === showControlEnum.MultipleSelect"
              >
                <lay-select
                  class="reslutShowControl"
                  :multiple="true"
                  :options="whereItem.matchData"
                  :minCollapsedNum="2"
                  v-model="whereItem.matchDataKeys"
                  placeholder="请选择"
                >
                </lay-select>
              </div>
              <!--树形下拉框-->
              <span v-if="whereItem.showControl === showControlEnum.TreeSelect">
              </span>
              <!--弹出层-->
              <span v-if="whereItem.showControl === showControlEnum.Layer">
              </span>
              <!--时间-->
              <span v-if="whereItem.showControl === showControlEnum.DateTimes">
                <div class="reslutShowControl">
                  <lay-date-picker
                    style="width: 100%"
                    v-model="whereItem.matchDataKey"
                  ></lay-date-picker>
                </div>
              </span>
              <div style="line-height: 36px">
                <lay-button
                  style="margin-left: 35px"
                  border="red"
                  size="xs"
                  prefix-icon="layui-icon-delete"
                  @click="deleteItem(whereItem, childrenItem2)"
                  >删除项</lay-button
                >
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div style="margin-top: 10px; margin-right: 20px; margin-left: 20px">
      <lay-textarea placeholder="规则备注" v-model="ruleRemark"> </lay-textarea>
    </div>
    <div style="margin-top: 10px; margin-right: 20px; float: right">
      <!-- <lay-button
        type="primary"
        @click="previewRuleClick"
        prefix-icon="layui-icon-read"
        >预览规则</lay-button
      > -->
      <lay-button
        type="normal"
        @click="saveRuleClick"
        prefix-icon="layui-icon-add-circle-fine"
        >保存规则</lay-button
      >
    </div>
  </div>
</template>
<script lang="ts">
import { ref, reactive, onMounted, h, defineComponent, PropType } from "vue";
import { layer } from "@layui/layui-vue";
import { LayuiSelectRowAuthExtend, matchingGroup } from "../../model/match";
import { plus } from "number-precision";
import {
  matchingData,
  matchingWhereData,
  showControlEnum,
} from "../../api/publicTool";
import { GetTableRowAuthConfigByMenuId } from "../../api/authority/tableRow";
import { NumberOrString } from "@layui/layui-vue/types/types";
import { StringOrNumber } from "@layui/layui-vue/types/component/tree/tree.type";
import { LayuiSelectModel } from "../../model/publicModel";
export default defineComponent({
  props: {
    menuId: {
      type: Object as PropType<NumberOrString>,
      required: true,
    },
    ruleJson: {
      type: Object as PropType<matchingData[]>,
      required: true,
    },
    ruleRemark: {
      type: Object as PropType<string>,
      required: true,
    },
  },
  setup(props, context) {
    //初始化数据
    onMounted(() => {
      GetTableRowAuthConfig();
    });
    const menuId = props.menuId;
    const ruleJson = props.ruleJson;
    const configList = ref<LayuiSelectRowAuthExtend[]>([]);
    const conditionalEquationList = ref<LayuiSelectModel[]>();
    const fieldValue = ref<StringOrNumber>();
    const ruleRemark = ref<string>(props.ruleRemark);
    const endTime = ref(null);
    //最多组
    const maxGroup = ref<number>(5);
    //最多层级
    const maxLevel = ref<number>(3);
    //最多条件
    const maxWhere = ref<number>(10);
    const matchingGroupValue = ref("And");

    //获取数据行权限配置
    const GetTableRowAuthConfig = () => {
      configList.value = [];
      if (menuId > 0) {
        GetTableRowAuthConfigByMenuId({ menuId: menuId }).then(
          ({ data, code, msg }) => {
            if (code == 200) {
              configList.value = data;
            } else {
              layer.confirm(msg, { icon: 2, title: "错误消息" });
            }
          }
        );
      }
    };

    const pageList = ref<matchingData[]>(ruleJson);
    if (pageList.value == undefined) {
      pageList.value = [
        {
          id: "1",
          pid: "0",
          matchGroup: "And",
          level: 1,
          matchingWhere: [],
          children: [],
        },
      ];
      // pageList = ref<matchingData[]>();
    }

    // 添加组事件
    const addGroup = function (item: matchingData) {
      //获取当前组的所有数据
      var listFilter = pageList.value.filter((f) => f.id.includes(item.id));
      //获取当前组的长度
      var listGroupLength = item.children.length;

      //添加前验证最多添加多少层级
      if (item.level >= maxLevel.value) {
        layer.msg("最多添加" + maxLevel.value + "级");
        return;
      }
      //添加前验证能添加多少组
      if (listGroupLength >= maxGroup.value) {
        layer.msg("每层下最多添加" + maxGroup.value + "个组");
        return;
      }

      //组织要添加节点的数据
      var groupId = item.id + "-" + (listGroupLength + 1);
      var groupPid = item.id;
      var groupLevel = item.level + 1;

      //找到对应的下标
      const index = pageList.value.findIndex((s) => {
        if (s.id === item.id) {
          return true;
        }
      });

      //精确插入当前节点及插入位置
      var indexLength = listGroupLength + 1;
      item.children.splice(plus(...[index, indexLength]), 0, {
        id: groupId,
        pid: groupPid,
        matchGroup: "Or",
        level: groupLevel,
        matchingWhere: [],
        children: [],
      });
    };

    //添加项事件
    const addItem = function (item: matchingData) {
      if (item.matchingWhere.length > maxWhere.value) {
        layer.msg("每层下最多添加" + maxWhere.value + "组条件");
        return;
      }
      item.matchingWhere.push({
        id: randamId().toString(),
        fieldKey: "",
        matchSymbolKey: "",
        matchSymbolOptions: [],
        showControl: showControlEnum.Input,
        matchData: [],
        matchDataKey: "",
        matchDataKeys: [],
      });
    };

    // 删除组
    const deleteGroup = function (item: matchingData, group: matchingData) {
      layer.msg(item.id);
      GetGroupSpliceIndex(item.id, group.children);
    };

    //递归删除组
    const GetGroupSpliceIndex = (id: string, list: matchingData[]) => {
      //找到删除数据下标
      const index = list.findIndex((p: { id: string }) => {
        if (p.id === id) {
          return true;
        }
      });
      if (index === -1) GetGroupSpliceIndex(id, list[0].children);
      list.forEach((f: { id: string }) => {
        if (f.id == id) {
          list.splice(index, 1);
          if (list.length == 0) {
            //删除组
          }
        }
      });
    };

    // 删除项
    const deleteItem = function (item: matchingWhereData, data: matchingData) {
      GetItemSpliceIndex(item.id, data);
    };

    //递归删除项
    const GetItemSpliceIndex = (id: string, list: any) => {
      //找到删除数据下标
      const index = list.matchingWhere.findIndex((p: { id: string }) => {
        if (p.id === id) {
          return true;
        }
      });
      if (index === -1) GetItemSpliceIndex(id, list.children);
      list.matchingWhere.forEach((f: { id: string }) => {
        if (f.id == id) {
          list.matchingWhere.splice(index, 1);
          //删除组,不能删除第一级的组
          // if (list.matchingWhere.length == 0) {
          //   var parentGroup = pageList.value.filter((s) => s.id == list.pid);
          //   if (parentGroup.length == 0) {
          //     var dddd = GetParentGroup(list.pid, pageList.value[0].children);
          //     GetGroupSpliceIndex(list.id, dddd);
          //   } else GetGroupSpliceIndex(list.id, parentGroup);
          // }
        }
      });
    };

    const GetParentGroup = (pid: string, list: matchingData[]) => {
      var parentGroup = list.filter((f: { id: string }) => f.id == pid);
      if (parentGroup.length == 0) GetParentGroup(pid, list[0].children);
      else return parentGroup;
    };

    /* 生成随机不重复id */
    const randamId = () => {
      let n = 1;
      let arr = [];
      for (let i = 0; i < n; i++) {
        arr[i] = parseInt((Math.random() * 10000000000).toString());
      }
      for (let i = 0; i < n; i++) {
        for (let j = i + 1; j < n; j++) {
          if (arr[i] === arr[j]) {
            randamId();
            return false;
          }
        }
      }
      return arr.toString();
    };

    //字段
    const fieldChange = (whereItem: matchingWhereData) => {
      const model = configList.value.find(
        (f) => f.value === whereItem.fieldKey
      );
      whereItem.matchSymbolOptions = model?.conditionalEquationList;
      whereItem.matchData = model?.conditionalEquationValueList;
      whereItem.showControl = model?.showControl;
      whereItem.matchDataKey = "";
      whereItem.matchDataKeys = undefined;
    };

    //预览规则事件
    const previewRuleClick = function () {
      context.emit("Key1", pageList.value);
    };
    //保存规则事件
    const saveRuleClick = function () {
      context.emit("Key2", pageList.value, ruleRemark);
    };
    return {
      pageList,
      configList,
      matchingGroup,
      matchingGroupValue,
      addGroup,
      addItem,
      deleteGroup,
      deleteItem,
      fieldValue,
      fieldChange,
      conditionalEquationList,
      showControlEnum,
      previewRuleClick,
      saveRuleClick,
      endTime,
      ruleRemark,
    };
  },

  components: {},
});
</script>

<style  lang="less" scoped>
/* 最外层样式 */
.plandiv {
  background-color: white;
  height: auto;
}

/* 分组样式 */
.groupDiv {
  border: 1px solid #e7dfdf;
  width: auto;
  height: auto;
  // line-height: 50px;
  margin-top: 5px;
  margin-right: 20px;
  /* width: 60%;
  padding-right: 10px; */
}

/* 循环层样式 */
.forDiv {
  /* border: 1px solid #e7dfdf; */
  margin-top: 10px;
  overflow-y: auto;
  max-height: 700px;
}

/* 组条件背景色 */
.groupBackColor {
  background-color: #e9dcef;
  height: 50px;
  line-height: 50px;
}

/* 项背景色 */
.itemBackColor {
  /* background-color: #d9d4d4; */
  height: 46px;
  display: -webkit-box;
  margin-top: 5px;
}

/* 项样式 */
.itemStyle {
  margin-left: 20px;
  //width: 250px;
  width: 25%;
}
/* 结果控件样式 */
.reslutShowControl {
  margin-left: 20px;
  //width: 250px;
  width: 100%;
}
</style>