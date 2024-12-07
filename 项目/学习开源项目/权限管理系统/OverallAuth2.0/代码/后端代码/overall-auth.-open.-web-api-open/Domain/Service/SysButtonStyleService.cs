using Infrastructure;
using Model;
using Model.BusinessModel;
using Subdomain.DomainCore;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    /// <summary>
    /// 按钮样式服务接口实现
    /// </summary>
    public class SysButtonStyleService : ISysButtonStyleService
    {
        #region 构造实例化

        //仓储接口
        private readonly ISysButtonStyleRepository _sysButtonStyleRepository;

        /// <summary>
        /// 构造函数 实现依赖注入
        /// </summary>
        public SysButtonStyleService(ISysButtonStyleRepository sysButtonStyleRepository)
        {
            _sysButtonStyleRepository = sysButtonStyleRepository;
        }

        #endregion

        #region 服务实现

        /// <summary>
        /// 新增按钮样式
        /// </summary>
        /// <param name="sysButtonStyle"></param>
        public void Insert(SysButtonStyle sysButtonStyle)
        {
            _sysButtonStyleRepository.Insert(sysButtonStyle, BaseSqlRepository.sysButtonStyle_insertSql);
        }

        /// <summary>
        /// 修改按钮样式
        /// </summary>
        /// <param name="sysButtonStyle"></param>
        public void Update(SysButtonStyle sysButtonStyle)
        {
            _sysButtonStyleRepository.Update(sysButtonStyle, BaseSqlRepository.sysButtonStyle_updateSql);
        }

        /// <summary>
        /// 删除按钮样式
        /// </summary>
        /// <param name="buttonStyleId"></param>
        public void Delete(int buttonStyleId)
        {
            _sysButtonStyleRepository.Delete(buttonStyleId.ToString(), BaseSqlRepository.sysButtonStyle_delete);
        }

        /// <summary>
        /// 根据按钮样式名称获取数据
        /// </summary>
        /// <param name="buttonStyleName">按钮样式名称</param>
        /// <param name="menuId">菜单id</param>
        /// <param name="loginResult">登陆人员信息</param>
        /// <returns></returns>
        public List<SysButtonStyleOutPut> GetAll(string buttonStyleName, string menuId, LoginResult loginResult)
        {
            List<SysButtonStyleOutPut> sysButtonStyleOutPutsList = new();
            var authWhere = DataAuthCore.GetRowDataAuthRoleSql("bs", menuId, loginResult);
            var list = _sysButtonStyleRepository.GetByButtonStyleNameList(buttonStyleName, authWhere).OrderByDescending(f => f.CreateTime).ToList();         
            return list;
        }

        #endregion
    }
}
