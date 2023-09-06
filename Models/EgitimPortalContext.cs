using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EgitimPortal.Models
{
    public class EgitimPortalContext :DbContext
    {
        public DbSet<Egitim> Egitimler { get; set; }

        public DbSet<Egitmen> Egitmenler { get; set; }
        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }

        public DbSet<EgitimEgitmen> EgitimEgitmenler { get; set; }

        public DbSet<EgitimKisi> EgitimKisiler { get; set; }

        public DbSet<EgitimTalep> EgitimTalepler { get; set; }
    }
}