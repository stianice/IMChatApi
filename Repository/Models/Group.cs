using System;
using System.Collections.Generic;

namespace ChatApi.Repository.Models;

public class Group
{
    public long GroupId { get; set; }

    public long UserId { get; set; }

    public string GroupName { get; set; } = null!;

    public string Notice { get; set; } = "无公告。。。。。";

    public long CreateTime { get; set; }

    public List<User> Users { get; set; } = new List<User>();
}
