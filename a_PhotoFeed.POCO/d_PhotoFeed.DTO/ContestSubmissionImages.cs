using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d_PhotoFeed.DTO
{
    public class ContestSubmissionImages
    {
        public int IdUser { get; set; }
        public string[] Photos { get; set; }
        public int IdContest { get; set; }
    }
}
