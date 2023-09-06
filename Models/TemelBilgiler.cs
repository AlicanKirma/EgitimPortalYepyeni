using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EgitimPortal.Models
{
    public abstract class TemelBilgiler
    {
        public int ID { get; set; }
        public bool AktifMi { get; set; }

        public DateTime KayitTarihi { get; set; }
    }
}