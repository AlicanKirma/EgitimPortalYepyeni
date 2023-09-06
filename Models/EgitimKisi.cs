using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EgitimPortal.Models
{
    [Table("EgitimKisi")]
    public class EgitimKisi : TemelBilgiler
    {
        public int EgitimID { get; set; }
        public int KisiID { get; set; }

        

        public bool TamamlandiMi { get; set; }
    }
}