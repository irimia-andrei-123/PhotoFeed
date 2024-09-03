namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompanyContact")]
    public partial class CompanyContact
    {
        [Key]
        public int IdContact { get; set; }

        public int IdContactCompany { get; set; }

        [Required]
        [StringLength(255)]
        public string WebsiteName { get; set; }

        [Required]
        [StringLength(255)]
        public string WebsiteUrl { get; set; }

        public virtual Company Company { get; set; }
    }
}
