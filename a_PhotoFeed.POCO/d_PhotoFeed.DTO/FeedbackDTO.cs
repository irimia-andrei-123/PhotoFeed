using System;

namespace d_PhotoFeed.DTO
{
    public class FeedbackDTO
    {
        public int IdFeedback { get; set; }
        public int IdCommenter { get; set; }
        public int IdPhotoFeedback { get; set; }
        public string GoodParts { get; set; }
        public string BadParts { get; set; }
        public string Miscellaneous { get; set; }
        public DateTime DatePosted { get; set; }
        public int Rating { get; set; }
    }
}
