namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WinnerBasic")]
    public partial class WinnerBasic
    {
        [Key]
        public int IdAward { get; set; }

        public int IdBasicContest { get; set; }

        public int IdWinnerUser { get; set; }

        public int PositionPlaced { get; set; }

        public virtual ContestBasic ContestBasic { get; set; }

        public virtual PositionStat PositionStat { get; set; }

        public virtual User User { get; set; }
    }
}
