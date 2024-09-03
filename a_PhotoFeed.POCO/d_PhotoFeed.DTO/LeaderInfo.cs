using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d_PhotoFeed.DTO
{
    public class LeaderInfo
    {
        public int UserId { get; set; }
        public int Position { get; set; }
        public string Username { get; set; }
        public int Points { get; set; }
        public int ProContestsWon { get; set; }
        public int BasicContestsWon { get; set; }
    }
}
