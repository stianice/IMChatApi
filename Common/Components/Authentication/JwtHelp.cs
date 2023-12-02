using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChatApi.Common.Configuration;
using Microsoft.IdentityModel.Tokens;
using IdentityModel;
namespace ChatApi.Common.Components.Authentication
{
    public class JwtHelp
    {
        public static string SignToken(JwtModel jwtModel)
        {
            //获取jwt配置
            var audience = AppSetting.Jwt.Audience;
            var issuer = AppSetting.Jwt.Issuer;
            var secretKey = AppSetting.Jwt.SecretKey;

            //声明
            var claims = new Claim[]
            {
                new (JwtClaimTypes.Name,jwtModel.UserName),
                new(JwtClaimTypes.Role,jwtModel.Role),
                new( JwtClaimTypes.Id,jwtModel.UserId)

            };

            var nbf = DateTime.UtcNow;
            var exp = DateTime.UtcNow.AddMinutes(10);

            var bytesKey = Encoding.UTF8.GetBytes(secretKey);

            var crt = new SymmetricSecurityKey(bytesKey);

            var signingCredentials = new SigningCredentials(crt, SecurityAlgorithms.HmacSha256);




            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = new JwtSecurityToken(issuer, audience, claims, nbf, exp, signingCredentials);
            var token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            
            return token;
        }
    }
}
