using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.IdentityModel.Tokens;

namespace ChatApi.Repository;

public class ChatDbContextFactory:IDesignTimeDbContextFactory<ChatDbContext>
{
    public ChatDbContext CreateDbContext(string[] args)
    {
        var opt = new DbContextOptionsBuilder<ChatDbContext>();
        string con = "server=192.168.0.6;user=root;password=root;database=ChatApi";
  
        opt.UseMySql(con,ServerVersion.AutoDetect(con));
        return new ChatDbContext(opt.Options);
    }
}