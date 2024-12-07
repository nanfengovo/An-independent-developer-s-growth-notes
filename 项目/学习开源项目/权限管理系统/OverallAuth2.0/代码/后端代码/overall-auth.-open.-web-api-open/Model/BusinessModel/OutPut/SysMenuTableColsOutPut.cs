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
    public class SysMenuTableColsOutPut
    {
        /// <summary>
        /// 选中列（该角色对应菜单拥有的权限）
        /// </summary>
        public Array SelectedKeys { get; set; }

        /// <summary>
        /// 列集合
        /// </summary>
        public List<SysMenuTableColsDataOutPut> SysMenuTableColsData { get; set; }
    }
}
