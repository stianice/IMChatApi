using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ChatApi.Common.Result;

public class ResultOptionsSetup : IConfigureOptions<AppResultOptions>
{
    public void Configure(AppResultOptions options)
    { 
        //默认统一返回200
        options.ResultFactory = result => new ObjectResult(result.AppResult) { StatusCode = StatusCodes.Status200OK };
    }

       
      
}