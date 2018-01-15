using System.Collections.Generic;

namespace gtsiparis.Models
{
    public interface SiparisViewModel
    {
        IEnumerable<Kategori> KategoriItems { get; set; }
        IEnumerable<Siparis> SiparisItems { get; set; }
        IEnumerable<Urun> UrunItems { get; set; }
    }
}