namespace gtsiparis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gtadmin.Menu")]
    public partial class Menu
    {
        public int Id { get; set; }

        public string MenuAdi { get; set; }

        public string MenuController { get; set; }

        public string MenuLink { get; set; }
    }
}
