using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ChatApi.Common.Swagger
{
    public class SimpleOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var isCtrAuth = context.MethodInfo.DeclaringType?.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() ?? false;

            var isMethAuth = context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

            var isAnony = context.MethodInfo.GetCustomAttributes(true).OfType<AllowAnonymousAttribute>().Any();


            //如果控制器和方法都没有auth
            if (!(isCtrAuth || isMethAuth)) return;
            //如果方法匿名
            if (isAnony) return;

            var bearer = new OpenApiSecurityScheme()
            {
                Scheme = "Bearer",
                Reference = new OpenApiReference()
                {
                    Id = "Bearer",Type = ReferenceType.SecurityScheme
                }
            };

            operation.Security = new List<OpenApiSecurityRequirement>()
         {
             new()
             {
                 [bearer] = Array.Empty<string>()
             }
         };
        }
    }
}