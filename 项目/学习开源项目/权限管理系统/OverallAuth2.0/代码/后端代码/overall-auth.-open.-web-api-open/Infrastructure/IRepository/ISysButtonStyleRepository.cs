using Model;
using Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// 按钮样式仓储接口
    /// </summary>
    public interface ISysButtonStyleRepository : IRepository<SysButtonStyle>
    {
        /// <summary>
        /// 根据按钮样式名称获取数据
        /// </summary>
        /// <param name="MenuId">按钮样式名称</param>
        /// <param name="authWhere">权限条件</param>
        /// <returns></returns>
        public List<SysButtonStyleOutPut> GetByButtonStyleNameList(string buttonStyleName, string authWhere);
    }
}
