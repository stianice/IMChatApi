using ChatApi.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApi.Repository.Configs
{
    public class FriendMessageConfig:IEntityTypeConfiguration<FriendMessage>
    {
        public void Configure(EntityTypeBuilder<FriendMessage> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Content)
                .IsRequired()
                .HasColumnType("longtext");
            builder.ToTable("Friend_Message");
        }
    }
}
