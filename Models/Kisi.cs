using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EgitimPortal.Models
{

    [Table("Kisiler")]
    public class Kisi : TemelBilgiler
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public string EPosta { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Sifre { get; set; }

        public bool AdminMi { get; set; }
    }
}