using ChatApi.Common.Result;
using ChatApi.Repository;
using ChatApi.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Service
{
    public class UserService(ChatDbContext chatDb)
    {

        public async Task<User> GetUser(long userId)
        {
            var user = await chatDb.Users.FirstOrDefaultAsync(u => u.UserId == userId) ??
                       throw AppResultException.FailMessageException("未找到用户");
            return user;
        }

        public async Task<List<User>> PostUsers(List<long> userIds)
        {

            try
            {
                return await chatDb.Users
                    .Where(u => userIds.Contains(u.UserId))
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw AppResultException.ErrorMessageException("获取用户信息失败",e);
            }

        }

        public async Task<User> UpdateUserName(User userDto)
        {
          var user= await chatDb.Users.FirstOrDefaultAsync(u=>u.Username==userDto.Username);
          if (user == null) throw AppResultException.FailMessageException("已存在用户名");

          return user;


        }

    }
}
