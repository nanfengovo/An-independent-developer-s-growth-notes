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
        private readonly IBaseRepository<TEntity> _baseRepository;

        //依赖注入
        public BaseServices(IMapper mapper,IBaseRepository<TEntity> baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }


        //对象关系映射
        public async Task<List<TVo>> Query()
        {
            //var baseRepo = new BaseRepository<TEntity>();
            var entities = await _baseRepository.Query();
            var llout = _mapper.Map<List<TVo>>(entities);
            return llout;
        }
    }
}
