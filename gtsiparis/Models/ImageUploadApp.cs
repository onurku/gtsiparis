using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gtsiparis.Models
{
    [Table("gtadmin.Gorsel")]
    public partial class Image
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
    }
}