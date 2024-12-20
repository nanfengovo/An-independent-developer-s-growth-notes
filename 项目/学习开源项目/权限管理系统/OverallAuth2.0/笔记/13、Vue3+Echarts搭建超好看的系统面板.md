**实现功能**

　　1、系统登录后的可视化面板页面

　　原本不想写这篇文章，因为它和我们的系统权限、框架没有实质性的关系，但耐不住群友的软磨硬泡，便答应了下来。

　　我起初的设想，这块功能直接上传到码云上，群友可以根据自己搭建的系统，酌情修改。

**安装echarts**

　　npm install echarts --save

**搭建面板页面**

在panel文件夹，打开index页面，编写布局代码

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

<template>
  <div style="display: flex; height: 1080px">
    <div style="width: 80%">
      <div
        style="height: 25%; display: flex; margin-bottom: 5px"
        class="boxStyle"
      >
        <div style="width: 50%" class="boxStyle">
        </div>
        <div
          style="width: 50%; margin-left: 5px;"
          class="boxStyle"
        >
         2
        </div>
      </div>
      <div style="height: 45% ;margin-bottom: 5px"  class="boxStyle">
       3
      </div>
      <div style="height: 28%" class="boxStyle">
        4
      </div>
    </div>
    <div
      style="width: 20%; margin-left: 5px; display: flow-root"
      class="panelContent boxStyle"
    >
      <div
        style="width: 100%; height: 50%; margin-bottom: 5px"
        class="boxStyle"
      >
        特色功能
      </div>
      <div style="width: 100%; height: 50%" class="boxStyle">关于作者</div>
    </div>
  </div>
</template>
<script  lang="ts" >
import * as echarts from "echarts";
import { defineComponent } from "vue";
export default defineComponent({
  props: {
    // openPageData: {
    //   type: Object as PropType<buttonModel>,
    //   required: true,
    // },
  },

  setup(props, context) {  
    
    return {};
  },
  components: {},
});
</script>
<style scoped>
.panelContent {
  font-size: 12px;
  justify-content: right;
  align-items: center;
}
.boxStyle {
  border: 1px solid #00152914;
  box-shadow: 0 1px 4px #00152914;
}
</style>

    

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

布局样式如下

