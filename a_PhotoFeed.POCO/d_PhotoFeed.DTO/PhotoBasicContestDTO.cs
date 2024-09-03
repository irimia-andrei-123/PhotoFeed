using System;

namespace d_PhotoFeed.DTO
{
    public class PhotoBasicContestDTO
    {
        public int IdPhotoBasicContest { get; set; }
        public int IdBasicContest { get; set; }
        public int IdUser { get; set; }
        public int Copyrighted { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public DateTime DatePosted { get; set; }
        public int Rating { get; set; }
    }
}
