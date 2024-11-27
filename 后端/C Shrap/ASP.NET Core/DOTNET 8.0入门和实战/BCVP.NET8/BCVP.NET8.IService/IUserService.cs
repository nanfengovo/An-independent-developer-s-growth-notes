using BCVP.NET8.Model;

namespace BCVP.NET8.IService
{
    public interface IUserService
    {
        Task<List<UserVo>> Query();
    }
}