![](https://img2024.cnblogs.com/blog/1158526/202411/1158526-20241130142251990-161314775.png)

**填充盒子1的内容**

在api文件夹下，创建一个文件夹panel，然后再该文件夹下创建一个echarts.ts的文件，编写如下代码

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

export const echartsOne = {
    title: {
      text: "系统六芒星图",
    },
    color: ['#67F9D8'],
    //backgroundColor: "#013954",  //背景样式
    radar: {
      // 雷达图的指示器，表示多个变量的标签
      indicator: [
        { name: "好用", max: 5 },
        { name: "易懂", max: 5 },
        { name: "简单", max: 5 },
        { name: "通用", max: 5 },
        { name: "灵活", max: 5 },
        { name: "学习", max: 5 },
      ],
      splitArea: {
        areaStyle: {
          color: ['#adbecf','#77EADF', '#26C3BE', '#64AFE9', '#428BD4','#2177cd'],
          shadowColor: 'rgba(0, 0, 0, 0.2)',
          shadowBlur: 10
        }
      },
      axisName: {
        formatter: '【{value}】',
        color: '#428BD4'
      },
    },
    series: [
      {
        type: "radar",
        // 雷达图的数据
        data: [
          {
            value: [5, 5, 5, 5, 5, 5],
          },
        ],
      },
    ],
  };

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

该代码是echarts的雷达图代码。

回到页面，我们把盒子1里的内容替换成

 　　<div id="echarts-one" style="width: 100%; height: 100%"></div>

然后再setup下添加如下代码

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

  onMounted(() => {
      GetEchartsOneData();
    });
    function GetEchartsOneData() {
      var myChart = echarts.init(document.getElementById("echarts-one"));
      myChart.setOption(echartsOne);
    }

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

注意这里的onMounted钩子函数需要添加引用，echartsOne也需要导入。点击vue的提示即可。

完成以上代码，我们预览看下效果

![](https://img2024.cnblogs.com/blog/1158526/202411/1158526-20241130150228755-276207.png)

照葫芦画瓢，我们开始编写盒子2、3、4的内容

在echarts.ts中添加

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

//南丁格尔玫瑰图
export const echartsTWO = {
    title: {
        text: "模块访问占比",
    },
    toolbox: {
        show: true,
    },
    legend: {
        bottom: "10",
    },
    // backgroundColor: "#013954",  //背景样式
    series: [
        {
            name: "Nightingale Chart",
            type: "pie",
            radius: [25, 80],
            center: ["50%", "50%"],
            roseType: "area",
            // itemStyle: {
            //   borderRadius: 8,
            // },
            data: [
                { value: 40, name: "菜单权限" },
                { value: 38, name: "角色权限" },
                { value: 32, name: "列权限" },
                { value: 30, name: "行权限" },
                { value: 28, name: "按钮权限" },
                { value: 18, name: "接口权限" },
                { value: 26, name: "流程" },
                { value: 22, name: "表单" },
            ],
        },
    ],
};

//中国地图
export const chinaGeoCoordMap = ref<any>({
    黑龙江: [127.9688, 45.368],
    内蒙古: [110.3467, 41.4899],
    吉林: [125.8154, 44.2584],
    北京市: [116.4551, 40.2539],
    辽宁: [123.1238, 42.1216],
    河北: [114.4995, 38.1006],
    天津: [117.4219, 39.4189],
    山西: [112.3352, 37.9413],
    陕西: [109.1162, 34.2004],
    甘肃: [103.5901, 36.3043],
    宁夏: [106.3586, 38.1775],
    青海: [101.4038, 36.8207],
    新疆: [87.9236, 43.5883],
    西藏: [91.11, 29.97],
    四川: [103.9526, 30.7617],
    重庆: [108.384366, 30.439702],
    山东: [117.1582, 36.8701],
    河南: [113.4668, 34.6234],
    江苏: [118.8062, 31.9208],
    安徽: [117.29, 32.0581],
    湖北: [114.3896, 30.6628],
    浙江: [119.5313, 29.8773],
    福建: [119.4543, 25.9222],
    江西: [116.0046, 28.6633],
    湖南: [113.0823, 28.2568],
    贵州: [106.6992, 26.7682],
    云南: [102.9199, 25.4663],
    广东: [113.12244, 23.009505],
    广西: [108.479, 23.1152],
    海南: [110.3893, 19.8516],
    上海: [121.4648, 31.2891],
});
export const chinaDatas = [
    [
        {
            name: "黑龙江",
            value: 0,
        },
    ],
    [
        {
            name: "内蒙古",
            value: 0,
        },
    ],
    [
        {
            name: "吉林",
            value: 0,
        },
    ],
    [
        {
            name: "辽宁",
            value: 0,
        },
    ],
    [
        {
            name: "河北",
            value: 0,
        },
    ],
    [
        {
            name: "天津",
            value: 0,
        },
    ],
    [
        {
            name: "山西",
            value: 0,
        },
    ],
    [
        {
            name: "陕西",
            value: 0,
        },
    ],
    [
        {
            name: "甘肃",
            value: 0,
        },
    ],
    [
        {
            name: "宁夏",
            value: 0,
        },
    ],
    [
        {
            name: "青海",
            value: 0,
        },
    ],
    [
        {
            name: "新疆",
            value: 0,
        },
    ],
    [
        {
            name: "西藏",
            value: 0,
        },
    ],
    [
        {
            name: "四川",
            value: 0,
        },
    ],
    [
        {
            name: "重庆",
            value: 0,
        },
    ],
    [
        {
            name: "山东",
            value: 0,
        },
    ],
    [
        {
            name: "河南",
            value: 0,
        },
    ],
    [
        {
            name: "江苏",
            value: 0,
        },
    ],
    [
        {
            name: "安徽",
            value: 0,
        },
    ],
    [
        {
            name: "湖北",
            value: 0,
        },
    ],
    [
        {
            name: "浙江",
            value: 0,
        },
    ],
    [
        {
            name: "福建",
            value: 0,
        },
    ],
    [
        {
            name: "江西",
            value: 0,
        },
    ],
    [
        {
            name: "湖南",
            value: 0,
        },
    ],
    [
        {
            name: "贵州",
            value: 0,
        },
    ],
    [
        {
            name: "广西",
            value: 0,
        },
    ],
    [
        {
            name: "海南",
            value: 0,
        },
    ],
    [
        {
            name: "上海",
            value: 1,
        },
    ],
];
var convertData = function (data: string | any[]) {
    var res = [];
    for (var i = 0; i < data.length; i++) {
        var dataItem = data[i];
        var fromCoord = chinaGeoCoordMap.value[dataItem[0].name];
        var toCoord = [103.9526, 30.7617];
        if (fromCoord && toCoord) {
            res.push([
                {
                    coord: fromCoord,
                    value: dataItem[0].value,
                },
                {
                    coord: toCoord,
                },
            ]);
        }
    }
    return res;
};
export const series: {
    type: string;
    zlevel: number;
    coordinateSystem: string;
    effect: {
        show: boolean;
        period: number; //箭头指向速度，值越小速度越快
        trailLength: number; //特效尾迹长度[0,1]值越大，尾迹越长重
        symbol: string; //箭头图标
        symbolSize: number;
        brushType: string;
        scale: number
    };
    rippleEffect:any;
    label: {},
    symbol: string;
    symbolSize: {},
    itemStyle: {},
    lineStyle: {
        normal: {
            width: number; //尾迹线条宽度
            opacity: number; //尾迹线条透明度
            curveness: number; //尾迹线条曲直度
        };
    };
    data: any
}[] = [];
[["四川", chinaDatas as any]].forEach(function (item, i) {
    series.push(
        {
            type: "lines",
            coordinateSystem: "geo",
            zlevel: 2,
            rippleEffect:[],
            effect: {
                show: true,
                period: 4, //箭头指向速度，值越小速度越快
                trailLength: 0.02, //特效尾迹长度[0,1]值越大，尾迹越长重
                symbol: "arrow", //箭头图标
                symbolSize: 5, //图标大小
                brushType: "",
                scale: 0
            },
            label: [],
            symbol: "",
            symbolSize: [],
            itemStyle: [],
            lineStyle: {
                normal: {
                    width: 1, //尾迹线条宽度
                    opacity: 1, //尾迹线条透明度
                    curveness: 0.3, //尾迹线条曲直度
                },
            },
            data: convertData(item[1]),
        },
        {
            type: "effectScatter",
            coordinateSystem: "geo".toString(),
            zlevel: 2,
            effect:{} as any,
            rippleEffect: {
                //涟漪特效
                period: 4, //动画时间，值越小速度越快
                brushType: "stroke", //波纹绘制方式 stroke, fill
                scale: 4,
                show: false,
                trailLength: 0,
                symbol: "",
                symbolSize: 0
            },
            label: {
                normal: {
                    show: true,
                    position: "right", //显示位置
                    offset: [5, 0], //偏移设置
                    formatter: function (params: { data: { name: any } }) {
                        //圆环显示文字
                        return params.data.name;
                    },
                    fontSize: 13,
                },
                emphasis: {
                    show: true,
                },
            },
            symbol: "circle",
            symbolSize: function (val: number[]) {
                return 5 + val[2] * 5; //圆环大小
            },
            itemStyle: {
                normal: {
                    show: false,
                    color: "#f00",
                },
            },
            lineStyle: {
                normal: {
                    width: 1, //尾迹线条宽度
                    opacity: 1, //尾迹线条透明度
                    curveness: 0.3, //尾迹线条曲直度
                },
            },
            data: item[1].map(function (
                dataItem: {
                    name: any;
                    value: any;
                }[]
            ) {
                return {
                    name: dataItem[0].name,
                    value: chinaGeoCoordMap.value[dataItem[0].name].concat([dataItem[0].value]),
                };
            }),
        },
        //被攻击点
        {
            type: "scatter",
            coordinateSystem: "geo",
            zlevel: 2,
            rippleEffect:{} as any,
            effect: {
                period: 4,
                brushType: "stroke",
                scale: 4,
                show: false,
                trailLength: 0,
                symbol: "",
                symbolSize: 0
            },
            label: {
                normal: {
                    show: true,
                    position: "right",
                    //offset:[5, 0],
                    color: "#0f0",
                    formatter: "{b}",
                    textStyle: {
                        color: "#0f0",
                    },
                },
                emphasis: {
                    show: true,
                    color: "#f60",
                },
            },
            symbol: "pin",
            symbolSize: 50,
            itemStyle: [],
            lineStyle: '' as any,
            data: [
                {
                    name: item[0],
                    value: chinaGeoCoordMap.value[item[0].toString()].concat([10]),
                },
            ],
        }
    );
});
export const echartsThree = {
    title: {
        text: "各省访问数量",
    },
    tooltip: {
      trigger: "item",
      backgroundColor: "rgba(166, 200, 76, 0.82)",
      borderColor: "#FFFFCC",
      showDelay: 0,
      hideDelay: 0,
      enterable: true,
      transitionDuration: 0,
      extraCssText: "z-index:100",
      formatter: function (
        params: { name: any; value: { [x: string]: any }; seriesIndex: number },
        ticket: any,
        callback: any
      ) {
        //根据业务自己拓展要显示的内容
        var res = "";
        var name = params.name;
        var value = params.value[params.seriesIndex + 1];
        res =
          "<span style='color:#fff;'>" + name + "</span><br/>数据：" + value;
        return res;
      },
    },
    //backgroundColor: "#013954",
    visualMap: {
      //图例值控制
      min: 0,
      max: 1,
      calculable: true,
      show: true,
      color: ["#f44336", "#fc9700", "#ffde00", "#ffde00", "#00eaff"],
      textStyle: {
        color: "#fff",
      },
    },
    geo: {
      map: "china",
      zoom: 1.2,
      label: {
        emphasis: {
          show: false,
        },
      },
      roam: false, //是否允许缩放
      itemStyle: {
        normal: {
          color: "rgba(51, 69, 89, .5)", //地图背景色
          borderColor: "#516a89", //省市边界线00fcff 516a89
          borderWidth: 1,
        },
        emphasis: {
          color: "rgba(37, 43, 61, .5)", //悬浮背景
        },
      },
    },
    series: series,
  };

  //堆叠图
  export const echartsFour = {
    title: {
      text: "系统访问量走势图",
    },
   // backgroundColor: "#6a7985",  //背景样式
    tooltip: {
      trigger: "axis",
      axisPointer: {
        type: "cross",
        label: {
          backgroundColor: "#6a7985",
        },
      },
    },
    legend: {
      data: ["菜单权限", "角色权限", "按钮权限", "行权限", "列权限"],
    },
    toolbox: {
      // feature: {
      //   saveAsImage: {},
      // },
    },
    grid: {
      left: "3%",
      right: "4%",
      bottom: "3%",
      containLabel: true,
    },
    xAxis: [
      {
        type: "category",
        boundaryGap: false,
        data: ["星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期天"],
      },
    ],
    yAxis: [
      {
        type: "value",
      },
    ],
    series: [
      {
        name: "菜单权限",
        type: "line",
        stack: "Total",
        areaStyle: {},
        emphasis: {
          focus: "series",
        },
        data: [120, 132, 101, 134, 90, 230, 210],
      },
      {
        name: "角色权限",
        type: "line",
        stack: "Total",
        areaStyle: {},
        emphasis: {
          focus: "series",
        },
        data: [220, 182, 191, 234, 290, 330, 310],
      },
      {
        name: "按钮权限",
        type: "line",
        stack: "Total",
        areaStyle: {},
        emphasis: {
          focus: "series",
        },
        data: [150, 232, 201, 154, 190, 330, 410],
      },
      {
        name: "行权限",
        type: "line",
        stack: "Total",
        areaStyle: {},
        emphasis: {
          focus: "series",
        },
        data: [320, 332, 301, 334, 390, 330, 320],
      },
      {
        name: "列权限",
        type: "line",
        stack: "Total",
        label: {
          show: true,
          position: "top",
        },
        areaStyle: {},
        emphasis: {
          focus: "series",
        },
        data: [820, 932, 901, 934, 1290, 1330, 1320],
      },
    ],
  };

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

在页面添加

把盒子2所在的地方替换成<div id="echarts-tow" style="width: 100%; height: 100%"></div>

把盒子3所在的地方替换成<div id="echarts-three" style="width: 100%; height: 100%"></div>

把盒子4所在的地方替换成<div id="echarts-four" style="width: 100%; height: 100%"></div>

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

 onMounted(() => {
      GetEchartsOneData();
      GetEchartsTwoData();
      GetEchartsThreeData();
      GetEchartsFourData();
    });

    //六芒星图
    function GetEchartsOneData() {
      var myChart = echarts.init(document.getElementById("echarts-one"));
      myChart.setOption(echartsOne);
    }

    //南丁格尔玫瑰图
    function GetEchartsTwoData() {
      var myChart = echarts.init(document.getElementById("echarts-tow"));
      myChart.setOption(echartsTWO);
    }

    //中国地图
    function GetEchartsThreeData() {
      var myChart = echarts.init(document.getElementById("echarts-three"));
      echarts.registerMap("china", chinaJson as any); //注册可用的地图
      myChart.setOption(echartsThree);
    }

    //堆叠图
    function GetEchartsFourData() {
      var myChart = echarts.init(document.getElementById("echarts-four"));
      myChart.setOption(echartsFour);
    }

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

**特别注意**

　　1、在添加中国地图时，需要下载一个中国地图的json包，放在项目中（我是放在和echarts.ts同级目录下）。下载地址：https://datav.aliyun.com/portal/school/atlas/area_selector

　　2、在tsconfig.json文件中需要添加"resolveJsonModule": true,的配置，该配置可以让系统允许导入json。

**预览**

**![](https://img2024.cnblogs.com/blog/1158526/202412/1158526-20241202110301526-377678714.png)**

**兼容性调整**

　　对应echarts来说，每个图表，它是固定的，就算设置的是百分比，也不随着窗体的大小而自适应屏幕，如下图

![](https://img2024.cnblogs.com/blog/1158526/202412/1158526-20241202110627706-821347007.png)

要解决以上问题，我们只需要添加一个方法即可

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

 //图标兼容性调整
    function resizeEchart(myChart:any)
    {
      //监听窗口大小变化(适用于一个页面多个图形)
      window.addEventListener('resize',()=>{myChart.resize();})
    }

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

然后再_myChart.setOption()方法后面添加_resizeEchart(myChart);即可解决兼容性问题，如图

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

  //堆叠图
    function GetEchartsFourData() {
      var myChart = echarts.init(document.getElementById("echarts-four"));
      myChart.setOption(echartsFour);
      resizeEchart(myChart);
    }

![复制代码](https://assets.cnblogs.com/images/copycode.gif)

**结语**

