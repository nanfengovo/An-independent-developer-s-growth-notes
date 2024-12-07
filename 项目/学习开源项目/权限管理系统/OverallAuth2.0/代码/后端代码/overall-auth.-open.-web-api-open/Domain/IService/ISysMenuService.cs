using Model;
using Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Domain.IService
{
    /// <summary>
    /// 菜单服务
    /// </summary>
    public interface ISysMenuService
    {
        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="menu"></param>
        void Insert(Menu menu);

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="menu"></param>
        void Update(Menu menu);

        /// <summary>
        /// 根据key获取菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Menu GetByKey(string id);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        List<Menu> GetAll();

        /// <summary>
        /// 获取所有菜单--上下级关系
        /// </summary>
        /// <returns></returns>
        List<MenuDao> GetAllChildren();

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        PageResultModel<MenuOutput> GetMenusList(PageResultModel pageResultModel, LoginResult loginResult);

        /// <summary>
        /// 获取用户所属菜单
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns>返回用户所属菜单</returns>
        ReceiveStatus<MenuDao> GetMenuByUserId(string userId);
    }
}
