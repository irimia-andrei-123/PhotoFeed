namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JudgeInvitation")]
    public partial class JudgeInvitation
    {
        [Key]
        public int IdInvitation { get; set; }

        public int IdCompany { get; set; }

        public int IdUserInvited { get; set; }

        public int IdContest { get; set; }

        public int Accepted { get; set; }

        public virtual Company Company { get; set; }

        public virtual ContestPro ContestPro { get; set; }

        public virtual InvitationAcceptStat InvitationAcceptStat { get; set; }

        public virtual User User { get; set; }
    }
}
