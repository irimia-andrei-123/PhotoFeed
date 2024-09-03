namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Jury")]
    public partial class Jury
    {
        [Key]
        public int IdJury { get; set; }

        public int IdProContest { get; set; }

        public int IdJuryUser { get; set; }

        public virtual ContestPro ContestPro { get; set; }

        public virtual User User { get; set; }
    }
}
