using AutoMapper;
using BCVP.NET8.IService;
using BCVP.NET8.Model;
using BCVP.NET8.Repository;
using BCVP.NET8.Repository.Base;

namespace BCVP.NET8.Service
{
    public class BaseServices<TEntity,TVo> : IBaseServices<TEntity,TVo> where TEntity : class,new()
    {
        //public async Task<List<TEntity>> Query()
        //{
        //    var baseRepo = new BaseRepository<TEntity>();
        //    return await baseRepo.Query();
        //}


        private readonly IMapper _mapper;

        //依赖注入
        public BaseServices(IMapper mapper)
        {
            _mapper = mapper;
        }


        //对象关系映射
        public async Task<List<TVo>> Query()
        {
            var baseRepo = new BaseRepository<TEntity>();
            var entities = await baseRepo.Query();
            var llout = _mapper.Map<List<TVo>>(entities);
            return llout;
        }
    }
}
