using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{

    /// <summary>
    /// 仓储基类
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    public abstract class Repository<T> : IRepository<T> where T : class, new()
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="deleteSql">删除sql</param>
        /// <returns></returns>
        public int Delete(string key, string deleteSql)
        {
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Execute(deleteSql, new { Key = key });
        }

        /// <summary>
        /// 根据主键获取模型
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="selectSql">查询sql</param>
        /// <returns></returns>
        public T GetByKey(string id, string selectSql)
        {
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.QueryFirstOrDefault<T>(selectSql, new { Key = id });
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="selectAllSql">查询sql</param>
        /// <returns></returns>
        public List<T> GetAll(string selectAllSql)
        {
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Query<T>(selectAllSql).ToList();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">新增实体</param>
        /// <param name="innserSql">新增sql</param>
        /// <returns></returns>
        public int Insert(T entity, string innserSql)
        {
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Execute(innserSql, entity);
        }

        /// <summary>
        /// 根据唯一主键验证数据是否存在
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="selectSql">查询sql</param>
        /// <returns>返回true存在，false不存在</returns>
        public bool IsExist(string id, string selectSql)
        {
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            var count = connection.QueryFirst<int>(selectSql, new { Key = id });
            if (count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">更新实体</param>
        /// <param name="updateSql">更新sql</param>
        /// <returns></returns>
        public int Update(T entity, string updateSql)
        {
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            return connection.Execute(updateSql, entity);
        }

        /// <summary>
        /// 分页方法
        /// </summary>
        /// <typeparam name="T">泛型集合实体类</typeparam>
        /// <param name="pageResultModel">分页模型</param>
        /// <returns></returns>
        public PageResultModel<T> GetPageList<T>(PageResultModel pageResultModel)
        {
            PageResultModel<T> resultModel = new();
            using var connection = DataBaseConnectConfig.GetSqlConnection();
            int skip = 1;
            var orderBy = string.Empty;
            if (pageResultModel.pageIndex > 0)
            {
                skip = (pageResultModel.pageIndex - 1) * pageResultModel.pageSize + 1;
            }
            if (!string.IsNullOrEmpty(pageResultModel.orderByField))
            {
                orderBy = string.Format(" ORDER BY {0} {1} ", pageResultModel.orderByField, pageResultModel.sortType);
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT COUNT(1) FROM {0} where 1=1 {1};", pageResultModel.tableName, pageResultModel.selectWhere);
            sb.AppendFormat(@"SELECT  *
                                FROM(SELECT ROW_NUMBER() OVER( {3}) AS RowNum,{0}
                                          FROM  {1}
                                          where 1=1 {2}
                                        ) AS result
                                WHERE  RowNum >= {4}   AND RowNum <= {5}
                                 ", pageResultModel.tableField, pageResultModel.tableName, pageResultModel.selectWhere, orderBy, skip, pageResultModel.pageIndex * pageResultModel.pageSize);
            using var reader = connection.QueryMultiple(sb.ToString());
            resultModel.total = reader.ReadFirst<int>();
            resultModel.data = reader.Read<T>().ToList();
            return resultModel;
        }

    }
}
