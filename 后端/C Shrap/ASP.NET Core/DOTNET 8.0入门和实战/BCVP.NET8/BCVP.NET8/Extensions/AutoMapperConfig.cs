using AutoMapper;

namespace BCVP.NET8.Extensions
{
    public class AutoMapperConfig
    {
        /// <summary>
        /// 静态全局AutoMapper配置文件
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(profile: new CustomProfile());
            });
        }       
    }
}
