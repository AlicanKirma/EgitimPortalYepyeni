using EgitimPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgitimPortal.Controllers
{
    public class KisiController : Controller
    {
        // GET: Kisi
        EgitimPortalContext context = new EgitimPortalContext();
        public ActionResult Ekle()
        {
            List<Kisi> kisiler = context.Kisiler.Where(x => x.AktifMi == true).ToList();
            return View(kisiler);
        }

        [HttpPost]
        public ActionResult Ekle(FormCollection form)
        {
            Kisi model = new Kisi();
            model.Ad = form["Adi"];
            model.Soyad = form["Soyadi"];
            model.KayitTarihi = DateTime.Now;
            model.DogumTarihi = Convert.ToDateTime(form["Tarih"]);
            model.AktifMi = true;
            model.Sifre = form["Sifre"];
            model.EPosta = form["EPosta"];
            model.AdminMi = false;
            context.Kisiler.Add(model);
            context.SaveChanges();
            return RedirectToAction("Ekle");
        }

        public ActionResult Guncelle(int id)
        {
            var kisi = context.Kisiler.Find(id);
            return View(kisi);
        }
        [HttpPost]
        public ActionResult Guncelle(FormCollection form)
        {

            int id = Convert.ToInt32(form["ID"]);
            var model = context.Kisiler.Find(id);
            model.Ad = form["Adi"];
            model.Soyad = form["Soyadi"];
            model.KayitTarihi = DateTime.Now;
            model.DogumTarihi = Convert.ToDateTime(form["Tarih"]);
            model.AktifMi = true;
            model.Sifre = form["Sifre"];
            model.EPosta = form["EPosta"];
            context.SaveChanges();
            return RedirectToAction("Ekle");
        }

        public ActionResult Sil(int id)
        {
            var model = context.Kisiler.Find(id);
            model.AktifMi = false;
            context.SaveChanges();
            return RedirectToAction("Ekle");
        }
    }
}