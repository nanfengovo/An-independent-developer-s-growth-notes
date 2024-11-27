using BCVP.NET8.Model;

namespace BCVP.NET8.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> Query();
    }
}
