namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FollowUserCategory")]
    public partial class FollowUserCategory
    {
        [Key]
        public int IdFollow { get; set; }

        public int IdUser { get; set; }

        public int IdCategoryFollowed { get; set; }

        public virtual Category Category { get; set; }

        public virtual User User { get; set; }
    }
}
