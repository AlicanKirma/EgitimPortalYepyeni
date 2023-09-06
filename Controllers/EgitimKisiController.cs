using EgitimPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgitimPortal.Controllers
{
    public class EgitimKisiController : Controller
    {
        // GET: EgitimKisi
        // GET: EgitimEgitmen
        EgitimPortalContext context = new EgitimPortalContext();
        public ActionResult Ekle()
        {
            dynamic model = new System.Dynamic.ExpandoObject();
            List<Egitim> egitimler = context.Egitimler.Where(x => x.AktifMi == true).ToList();
            List<Kisi> kisiler = context.Kisiler.Where(x => x.AktifMi == true).ToList();
            model.Egitimler = egitimler;
            model.Kisiler =kisiler;
            var sorgu = from e in context.EgitimKisiler
                        join e1 in context.Egitimler
                        on e.EgitimID equals e1.ID
                        join e2 in context.Kisiler

                         on e.KisiID equals e2.ID
                        select new EgitimKisiView
                        {
                            ID = e.ID,
                            AktifMi = e.AktifMi,
                            EgitimAdi = e1.EgitimAdi,

                            KisiAdi = e2.Ad
                        };

            model.Liste = sorgu.Where(x => x.AktifMi == true);
            return View(model);
        }

        [HttpPost]
        public ActionResult Ekle(FormCollection form)
        {

            EgitimKisi model = new EgitimKisi();
            model.EgitimID = Convert.ToInt32(form["Egitim"]);
            model.KisiID = Convert.ToInt32(form["Kisi"]);
            model.KayitTarihi = DateTime.Now;
            model.AktifMi = true;
            context.EgitimKisiler.Add(model);
            context.SaveChanges();
            return RedirectToAction("Ekle");
        }

        public ActionResult Sil(int id)
        {

            var model = context.EgitimKisiler.Find(id);
            model.AktifMi = false;
            context.SaveChanges();
            return RedirectToAction("Ekle");
        }
    }
}