
using EgitimPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EgitimPortal.Controllers
{
    [AllowAnonymous]
    public class GuvenlikController : Controller
    {
        // GET: Guvenlik
        EgitimPortalContext context = new EgitimPortalContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string eposta = form["Eposta"];
            string sifre = form["Sifre"];
            var model = context.Kisiler.FirstOrDefault(x => x.EPosta == eposta && x.Sifre == sifre);
            if (model != null)
            {
                string adsoyad = model.Ad + " " + model.Soyad;
                FormsAuthentication.SetAuthCookie(adsoyad, true);
                Session["AdSoyad"] = model.Ad+" "+ model.Soyad;
                Session["AdminMi"] = model.AdminMi.ToString();
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.Mesaj = "Hatalı posta veya şifre";
                return View();
            };

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }

    }
}