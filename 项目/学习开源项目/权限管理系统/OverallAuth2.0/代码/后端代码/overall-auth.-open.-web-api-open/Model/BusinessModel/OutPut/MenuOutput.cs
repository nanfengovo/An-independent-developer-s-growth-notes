using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{
    /// <summary>
    /// 菜单输出模型
    /// </summary>
    [EnitityMapping(MenuId = "5")]
    public class MenuOutput
    {
        /// <summary>
        /// 菜单id"
        /// </summary>
        [Description("菜单id")]
        public int Id { get; set; }

        /// <summary>
        /// 菜单路径
        /// </summary>
        [Description("菜单路径")]
        public string MenuUrl { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        [Description("菜单图标")]
        public string MenuIcon { get; set; }

        /// <summary>
        /// 菜单标题
        /// </summary>
        [Description("菜单标题")]
        public string MenuTitle { get; set; }

        /// <summary>
        /// 父级菜单id
        /// </summary>
        [Description("父级菜单id")]
        public int Pid { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Description("是否启用")]
        public bool IsOpen { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人id
        /// </summary>
        [Description("创建人id")]
        public string CreateUser { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        [Description("创建人姓名")]
        public string UserName { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        [Description("菜单地址")]
        public string Component { get; set; }

        /// <summary>
        /// 菜单路径
        /// </summary>
        [Description("菜单路径")]
        public string Path { get; set; }

        /// <summary>
        /// 是否验证
        /// </summary>
        [Description("是否验证")]
        public bool RequireAuth { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Description("名称")]
        public string Name { get; set; }

        /// <summary>
        /// 重定向
        /// </summary>
        [Description("重定向")]
        public string Redirect { get; set; }

        /// <summary>
        /// 子集
        /// </summary>
        [Description("子集")]
        public List<MenuOutput> Children { get; set; }
    }
}
