using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EgitimPortal.Models
{
    public class EgitimKisiView
    {
        public int ID { get; set; }

        public bool AktifMi { get; set; }
        public string EgitimAdi { get; set; }
        public string KisiAdi{ get; set; }
    }
}