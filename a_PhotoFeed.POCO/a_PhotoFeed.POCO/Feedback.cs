namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        [Key]
        public int IdFeedback { get; set; }

        public int IdCommenter { get; set; }

        public int IdPhotoFeedback { get; set; }

        [Required]
        public string GoodParts { get; set; }

        [Required]
        public string BadParts { get; set; }

        public string Miscellaneous { get; set; }

        [Column(TypeName = "date")]
        public DateTime DatePosted { get; set; }

        [Required]
        public int Rating { get; set; }

        public virtual User User { get; set; }

        public virtual PhotoFeedbackCategory PhotoFeedbackCategory { get; set; }
        
    }
}
