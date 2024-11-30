using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCVP.NET8.IService
{
    public interface IBaseServices<TEntity,TVo> where TEntity : class
    {
        Task<List<TEntity>> Query();
    }
}
