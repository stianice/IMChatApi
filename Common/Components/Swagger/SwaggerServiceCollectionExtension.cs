using ChatApi.Common.Swagger;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SwaggerServiceCollectionExtension
    {
        public static IServiceCollection AddSimpleSwagger(this IServiceCollection services, Action<SwaggerGenOptions>? setup = null)
        {
            //默认配置
            
            services.AddSwaggerGen(opt =>
            {
                //api加锁
                opt.OperationFilter<SimpleOperationFilter>();

                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "内容直接输入token",
                    In = ParameterLocation.Header,
                    BearerFormat = "JWT",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    Type = SecuritySchemeType.Http
                });


            });


            if (setup != null) services.Configure(setup);


            return services;
        }
    }
}
