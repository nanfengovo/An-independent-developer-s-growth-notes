using Microsoft.IdentityModel.Tokens;
using Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ProjectManageWebApi
{

    /// <summary>
    /// Jwt帮助类
    /// </summary>
    public static class JwtHelper
    {
        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="loginResult">登陆返回信息</param>
        /// <returns></returns>
        public static LoginResult BuildToken(LoginResult loginResult)
        {
            LoginResult result = new LoginResult();
            //获取配置
            var jwtsetting = ConfigurationFileHelper.GetNode<JwtSetting>("JwtSetting");

            //准备calims，记录登录信息
            var calims = loginResult.PropValuesType().Select(x => new Claim(x.Name, x.Value.ToString(), x.Type)).ToList();

            //创建header
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtsetting.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(creds);

            //创建payload
            var payload = new JwtPayload(jwtsetting.Issuer, jwtsetting.Audience, calims, DateTime.Now, DateTime.Now.AddMinutes(jwtsetting.ExpireSeconds));

            //创建令牌 
            var token = new JwtSecurityToken(header, payload);
            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            result.ExpiresDate = token.ValidTo.AddHours(8).ToString();
            result.Token = tokenStr;
            result.UserId = loginResult.UserId;
            result.UserName = loginResult.UserName;
            result.RoleIds = loginResult.RoleIds;
            return result;
        }

        /// <summary>
        /// 反射获取字段
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IEnumerable<(string Name, object Value, string Type)> PropValuesType(this object obj)
        {
            List<(string a, object b, string c)> result = new List<(string a, object b, string c)>();

            var type = obj.GetType();
            var props = type.GetProperties();
            foreach (var item in props)
            {
                result.Add((item.Name, item.GetValue(obj), item.PropertyType.Name));
            }
            return result;
        }


    }

}
