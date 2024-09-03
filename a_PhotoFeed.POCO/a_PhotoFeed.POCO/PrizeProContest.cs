namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PrizeProContest")]
    public partial class PrizeProContest
    {
        [Key]
        public int IdPrize { get; set; }

        public int IdProContest { get; set; }

        public int Position { get; set; }

        [Required]
        [StringLength(255)]
        public string PositionPrize { get; set; }

        public virtual ContestPro ContestPro { get; set; }
    }
}
