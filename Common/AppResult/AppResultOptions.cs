using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Common.Result;

public class AppResultOptions
{
    private Func<AppResultException, IActionResult> _result=default!;

    public Func<AppResultException, IActionResult> ResultFactory
    {
        get => _result;
        set =>  _result = value ?? throw new ArgumentNullException(nameof(value));
    }
}