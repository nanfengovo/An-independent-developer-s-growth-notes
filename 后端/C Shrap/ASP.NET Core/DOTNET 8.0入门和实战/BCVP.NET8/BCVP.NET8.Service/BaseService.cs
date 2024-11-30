using BCVP.NET8.IService;
using BCVP.NET8.Model;
using BCVP.NET8.Repository;
using BCVP.NET8.Repository.Base;

namespace BCVP.NET8.Service
{
    public class BaseServices<TEntity,TVo> : IBaseServices<TEntity,TVo> where TEntity : class,new()
    {
        public async Task<List<TEntity>> Query()
        {
            var baseRepo = new BaseRepository<TEntity>();
            return await baseRepo.Query();
        }
    }
}
