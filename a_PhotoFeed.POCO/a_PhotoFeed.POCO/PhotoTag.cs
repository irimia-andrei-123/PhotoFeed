namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhotoTag")]
    public partial class PhotoTag
    {
        [Key]
        public int IdPhotoTag { get; set; }

        public int IdTag { get; set; }

        public int IdPhoto { get; set; }

        public virtual PhotoUser PhotoUser { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
