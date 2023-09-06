using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EgitimPortal.Models
{
    [Table("EgitimEgitmen")]
    public class EgitimEgitmen : TemelBilgiler
    {
        public int EgitimID { get; set; }
        public int EgitmenID { get; set; }
    }
}