namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhotoFeedbackCategory")]
    public partial class PhotoFeedbackCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhotoFeedbackCategory()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        [Key]
        public int IdPhotoFeedbackCategory { get; set; }

        public int IdCategory { get; set; }

        public int IdPhoto { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual PhotoFeedback PhotoFeedback { get; set; }
    }
}
