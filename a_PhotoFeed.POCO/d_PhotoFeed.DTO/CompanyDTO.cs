namespace d_PhotoFeed.DTO
{
    public class CompanyDTO
    {
        public int IdCompany { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string ProfilePicture { get; set; }
        public int Allowed { get; set; }
    }
}
