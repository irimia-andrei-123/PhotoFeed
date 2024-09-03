using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d_PhotoFeed.DTO
{
    public class UploadImage
    {
        public string Photo { get; set; }
        public int IdUser { get; set; }
        public int Copyrighted { get; set; }
        public string Description { get; set; }
        public DateTime DatePosted { get; set; }
        public int Rating { get; set; }
        public List<int> Categories { get; set; }
        public List<string> Tags { get; set; }
    }
}
