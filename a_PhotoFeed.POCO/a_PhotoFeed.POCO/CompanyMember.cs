namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompanyMember")]
    public partial class CompanyMember
    {
        [Key]
        public int IdCompanyMember { get; set; }

        public int IdUser { get; set; }

        public int IdCompany { get; set; }

        public virtual Company Company { get; set; }

        public virtual User User { get; set; }
    }
}
