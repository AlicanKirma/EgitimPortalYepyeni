using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace EgitimPortal.Models
{
    [Table("Egitimler")]
    public class Egitim : TemelBilgiler
    {
      
        public string EgitimAdi { get; set; }

        public DateTime BaslangicTarihi { get; set; }

        public DateTime BitisTarihi { get; set; }
     
        public int Fiyat { get; set; }

        public int GunSayisi { get; set; }

        public int Kontenjan { get; set; }

        public int KategoriID { get; set; }
    }
}