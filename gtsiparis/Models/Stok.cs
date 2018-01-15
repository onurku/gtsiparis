using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace gtsiparis
{
    [Table("gtadmin.Stok")]
    public partial class Stok
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        [Key]
        public int Id { get; set; }
         
        [DisplayName("Ürün")]
        public int? UrunId { get; set; }
        public virtual Urun Urun { get; set; }

        [DisplayName("Son Stok")]
        [DataType(DataType.Currency)]
        public decimal SonStok { get; set;}

        [DisplayName("Miktarı")]
        [DataType(DataType.Currency)]
        public decimal Miktar { get; set; }

        [DisplayName("Girdi / Çıktı")]
        public bool GirdiCikti { get; set; }

        [DisplayName("Tarih")]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Tarih { get; set; }




    }
}