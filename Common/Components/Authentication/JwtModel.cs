namespace ChatApi.Common.Components.Authentication
{
    public class JwtModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; } = null!;

       public string Role { get; set; } =null!;
    }
}
