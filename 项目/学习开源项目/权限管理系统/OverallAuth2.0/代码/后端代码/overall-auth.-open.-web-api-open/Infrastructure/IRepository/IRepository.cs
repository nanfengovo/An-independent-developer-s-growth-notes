using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// 仓储接口定义
    /// </summary>
    public interface IRepository
    {

    }

    /// <summary>
    /// 定义泛型仓储接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="object">主键类型</typeparam>
    public interface IRepository<T> : IRepository where T : class, new()
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="innserSql">新增sql</param>
        /// <returns></returns>
        int Insert(T entity, string innserSql);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="updateSql">更新sql</param>
        /// <returns></returns>
        int Update(T entity, string updateSql);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="deleteSql">删除sql</param>
        /// <returns></returns>
        int Delete(string key,string deleteSql);

        /// <summary>
        /// 根据主键获取模型
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="selectSql">查询sql</param>
        /// <returns></returns>
        T GetByKey(string key, string selectSql);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="selectAllSql">查询sql</param>
        /// <returns></returns>
        List<T> GetAll(string selectAllSql);

        /// <summary>
        /// 根据唯一主键验证数据是否存在
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="selectSql">查询sql</param>
        /// <returns>返回true存在，false不存在</returns>
        bool IsExist(string id, string selectSql);

        /// <summary>
        /// dapper通用分页方法
        /// </summary>
        /// <typeparam name="T">泛型集合实体类</typeparam>
        /// <param name="pageResultModel">分页模型</param>
        /// <returns></returns>
        PageResultModel<T> GetPageList<T>(PageResultModel pageResultModel);

    }
}
