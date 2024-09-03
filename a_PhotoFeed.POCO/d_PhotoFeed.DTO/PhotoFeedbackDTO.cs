using System;

namespace d_PhotoFeed.DTO
{
    public class PhotoFeedbackDTO
    {
        public int IdPhotoFeedback { get; set; }
        public int IdUser { get; set; }
        public int Copyrighted { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
