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
   

    public List<Group> Groups { get; set; } = new ();
   
  
    public List<User> Friends { get; set; } = new ();
  
}

