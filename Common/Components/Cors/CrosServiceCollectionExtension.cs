using ChatApi.Common.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CrosServiceCollectionExtension
    {
        public static IServiceCollection AddSimpleCros(this IServiceCollection services)
        {
            var allowCors = AppSetting.AllowCors;
            services.AddCors(opt =>
            {
                opt.AddPolicy("default", opt =>
                {
                     opt.WithOrigins(allowCors)
                        .AllowAnyHeader()
                        .AllowAnyHeader()
                        .AllowAnyMethod();

                });
            });


            return services;
        }
    }
}
