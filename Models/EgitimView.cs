using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EgitimPortal.Models
{
    public class EgitimView
    {
        public int ID { get; set; }
        public string EgitimAdi { get; set; }
        public string KategoriAdi { get; set; }

        public DateTime BaslangicTarihi { get; set; }

        public DateTime BitisTarihi { get; set; }

        public decimal Fiyat { get; set; }

        public int GunSayisi { get; set; }

        public int Kontenjan { get; set; }

        public int KategoriID { get; set; }
    }
}