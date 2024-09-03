using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d_PhotoFeed.DTO
{
    public class FeedbackComment
    {
        public int IdCommenter { get; set; }
        public string CommenterName { get; set; }
        public int IdPhotoFeedback { get; set; }
        public string Miscellaneous { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
