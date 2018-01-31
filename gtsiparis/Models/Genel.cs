using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gtsiparis.Models
{
        public class UrunListe
        {
            public IEnumerable<Urun> UrunListesi { get; set; }
            public Pager Pager { get; set; }
        }

        public class SiparisUrun
        {
            public Urun Urun { get; set; }
            public string Mod { get; set; }
        }
}