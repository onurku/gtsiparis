namespace gtsiparis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gtadmin.Ilce")]
    public partial class Ilce
    {
        public int Id { get; set; }

        public string IlceAdi { get; set; }

        public int? IL_Id { get; set; }

        public virtual IL IL { get; set; }
    }
}
