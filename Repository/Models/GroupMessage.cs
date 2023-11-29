using System;
using System.Collections.Generic;

namespace ChatApi.Repository.Models;

public class GroupMessage
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long GroupId { get; set; }

    public string Content { get; set; } = null!;

    public byte MessageType { get; set; }

    public long Time { get; set; }
}
