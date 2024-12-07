using Model;
using Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// 按钮样式服务接口
    /// </summary>
    public interface ISysButtonStyleService
    {
        /// <summary>
        /// 新增按钮样式
        /// </summary>
        /// <param name="sysButtonStyle">模型</param>
        void Insert(SysButtonStyle sysButtonStyle);

        /// <summary>
        /// 修改按钮样式
        /// </summary>
        /// <param name="sysButtonStyle">模型</param>
        void Update(SysButtonStyle sysButtonStyle);

        /// <summary>
        /// 删除按钮样式
        /// </summary>
        /// <param name="buttonStyleId">按钮样式id</param>
        void Delete(int buttonStyleId);

        /// <summary>
        /// 根据按钮样式名称获取数据
        /// </summary>
        /// <param name="buttonStyleName">按钮样式名称</param>
        /// <param name="menuId">菜单id</param>
        /// <param name="loginResult">登陆人员信息</param>
        /// <returns></returns>
        List<SysButtonStyleOutPut> GetAll(string buttonStyleName, string menuId, LoginResult loginResult);
    }
}
