using ChatApi.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ChatApi.Repository.Configs
{
    public class GroupMessageConfig: IEntityTypeConfiguration<GroupMessage>
    {
        public void Configure(EntityTypeBuilder<GroupMessage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Content)
                   .HasColumnType("longtext")
                   .IsRequired();
            builder.ToTable("Group_Message");
        }
    }
}
