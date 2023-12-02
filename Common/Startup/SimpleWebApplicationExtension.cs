using ChatApi.Common.Configuration;
using ChatApi.Common.Startup;
using NLog.Web;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SimpleWebApplicationExtension
    {
        public static WebApplicationBuilder AddSimpleConfigure(this WebApplicationBuilder builder)
        {

            var config = builder.Configuration;

            AppSetting.Configure(config);

            builder.Host.UseNLog();

            builder.Services.AddHostedService<SimpleHostService>();

            return builder;
        }
    }
}
