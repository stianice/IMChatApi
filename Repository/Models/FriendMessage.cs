namespace ChatApi.Repository.Models;

public class FriendMessage
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long FriendId { get; set; }

    public string Content { get; set; } = null!;

    public byte MessageType { get; set; }

    public long Time { get; set; }
}
