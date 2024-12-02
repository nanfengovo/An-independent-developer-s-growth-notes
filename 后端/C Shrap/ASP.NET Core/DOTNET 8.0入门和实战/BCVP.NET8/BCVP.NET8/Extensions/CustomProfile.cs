using AutoMapper;
using BCVP.NET8.Model;

namespace BCVP.NET8.Extensions
{
    public class CustomProfile:Profile
    {
        //配置构造函数，用来创建关系映射
        public CustomProfile()
        {
            CreateMap<Role,RoleVo>()
                .ForMember(a => a.RoleName,o => o.MapFrom(d => d.Name));
            CreateMap<RoleVo, Role>()
                .ForMember(a => a.Name, o => o.MapFrom(d => d.RoleName));
        }

    }
}
