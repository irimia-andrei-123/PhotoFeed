namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FollowCompanyCategory")]
    public partial class FollowCompanyCategory
    {
        [Key]
        public int IdFollow { get; set; }

        public int IdCompany { get; set; }

        public int IdCategoryFollowed { get; set; }

        public virtual Category Category { get; set; }

        public virtual Company Company { get; set; }
    }
}
