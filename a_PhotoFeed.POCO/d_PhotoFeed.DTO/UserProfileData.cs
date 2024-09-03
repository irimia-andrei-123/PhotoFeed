using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d_PhotoFeed.DTO
{
    public class UserProfileData
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string ProfilePicture { get; set; }
        public int Points { get; set; }
        public int Blocked { get; set; }
        public List<UserContactDTO> Contact { get; set; }
    }
}
