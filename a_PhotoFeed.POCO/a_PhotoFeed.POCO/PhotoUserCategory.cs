namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhotoUserCategory")]
    public partial class PhotoUserCategory
    {
        [Key]
        public int IdPhotoUserCategory { get; set; }

        public int IdCategory { get; set; }

        public int IdPhoto { get; set; }

        public virtual Category Category { get; set; }

        public virtual PhotoUser PhotoUser { get; set; }
    }
}
