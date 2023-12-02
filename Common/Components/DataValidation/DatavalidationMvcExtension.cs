using ChatApi.Common.DataValidation;

namespace Microsoft.Extensions.DependencyInjection;

public static class DatavalidationMvcExtension
{
    public static IMvcBuilder AddDataValidation(this IMvcBuilder builder)
    {
        //禁用默认模型验证过滤器
        builder.ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true);

        builder.AddMvcOptions(opt => opt.Filters.Add<DataValidationFilter>());
            

        return builder;

    }
}