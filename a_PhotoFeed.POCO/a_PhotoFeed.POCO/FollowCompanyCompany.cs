namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FollowCompanyCompany")]
    public partial class FollowCompanyCompany
    {
        [Key]
        public int IdFollow { get; set; }

        public int IdCompany { get; set; }

        public int IdCompanyFollowed { get; set; }

        public virtual Company Company { get; set; }

        public virtual Company Company1 { get; set; }
    }
}
