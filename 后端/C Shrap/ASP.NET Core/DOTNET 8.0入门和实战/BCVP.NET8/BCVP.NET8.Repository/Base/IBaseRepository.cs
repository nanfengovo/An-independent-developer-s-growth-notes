using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCVP.NET8.Repository.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> Query();
    }
}
