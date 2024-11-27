using BCVP.NET8.Model;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BCVP.NET8.Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<User>> Query()
        {
            await Task.CompletedTask;
            var data = "[{\"Id\":18,\"Name\":\"nanfeng\"}]";
            return JsonConvert.DeserializeObject<List<User>>(data)??new List<User>();
        }
    }
}
