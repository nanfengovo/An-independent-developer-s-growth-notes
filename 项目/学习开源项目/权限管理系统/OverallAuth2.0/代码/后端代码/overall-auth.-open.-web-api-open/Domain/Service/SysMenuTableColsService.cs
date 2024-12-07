using Infrastructure;
using Model;
using Model.BusinessModel;
using Newtonsoft.Json.Linq;
using Subdomain;
using Subdomain.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Domain
{
    /// <summary>
    /// 菜单数据列权限服务接口实现
    /// </summary>
    public class SysMenuTableColsService : ISysMenuTableColsService
    {
        #region 构造实例化

        //仓储接口
        private readonly ISysMenuTableColsRepository _sysMenuTableColsRepository;
        private readonly ISysMenuTableColsRoleRepository _sysMenuTableColsRoleRepository;

        /// <summary>
        /// 构造实例化 实现依赖注入
        /// </summary>
        /// <param name="sysMenuTableColsRepository"></param>
        public SysMenuTableColsService(ISysMenuTableColsRepository sysMenuTableColsRepository, ISysMenuTableColsRoleRepository sysMenuTableColsRoleRepository)
        {
            _sysMenuTableColsRepository = sysMenuTableColsRepository;
            _sysMenuTableColsRoleRepository = sysMenuTableColsRoleRepository;
        }

        #endregion

        #region  服务实现

        /// <summary>
        /// 新增数据列
        /// </summary>
        /// <param name="sysMenuTableCols"></param>
        public ReceiveStatus Insert(SysMenuTableCols sysMenuTableCols)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            var result = Validate(sysMenuTableCols);
            if (!result.success)
                return result;
            sysMenuTableCols.IsSystemData = (int)ColsDataTypeEnum.CreateData;
            _sysMenuTableColsRepository.Insert(sysMenuTableCols, BaseSqlRepository.sysMenuTableCols_insertSql);
            return receiveStatus;
        }

        /// <summary>
        /// 修改按钮数据
        /// </summary>
        /// <param name="sysMenuTableCols"></param>
        public ReceiveStatus Update(SysMenuTableCols sysMenuTableCols)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            var result = Validate(sysMenuTableCols);
            if (!result.success)
                return result;
            _sysMenuTableColsRepository.Update(sysMenuTableCols, BaseSqlRepository.sysMenuTableCols_updateSql);
            return receiveStatus;
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="sysMenuTableCols"></param>
        /// <returns></returns>
        public ReceiveStatus Validate(SysMenuTableCols sysMenuTableCols)
        {
            ReceiveStatus receiveStatus = new ReceiveStatus();
            /*
         新增/修改前验证
         1、相同菜单下不能有重复的字段名称和插槽，不然绑定table和显示会有问题
         */
            var tableColsList = _sysMenuTableColsRepository.GetTableColsByMenuId(sysMenuTableCols.MenuId);
            foreach (var item in tableColsList)
            {
                if (item.FieldName.ToLower() == sysMenuTableCols.FieldName.ToLower() && Convert.ToInt32(item.Id) != sysMenuTableCols.Id)
                    return ExceptionHelper.CustomException(string.Format("该菜单已存在字段名称为【{0}】的数据,请重新输入!", sysMenuTableCols.FieldName));
                if (!string.IsNullOrWhiteSpace(sysMenuTableCols.FieldCustomSlot) && !string.IsNullOrWhiteSpace(item.FieldCustomSlot))
                {
                    if (item.FieldCustomSlot.ToLower() == sysMenuTableCols.FieldCustomSlot.ToLower() && Convert.ToInt32(item.Id) != sysMenuTableCols.Id)
                        return ExceptionHelper.CustomException(string.Format("该菜单已存在字段插槽为【{0}】的数据,请重新输入!", sysMenuTableCols.FieldCustomSlot));
                }
                if (!string.IsNullOrWhiteSpace(sysMenuTableCols.DataRowAuthField) && (!string.IsNullOrWhiteSpace(item.DataRowAuthField)))
                {
                    if (item.DataRowAuthField.ToLower() == sysMenuTableCols.DataRowAuthField.ToLower() && Convert.ToInt32(item.Id) != sysMenuTableCols.Id)
                        return ExceptionHelper.CustomException(string.Format("该菜单已存在行权限字段为【{0}】的数据,请重新输入!", sysMenuTableCols.DataRowAuthField));
                }
                if (!string.IsNullOrWhiteSpace(sysMenuTableCols.DataRowAuthFieldName) && !string.IsNullOrWhiteSpace(item.DataRowAuthFieldName))
                {
                    if (item.DataRowAuthFieldName.ToLower() == sysMenuTableCols.DataRowAuthFieldName.ToLower() && Convert.ToInt32(item.Id) != sysMenuTableCols.Id)
                        return ExceptionHelper.CustomException(string.Format("该菜单已存在行权限字段名称为【{0}】的数据,请重新输入!", sysMenuTableCols.DataRowAuthFieldName));
                }
            }
            return receiveStatus;
        }

        /// <summary>
        /// 删除数据列
        /// </summary>
        /// <param name="id">主键</param>
        public void Delete(int id)
        {
            _sysMenuTableColsRepository.Delete(id.ToString(), BaseSqlRepository.sysMenuTableCols_delete);
        }

        /// <summary>
        /// 获取菜单数据列
        /// </summary>
        /// <param name="pageResultModel">分页模型</param>
        /// <param name="loginResult">登陆人员信息</param>
        /// <returns>返回菜单数据列集合</returns>
        public PageResultModel<SysMenuTableColsDataOutPut> GetMenuTableColsList(PageResultModel pageResultModel, LoginResult loginResult)
        {
            var authWhere = DataAuthCore.GetRowDataAuthRoleSql("mc", pageResultModel.menuId, loginResult);
            var selectWhere = string.Empty;
            JObject jobj = JObject.Parse(pageResultModel.filterJson);
            var menuId = Convert.ToInt32(jobj["MenuId"].ToString());
            if (menuId > 0)
                selectWhere = string.Format(" and sm.id = {0} ", menuId);

            pageResultModel.selectWhere = selectWhere + authWhere;
            pageResultModel.tableField = " mc.*,(select d.MenuTitle+'->' +sm.MenuTitle from Sys_Menu as d where  d.Id = sm.Pid ) MenuTitle  ";
            pageResultModel.tableName = @" Sys_MenuTableCols as  mc  
                                            inner join  Sys_Menu as sm  on mc.MenuId = sm.Id ";
            pageResultModel.orderByField = " mc.CreateTime ";
            pageResultModel.sortType = " desc ";
            var list = _sysMenuTableColsRepository.GetPageList<SysMenuTableColsDataOutPut>(pageResultModel);
            return list;
        }

        /// <summary>
        /// 获取菜单拥有的列
        /// </summary>
        /// <param name="menuId">菜单id</param>
        /// <param name="roleId">角色id</param>
        /// <returns>返回对应列集合</returns>
        public ReceiveStatus<SysMenuTableColsOutPut> GetMenuHaveTableCols(int menuId, int roleId)
        {
            ReceiveStatus<SysMenuTableColsOutPut> receiveStatus = new();
            SysMenuTableColsOutPut sysMenuTableColsOutPut = new();
            sysMenuTableColsOutPut.SysMenuTableColsData = _sysMenuTableColsRepository.GetTableColsByMenuId(menuId);
            //取对应角色菜单拥有的数据列权限
            var buttonRoleList = _sysMenuTableColsRoleRepository.GetTableColsRoleByRoleIdOrMenuId(roleId, menuId);
            if (buttonRoleList != null || buttonRoleList.Count > 0)
                sysMenuTableColsOutPut.SelectedKeys = buttonRoleList.Select(f => f.MenuTableColsId.ToString()).ToArray();

            receiveStatus.data = new List<SysMenuTableColsOutPut>() { sysMenuTableColsOutPut };
            receiveStatus.msg = "获取成功";
            return receiveStatus;
        }

        #endregion

    }
}
