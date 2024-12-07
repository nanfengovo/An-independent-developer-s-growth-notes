using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{
    /// <summary>
    /// layui树
    /// </summary>
    public class LayuiTree
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 上级id
        /// </summary>
        public int Pid { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 子集
        /// </summary>
        public List<LayuiTree> Children { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 是否展开
        /// </summary>
        public bool Spread => true;

        /// <summary>
        /// 是否开启菜单
        /// </summary>
        public bool IsOpen { get; set; }
    }

    public class LayuiTreeModel 
    {
        /// <summary>
        /// 选择节点
        /// </summary>
        public Array CheckedKeys { get; set; }

        /// <summary>
        /// tree
        /// </summary>
        public List<LayuiTree> TreeItems { get; set; }
    }
}
