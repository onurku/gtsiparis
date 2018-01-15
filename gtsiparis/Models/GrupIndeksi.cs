using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gtsiparis
{
    [Table("gtadmin.GrupIndeksi")]
    public partial class GrupIndeksi
    {
        
        [Key]
        public int Id { get; set; }

        [DisplayName("Kullanici")]
        public virtual ApplicationUser User { get; set; }

        [DisplayName("Grup")]
        public int? GrupId { get; set; }
        public virtual Grup Grup { get; set; }

    }
}