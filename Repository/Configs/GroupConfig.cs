using ChatApi.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApi.Repository.Configs
{
    public class GroupConfig:IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(k => k.GroupId);
            builder.Property(p => p.GroupName).HasMaxLength(20);
            builder.HasMany(g => g.Users).WithMany(u => u.Groups)
                .UsingEntity("Group_User_Map");
            builder.ToTable("Group");

        }
    }
}
