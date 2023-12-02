



using ChatApi.Common.Components.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ChatApi.Common.Startup
{
    public class SimpleHostService : IHostedService
    {
        public SimpleHostService(IHost host)
        {
            Host = host;
        }

        public IHost Host { get; set; }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var services = Host.Services;

            var jsonOptions = services.GetService<IOptions<JsonOptions>>();
            //配置jsonHelp
            if (jsonOptions != null)
                JsonHelper.Configure(jsonOptions.Value.JsonSerializerOptions);


            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
