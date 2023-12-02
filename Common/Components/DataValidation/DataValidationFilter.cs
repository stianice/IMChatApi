using ChatApi.Common.Result;
using ChatApi.Common.Components.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace ChatApi.Common.DataValidation;

public class DataValidationFilter : IActionFilter, IOrderedFilter
{


    public int Order { get; set; }
    private AppResultOptions _options { get; set; }
    public DataValidationFilter(IOptions<AppResultOptions> options)
    {
        _options = options.Value;
    }
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid)
        {
            return;
        }

        var errors = context.ModelState
            .Where(m => m.Value != null && m.Value.ValidationState == ModelValidationState.Invalid)
            .SelectMany(s => s.Value.Errors)
            .Select(e => e.ErrorMessage).ToArray();


        var result = AppResult.ErrorDetailed(errors, "数据校验失败");


        context.Result = new ObjectResult(result)
        {
            StatusCode = StatusCodes.Status200OK
        };

        


    }

    public void OnActionExecuted(ActionExecutedContext context)
    {

    }
}