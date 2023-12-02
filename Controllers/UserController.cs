using ChatApi.Common.Result;
using ChatApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(UserService userService) : ControllerBase
    {

        [HttpGet]
        public async Task<AppResult> GetUser([FromRoute]long userId)
        {
            var user = await userService.GetUser(userId);
            return AppResult.OkData(user);
        }
    }
}
