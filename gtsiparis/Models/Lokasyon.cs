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
        [Key]
        public int Id { get; set; }

        [DisplayName("İl")]
        public string Il { get; set; }

        [DisplayName("İlçe")]
        public string Ilce { get; set; }

        [DisplayName("Semt/Bucak/Belde")]
        public string SemtBelde { get; set; }

        [DisplayName("Mahalle")]
        public string Mahalle { get; set; }

        [DisplayName("Posta Kodu")]
        public string PostaKodu { get; set; }

    }
}
