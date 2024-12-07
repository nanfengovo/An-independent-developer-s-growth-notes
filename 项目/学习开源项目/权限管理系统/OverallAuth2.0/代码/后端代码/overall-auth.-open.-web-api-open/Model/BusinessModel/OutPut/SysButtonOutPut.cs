using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{
    /// <summary>
    /// 按钮输出类
    /// </summary>
    public class SysButtonOutPut
    {
        /// <summary>
        /// 选中按钮（该角色对应菜单拥有的权限）
        /// </summary>
        public Array SelectedKeys { get; set; }

        /// <summary>
        /// 按钮集合
        /// </summary>
        public List<SysButtonDataOutPut> SysButtonData { get; set; }
    }

}
