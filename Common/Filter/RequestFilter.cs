using Microsoft.AspNetCore.Mvc.Filters;

namespace ChatApi.Common.Filter
{
    public class RequestFilter:IAsyncActionFilter,IOrderedFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //TODO 打印记录请求记录
            next();
            return Task.CompletedTask;
        }

        public int Order { get; set; }
    }
}
