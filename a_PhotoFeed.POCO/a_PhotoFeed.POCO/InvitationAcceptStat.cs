namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InvitationAcceptStat")]
    public partial class InvitationAcceptStat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvitationAcceptStat()
        {
            JudgeInvitations = new HashSet<JudgeInvitation>();
        }

        [Key]
        public int IdInvitationAccept { get; set; }

        [Required]
        [StringLength(255)]
        public string AcceptStat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JudgeInvitation> JudgeInvitations { get; set; }
    }
}
