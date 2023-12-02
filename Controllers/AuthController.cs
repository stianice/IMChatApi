using ChatApi.Common.Result;
using ChatApi.Service;
using ChatApi.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController(AuthService authService) : ControllerBase
    {
        [HttpPost]
        public async Task<AppResult> Login(UserDtoParam userDto)
        {
            var (user, token) = await authService.Login(userDto);

            var data = new Dictionary<string, object>();
            data["user"] = user;
            data["token"] = token;

            return AppResult.OkDetailed(data, "登录成功");
        }


        [HttpPost]
        public async Task<AppResult> Register(UserDtoParam userDto)
        {
            var (user, token) = await authService.Register(userDto);

            var data = new Dictionary<string, object>();
            data["user"] = userDto;
            data["token"] = token;

            return AppResult.OkDetailed(data, "注册成功");
        }
    }
}
