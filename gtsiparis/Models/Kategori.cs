namespace gtsiparis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gtadmin.Kategori")]
    public partial class Kategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kategori()
        {
            Urun = new HashSet<Urun>();
        }

        public int Id { get; set; }
        [DisplayName("Kategori")]
        public string KategoriAdi { get; set; }

        public bool Aktif { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedTime { get; set; }

        public int? CreatedBy_Id { get; set; }

        [DisplayName("Grup")]
        public int? Grup_Id { get; set; }
        [DisplayName("Lokasyon")]
        public int? Lokasyon_Id { get; set; }

        public virtual Grup Grup { get; set; }

        public virtual ApplicationUser Kullanici { get; set; }

        public virtual Lokasyon Lokasyon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Urun> Urun { get; set; }
    }
}
