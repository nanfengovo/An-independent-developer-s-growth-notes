using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{

    /// <summary>
    /// 用户和角色模型
    /// </summary>
    [EnitityMapping(MenuId = "37")]
    public class UserOrRoleOutPut : LayuiTableOutPut
    {
        /// <summary>
        /// 用户id
        /// </summary>
        [Description("用户id")]
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Description("用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Description("密码")]
        public string Password { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Description("年龄")]
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Description("性别")]
        public string Sex { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        [Description("部门id")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// 角色id（多个以逗号隔开）
        /// </summary>
        [Description("角色id")]
        public string RoleId { get; set; }

        /// <summary>
        /// 角色名称（多个以逗号隔开）
        /// </summary>
        [Description("角色名称")]
        public string RoleName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人员
        /// </summary>
        [Description("创建人员id")]
        public string CreateUser { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        [Description("主键")]
        public override string Id { get { return UserId.ToString(); } }
    }
}
