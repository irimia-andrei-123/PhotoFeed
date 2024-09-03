namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserContact")]
    public partial class UserContact
    {
        [Key]
        public int IdContact { get; set; }

        public int IdContactUser { get; set; }

        [Required]
        [StringLength(255)]
        public string WebsiteName { get; set; }

        [Required]
        [StringLength(255)]
        public string WebsiteUrl { get; set; }

        public virtual User User { get; set; }
    }
}
