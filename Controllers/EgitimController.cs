using EgitimPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgitimPortal.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        EgitimPortalContext context = new EgitimPortalContext();
        public ActionResult Ekle()
        {
           
            dynamic model = new System.Dynamic.ExpandoObject();
            //List<Egitim> egitimler = context.Egitimler.Where(x => x.AktifMi == true).ToList();
            List<Kategori> kategoriler = context.Kategoriler.Where(x => x.AktifMi == true).ToList();
            var sorgu = from e in context.Egitimler
                        join k in context.Kategoriler
                        on e.KategoriID equals k.ID
                        select new  EgitimView {ID= e.ID , EgitimAdi= e.EgitimAdi,
                                     BaslangicTarihi = e.BaslangicTarihi,
                                     BitisTarihi = e.BitisTarihi,Fiyat = e.Fiyat,
                            GunSayisi = e.GunSayisi,Kontenjan = e.Kontenjan,KategoriAdi = k.KategoriAdi };
            model.Egitim =sorgu;
            model.Kategoriler = kategoriler;
            return View(model);
          
        }
      
        [HttpPost]
        public ActionResult Ekle(FormCollection form)
        {

            Egitim model = new Egitim();
            model.EgitimAdi = form["EgitimAdi"];
            model.BaslangicTarihi = Convert.ToDateTime(form["BasTarih"]);
            model.BitisTarihi = Convert.ToDateTime(form["BitTarih"]);
            model.Fiyat = Convert.ToInt32(form["Fiyat"]);
            model.KayitTarihi = DateTime.Now;
            model.GunSayisi = Convert.ToInt32(form["GunSayisi"]);
            model.AktifMi = true;
            model.Kontenjan = Convert.ToInt32(form["Kontenjan"]);
            context.Egitimler.Add(model);
            context.SaveChanges();
            return RedirectToAction("Ekle");
        }

        public ActionResult Guncelle(int id)
        {
            dynamic model = new System.Dynamic.ExpandoObject();
            List<Kategori> kategoriler = context.Kategoriler.Where(x => x.AktifMi == true).ToList();
            var egitim = context.Egitimler.Find(id);
            model.Egitim = egitim;
            model.Kategoriler = kategoriler;
            return View(model);
        }

        [HttpPost]
        public ActionResult Guncelle(FormCollection form)
        {

            int id = Convert.ToInt32(form["ID"]);
            var model = context.Egitimler.Find(id);
            model.EgitimAdi = form["EgitimAdi"];
            model.BaslangicTarihi = Convert.ToDateTime(form["BasTarih"]);
            model.BitisTarihi = Convert.ToDateTime(form["BitTarih"]);
            model.Fiyat = Convert.ToInt32(form["Fiyat"]);
            model.KayitTarihi = DateTime.Now;
            model.GunSayisi = Convert.ToInt32(form["GunSayisi"]);
            model.AktifMi = true;
            model.Kontenjan = Convert.ToInt32(form["Kontenjan"]);
           
            context.SaveChanges();
            return RedirectToAction("Ekle");
        }

        public ActionResult Sil(int id)
        {

            var model = context.Egitimler.Find(id);
            model.AktifMi = false;
            context.SaveChanges();
            return RedirectToAction("Ekle");
        }
    }
}