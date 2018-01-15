namespace gtsiparis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gtadmin.Grup")]
    public partial class Grup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grup()
        {
            Kategori = new HashSet<Kategori>();
            Indeks = new HashSet<GrupIndeksi>();
            Urun = new HashSet<Urun>();
        }

        public int Id { get; set; }
        [DisplayName("Grup Adı")]
        public string GrupAdi { get; set; }
        [DisplayName("Lokasyon")]
        public int? Lokasyon_Id { get; set; }

        public virtual Lokasyon Lokasyon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kategori> Kategori { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrupIndeksi> Indeks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Urun> Urun { get; set; }

        public static implicit operator Grup(HashSet<Grup> v)
        {
            throw new NotImplementedException();
        }
    }
}
