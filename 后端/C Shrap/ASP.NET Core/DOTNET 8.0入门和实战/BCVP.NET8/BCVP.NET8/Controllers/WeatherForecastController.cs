using AutoMapper;
using BCVP.NET8.IService;
using BCVP.NET8.Model;
using BCVP.NET8.Service;
using Microsoft.AspNetCore.Mvc;

namespace BCVP.NET8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBaseServices<Role, RoleVo> _roleService;
        private readonly IMapper _mapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<object> Get()
        {
            //var userService = new UserService();
            // var userList = await userService.Query();
            // return userList;

            var roleService = new BaseServices<Role, RoleVo>(_mapper);
            var roleList = await roleService.Query();

            //var roleList = await _roleService.Query();
            return roleList;
        }
    }
}
