using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using ChatApi.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ChatApi.Repository;

public class ChatDbContext:DbContext
{
    public DbSet<FriendMessage> FriendMessages { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<GroupMessage> GroupMessages { get; set; }

    public ChatDbContext(DbContextOptions<ChatDbContext> options):base(options)
    {
            
            
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
            
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}