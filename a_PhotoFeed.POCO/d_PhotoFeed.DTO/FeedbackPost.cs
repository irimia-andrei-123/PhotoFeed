using System;
using System.Collections.Generic;

namespace d_PhotoFeed.DTO
{
    public class FeedbackPost
    {
        public int IdPhotoFeedback { get; set; }
        public string Photo { get; set; }
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public DateTime DatePosted { get; set; }
        public List<FeedbackComment> Comments { get; set; }
    }
}
