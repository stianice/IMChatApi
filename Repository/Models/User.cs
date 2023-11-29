using SqlSugar;

namespace ChatApi.Repository.Models;

public class User
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public long UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Avatar { get; set; } = null!;

    public string Role { get; set; } = null!;

    public byte Status { get; set; }

    public byte Tag { get; set; }

    public long CreateTime { get; set; }
    [SugarColumn(IsIgnore = true)]

    public List<Group> Groups { get; set; } = new ();
    [SugarColumn(IsIgnore = true)]
    public List<Friend2> Friend2s { get; set; } = new ();
    [SugarColumn(IsIgnore = true)]
    public List<User> Friends { get; set; } = new ();
  
}

public class Friend2
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public long FriendId { get; set; }
    [SugarColumn(IsIgnore = true)]
    public List<User> User { get; set; } = new List<User>();

}