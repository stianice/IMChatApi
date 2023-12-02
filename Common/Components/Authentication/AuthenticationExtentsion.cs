using System.Text;
using ChatApi.Common.Result;
using ChatApi.Common.Components.Json;
using ChatApi.Common.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AuthenticationExtentsion
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
        {


            //读取配置
            var audience = AppSetting.Jwt.Audience;
            var issuer = AppSetting.Jwt.Issuer;
            var base64SecretKey = AppSetting.Jwt.SecretKey;


            //配置密钥

            var secretKey = Encoding.UTF8.GetBytes(base64SecretKey);
            var signingKey = new SymmetricSecurityKey(secretKey);

            var valiParam = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidAudience = audience,

                ValidateIssuer = true,
                ValidIssuer = issuer,

                IssuerSigningKey = signingKey,
                ValidateIssuerSigningKey = true,
                
                ClockSkew = TimeSpan.FromSeconds(30),

                ValidateLifetime = true,//验证生效时间
                RequireExpirationTime = true//需要过期时间


            };

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true, // 是否验证SecurityKey
                IssuerSigningKey = signingKey, // 拿到SecurityKey

                ValidateIssuer = true, // 是否验证Issuer
                ValidIssuer = issuer, // 发行人Issuer

                ValidateAudience = true, // 是否验证Audience
                ValidAudience = audience, // 订阅人Audience

                ValidateLifetime = true, // 是否验证失效时间
                ClockSkew = TimeSpan.FromSeconds(30), // 过期时间容错值，解决服务器端时间不同步问题（秒）

                RequireExpirationTime = true,

            };


            var events = new JwtBearerEvents()
            {
                OnForbidden =  context =>
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
                    context.HttpContext.Response.ContentType = "application/json;charset=utf-8";
                    var body = JsonHelper.Serialize(AppResult.ErrorMessage("无权操作"));
                    
                    context.HttpContext.Response.WriteAsync(body);
                
                    return Task.CompletedTask;
                },
              
                OnChallenge = context =>
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
                    context.HttpContext.Response.WriteAsJsonAsync(AppResult.ErrorMessage("未登录，请登录"));
                    return Task.CompletedTask;

                }
            };


            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer("default", opt =>
            {
                opt.TokenValidationParameters = tokenValidationParameters;
                opt.Events = events;
            });


            return services;


        }
    }
}
