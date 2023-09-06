using EgitimPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgitimPortal.Controllers
{
    public class EgitmenController : Controller
    {
        // GET: Egitmen
        EgitimPortalContext context = new EgitimPortalContext();
        public ActionResult Ekle()
        {
            List<Egitmen> egitmenler = context.Egitmenler.Where(x => x.AktifMi == true).ToList();
            List<Kategori> kategoriler = context.Kategoriler.Where(x => x.AktifMi == true).ToList();
            return View(egitmenler);
        }

        [HttpPost]
        public ActionResult Ekle(FormCollection form)
        {
            Egitmen model = new Egitmen();
            model.Ad = form["Adi"];
            model.Soyad = form["Soyadi"];
            model.KayitTarihi = DateTime.Now;
            model.DogumTarihi = Convert.ToDateTime(form["Tarih"]);
            model.AktifMi = true;
            context.Egitmenler.Add(model);
            context.SaveChanges();
            return RedirectToAction("Ekle");
        }

        public ActionResult Guncelle(int id)
        {
            var kisi = context.Egitmenler.Find(id);
            return View(kisi);
        }
        [HttpPost]
        public ActionResult Guncelle(FormCollection form)
        {

            int id = Convert.ToInt32(form["ID"]);
            var model = context.Egitmenler.Find(id);
            model.Ad = form["Adi"];
            model.Soyad = form["Soyadi"];
            model.KayitTarihi = DateTime.Now;
            model.DogumTarihi = Convert.ToDateTime(form["Tarih"]);
            context.SaveChanges();
            return RedirectToAction("Ekle");
        }

        public ActionResult Sil(int id)
        {
            var model = context.Egitmenler.Find(id);
            model.AktifMi = false;
            context.SaveChanges();
            return RedirectToAction("Ekle");
        }
    }
}