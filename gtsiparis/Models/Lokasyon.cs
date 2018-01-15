namespace gtsiparis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gtadmin.Lokasyon")]
    public partial class Lokasyon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lokasyon()
        {
            Grup = new HashSet<Grup>();
            Kategori = new HashSet<Kategori>();
        }

        public int Id { get; set; }
        [DisplayName("Adı")]
        public string LokasyonAdi { get; set; }
        [DisplayName("Rolü")]
        public int? Rol_Id { get; set; }
        [DisplayName("İl")]
        public int? IL_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grup> Grup { get; set; }

        public virtual IL IL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kategori> Kategori { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
