namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserSpecialization")]
    public partial class UserSpecialization
    {
        public int Id { get; set; }

        public int IdUserSpec { get; set; }

        public int IdSpecialization { get; set; }

        public virtual Specialization Specialization { get; set; }

        public virtual User User { get; set; }
    }
}
