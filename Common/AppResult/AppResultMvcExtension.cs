using ChatApi.Common.Result;
using Microsoft.Extensions.Options;


namespace Microsoft.Extensions.DependencyInjection;

public static class AppResultMvcExtension
{
    public static IMvcBuilder AddAppResult(this IMvcBuilder builder, Action<AppResultOptions>? options = null)
    {

        builder.AddMvcOptions(opt => opt.Filters.Add<ResultActionFilter>());
       
        //默认配置
        builder.Services.AddTransient
            <IConfigureOptions<AppResultOptions>, ResultOptionsSetup>();

        if (options != null)//自定义配置
            builder.Services.Configure(options);
 

        return builder;
    }
}