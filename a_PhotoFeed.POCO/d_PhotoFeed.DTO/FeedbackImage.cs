using System;

namespace d_PhotoFeed.DTO
{
    public class FeedbackImage
    {
        public int IdPhotoFeedback { get; set; }
        public string Photo { get; set; }
        public int IdUser { get; set; }
        public int IdImage { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
