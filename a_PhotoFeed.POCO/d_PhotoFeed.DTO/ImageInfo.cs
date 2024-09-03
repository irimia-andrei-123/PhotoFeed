using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d_PhotoFeed.DTO
{
    public class ImageInfo
    {
        public int IdPhoto { get; set; }
        public string Photo { get; set; }
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string UserPicture { get; set; }
        public string Description { get; set; }
        public DateTime DatePosted { get; set; }
        public int Rating { get; set; }
        // comments
    }
}
