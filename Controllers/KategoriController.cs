using EgitimPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgitimPortal.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        EgitimPortalContext context = new EgitimPortalContext();
        public ActionResult Ekle()
        {
            
            List<Kategori> kategoriler = context.Kategoriler.Where(x => x.AktifMi == true).ToList();
            return View(kategoriler);
        }

       

        [HttpPost]
        public ActionResult Ekle(FormCollection form)
        {

            Kategori model = new Kategori();
            model.KategoriAdi = form["KategoriAdi"];
            model.KayitTarihi = DateTime.Now;
            model.AktifMi = true;
            context.Kategoriler.Add(model);
            context.SaveChanges();
            return RedirectToAction("Ekle");
        }

        public ActionResult Guncelle(int id)
        {
            var rol = context.Kategoriler.Find(id);
            return View(rol);
        }
        [HttpPost]
        public ActionResult Guncelle(FormCollection form)
        {

            int id = Convert.ToInt32(form["ID"]);
            var model = context.Kategoriler.Find(id);
            model.KategoriAdi = form["KategoriAdi"];
            context.SaveChanges();
            return RedirectToAction("Ekle");
        }

        public ActionResult Sil(int id)
        {
            
            var model = context.Kategoriler.Find(id);         
            model.AktifMi = false;
            context.SaveChanges();
            return RedirectToAction("Ekle");
        }
    }
}