using ChatApi.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApi.Repository.Configs;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(k => k.UserId);
        builder.Property(p => p.Username).HasMaxLength(20);
        builder.HasMany<User>(g => g.Friends).WithMany()
            .UsingEntity("User_Friend_Map", l => l.HasOne(typeof(User)).WithMany().HasForeignKey("UserId"),
                r => r.HasOne(typeof(User)).WithMany().HasForeignKey("FriendId"));

        builder.ToTable("User");
    }
}