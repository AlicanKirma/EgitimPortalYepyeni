using EgitimPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgitimPortal.Controllers
{
    public class EgitimEgitmenController : Controller
    {
        // GET: EgitimEgitmen
        EgitimPortalContext context = new EgitimPortalContext();
        public ActionResult Ekle()
        {
            dynamic model = new System.Dynamic.ExpandoObject();
            List<Egitim> egitimler = context.Egitimler.Where(x => x.AktifMi == true).ToList();
            List<Egitmen> egitmenler = context.Egitmenler.Where(x => x.AktifMi == true).ToList();
            model.Egitimler = egitimler;
            model.Egitmenler = egitmenler;
            var sorgu = from e in context.EgitimEgitmenler
                        join e1 in context.Egitimler
                        on e.EgitimID equals e1.ID
                        join e2 in context.Egitmenler
                        
                         on e.EgitmenID equals e2.ID 
                        select new EgitimEgitmenView
                        {
                            ID = e.ID,
                            AktifMi = e.AktifMi,
                            EgitimAdi = e1.EgitimAdi,
                           
                            EgitmenAdi = e2.Ad
                        };
           
            model.Liste = sorgu.Where(x => x.AktifMi == true);
            return View(model);
        }

        [HttpPost]
        public ActionResult Ekle(FormCollection form)
        {

            EgitimEgitmen model = new EgitimEgitmen();
            model.EgitimID = Convert.ToInt32(form["Egitim"]);
            model.EgitmenID = Convert.ToInt32(form["Egitmen"]);
            model.KayitTarihi = DateTime.Now;
            model.AktifMi = true;
            context.EgitimEgitmenler.Add(model);
            context.SaveChanges();
            return RedirectToAction("Ekle");
        }

        public ActionResult Sil(int id)
        {

            var model = context.EgitimEgitmenler.Find(id);
            model.AktifMi = false;
            context.SaveChanges();
            return RedirectToAction("Ekle");
        }
    }
}