using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EgitimPortal.Models
{
    [Table("Kategori")]
    public class Kategori : TemelBilgiler
    {
        public string KategoriAdi { get; set; }
    }
}