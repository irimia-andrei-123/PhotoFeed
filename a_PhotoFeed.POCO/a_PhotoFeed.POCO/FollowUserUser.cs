namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FollowUserUser")]
    public partial class FollowUserUser
    {
        [Key]
        public int IdFollow { get; set; }

        public int IdUser { get; set; }

        public int IdUserFollowed { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
