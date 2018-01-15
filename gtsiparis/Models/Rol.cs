namespace gtsiparis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gtadmin.Rol")]
    public partial class Rol
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rol()
        {
            Kullanici = new HashSet<ApplicationUser>();
            Lokasyon1 = new HashSet<Lokasyon>();
        }

        public int Id { get; set; }

        public string RolAdi { get; set; }

        public bool Grup { get; set; }

        public bool Lokasyon { get; set; }

        public bool Kategori { get; set; }

        public bool Urun { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationUser> Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lokasyon> Lokasyon1 { get; set; }
    }
}
