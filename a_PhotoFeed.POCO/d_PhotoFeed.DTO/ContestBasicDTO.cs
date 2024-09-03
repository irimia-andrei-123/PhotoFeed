
using System;

namespace d_PhotoFeed.DTO
{
    public class ContestBasicDTO
    {
        public int IdContestBasic { get; set; }
        public int IdCreator { get; set; }
        public string ContestName { get; set; }
        public string Description { get; set; }
        public int MaximumPictureNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Closed { get; set; }
    }
}
