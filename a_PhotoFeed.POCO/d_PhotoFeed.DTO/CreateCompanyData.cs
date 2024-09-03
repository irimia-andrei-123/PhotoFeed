using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d_PhotoFeed.DTO
{
    public class CreateCompanyData
    {
        public int IdCompany { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string ProfilePicture { get; set; }
        public int[] Members { get; set; }
        public int Allowed { get; set; }
        public List<CompanyContactDTO> ContactInfo { get; set; }
    }
}
