namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhotoProContest")]
    public partial class PhotoProContest
    {
        [Key]
        public int IdPhotoProContest { get; set; }

        public int IdProContest { get; set; }

        public int IdUser { get; set; }

        public int Copyrighted { get; set; }
        
        [Required]
        public string Photo { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime DatePosted { get; set; }

        public int Rating { get; set; }

        public virtual ContestPro ContestPro { get; set; }

        public virtual CopyrightStat CopyrightStat { get; set; }

        public virtual User User { get; set; }
    }
}
