
namespace d_PhotoFeed.DTO
{
    public class UserDTO
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string ProfilePicture { get; set; }
        public int Verified { get; set; }
        public int Points { get; set; }
        public int Moderator { get; set; }
        public int Blocked { get; set; }
    }
}
