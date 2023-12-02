using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace ChatApi.Common.Result;

public class ResultActionFilter:IAsyncActionFilter,IOrderedFilter
{
    public int Order { get; set; }

    private AppResultOptions _appResultOptions;

    public ResultActionFilter(IOptions<AppResultOptions> appResultOptions)
    {
        _appResultOptions = appResultOptions.Value;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        //过滤前操作
        var actionContext=await next();

        if(actionContext.Result != null||context.Result!=null) return;

        if(actionContext.Exception is AppResultException resultException )
        {
            actionContext.Result=_appResultOptions.ResultFactory(resultException);
            actionContext.ExceptionHandled = true;
        }

    }

     
}