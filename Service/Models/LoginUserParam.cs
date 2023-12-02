using System.ComponentModel.DataAnnotations;

namespace ChatApi.Service.Models
{
    public class UserDtoParam
    {
        public long? UserId { get; set; } = null;
        
        [Required(ErrorMessage = "用户名不为空")]
        [Length(5, 25, ErrorMessage = "登录名需要5到25个字符")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "密码不为空")]
        [Length(8, 16, ErrorMessage = "密码不少于8到16位")]
        public string Password { get; set; } = null!;
    }
}
