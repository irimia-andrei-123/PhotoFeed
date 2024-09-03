namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhotoFeedback")]
    public partial class PhotoFeedback
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhotoFeedback()
        {
            PhotoFeedbackCategories = new HashSet<PhotoFeedbackCategory>();
        }

        [Key]
        public int IdPhotoFeedback { get; set; }

        public int IdUser { get; set; }

        public int Copyrighted { get; set; }

        [Required]
        public string Photo { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime DatePosted { get; set; }

        public virtual CopyrightStat CopyrightStat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhotoFeedbackCategory> PhotoFeedbackCategories { get; set; }

        public virtual User User { get; set; }
    }
}
