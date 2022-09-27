using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Denetim_Takip_Sistemi.Models.EntityFramework;

namespace Denetim_Takip_Sistemi.Controllers
{
    
    public class SecurityController : Controller
    {
        denetimtakipsistemiVTEntities3 db = new denetimtakipsistemiVTEntities3();
        // GET: Security

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(kullanici kullanici)
        {
            string sifregiris = Sifrele.MD5Olustur(kullanici.kllnc_prl);
            var kullaniciInDb = db.kullanici.FirstOrDefault(x=>x.kllnc_epsta==kullanici.kllnc_epsta && x.kllnc_prl==sifregiris);
            if (kullaniciInDb != null)
            {
                FormsAuthentication.SetAuthCookie(kullaniciInDb.kllnc_adi, false);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz E-posta veya Parola Girdiniz.";
                return View();
            }   
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Security");
        }
    }
}