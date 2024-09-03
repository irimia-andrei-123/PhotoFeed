namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FollowCompanyUser")]
    public partial class FollowCompanyUser
    {
        [Key]
        public int IdFollow { get; set; }

        public int IdCompany { get; set; }

        public int IdUserFollowed { get; set; }

        public virtual Company Company { get; set; }

        public virtual User User { get; set; }
    }
}
