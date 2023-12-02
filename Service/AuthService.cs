using ChatApi.Common.Components.Authentication;
using ChatApi.Common.Result;
using ChatApi.Repository;
using ChatApi.Repository.Models;
using ChatApi.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Service
{
    public class AuthService(ChatDbContext chatDb)
    {
        public async Task<(User, string token)> Login(UserDtoParam userDto)
        {

            var user = await chatDb.Users.FirstOrDefaultAsync(s =>
                      s.Username == userDto.UserName
                      &&
                      s.Password == userDto.Password)
                  ?? throw AppResultException.ErrorMessageException("用户不存在");

            var jwtModel = new JwtModel()
            {
                UserId = user.UserId.ToString(),
                UserName = user.Username,
                Role = user.Role
            };

            var token = JwtHelp.SignToken(jwtModel);

            return (user, token);


        }

        public async Task<(User, string token)> Register(UserDtoParam userDto)
        {
            var user = chatDb.Users.FirstOrDefault(s => s.Username == userDto.UserName);

            if (user != null) throw AppResultException.ErrorMessageException("该用户名已被注册");
            await using var transaction = await chatDb.Database.BeginTransactionAsync();
            user = new()
            {
                Username = userDto.UserName,
                Password = userDto.Password,
                Avatar = $"api/v1/avatar({new Random().Next(0, 20)})",
                Role = "user"
            };

            chatDb.Add(user);

            await chatDb.SaveChangesAsync();

            var group = chatDb.Groups.FirstOrDefault(g => g.GroupName == "阿童木聊天室") ?? new Group()
            {
                UserId = user.UserId,
                GroupName = "阿童木聊天室"
            };

            chatDb.Add(group);
            await chatDb.SaveChangesAsync();
            await transaction.CommitAsync();

            var jwtModel = new JwtModel()
            {
                UserId = user.UserId.ToString(),
                UserName = user.Username,
                Role = user.Role
            };

            var token = JwtHelp.SignToken(jwtModel);

            return (user, token);
        }
    }
}
