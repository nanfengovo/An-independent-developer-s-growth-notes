using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Utility;

namespace ProjectManageWebApi.Controllers
{
    /// <summary>
    /// 基础控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class BaseController : ControllerBase
    {

        /// <summary>
        /// 获取登陆人员信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public LoginResult GetLoginUserMsg()
        {
            StringValues s = new StringValues();
            var auth = Request.Headers.TryGetValue("Authorization", out s);
            if (string.IsNullOrWhiteSpace(s))
                ExceptionHelper.ThrowBusinessException("登录信息无效");
            var token = new JwtSecurityTokenHandler().ReadJwtToken(s.ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", ""));
            LoginResult loginResult = new()
            {
                UserName = token.Claims.FirstOrDefault(f => f.Type == "UserName").Value,
                UserId = Convert.ToInt32(token.Claims.FirstOrDefault(f => f.Type == "UserId").Value),
                RoleIds = Convert.ToString(token.Claims.FirstOrDefault(f => f.Type == "RoleIds").Value),
            };
            return loginResult;

        }
    }
}
