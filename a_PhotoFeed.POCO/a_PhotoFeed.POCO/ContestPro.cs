namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContestPro")]
    public partial class ContestPro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContestPro()
        {
            JudgeInvitations = new HashSet<JudgeInvitation>();
            Juries = new HashSet<Jury>();
            PhotoProContests = new HashSet<PhotoProContest>();
            PrizeProContests = new HashSet<PrizeProContest>();
            WinnerProes = new HashSet<WinnerPro>();
        }

        [Key]
        public int IdContestPro { get; set; }

        public int IdCreator { get; set; }

        [Required]
        [StringLength(255)]
        public string ContestName { get; set; }

        [Required]
        public string Description { get; set; }

        public int MaximumPictureNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public int Closed { get; set; }

        public virtual Company Company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JudgeInvitation> JudgeInvitations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jury> Juries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhotoProContest> PhotoProContests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrizeProContest> PrizeProContests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WinnerPro> WinnerProes { get; set; }
    }
}
