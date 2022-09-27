using Denetim_Takip_Sistemi.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;
using MailMessage = System.Net.Mail.MailMessage;

namespace Denetim_Takip_Sistemi.Controllers
{
    [AllowAnonymous]
    public class ForgotPasswordController : Controller
    {
        denetimtakipsistemiVTEntities3 db = new denetimtakipsistemiVTEntities3();
        // GET: ForgotPassword
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult KodGonder(string Email)
        {
            var sorgu = (from i in db.kullanici where i.kllnc_epsta.Equals(Email) select i).SingleOrDefault();
            if (sorgu != null)
            {
                Guid randomkey = Guid.NewGuid(); 

                sorgu.kllnc_pll_rst = randomkey.ToString().Substring(0, 5);

                db.SaveChanges();

                try
                {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    MailAddress from = new MailAddress("stajdeneme123@gmail.com");
                    MailAddress to = new MailAddress(sorgu.kllnc_epsta);
                    MailMessage msg = new MailMessage(from, to);
                    msg.IsBodyHtml = true;
                    msg.Subject = "Şifre Degiştirme İsteği Bildirimi";
                    msg.Body += "<h2>  Merhaba " + sorgu.kllnc_adi + " Şifre Degiştirme İsteğiniz Alınmıştır.  Kodunuz: " + randomkey.ToString().Substring(0, 5) + ". Sitemize girerek şifrenizi Güncelleyebilirsiniz. </h2>  </br>  ";
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = true;
                    NetworkCredential info = new NetworkCredential("stajdeneme123@gmail.com", "Deneme123.");
                    client.Credentials = info;
                    client.Send(msg);
                }
                catch
                {
                    ViewBag.Mesaj = "Doğrulama Kodu Gönderilemedi!";
                    return View("Index");
                }
                ViewBag.Email = Email;
                return View("dogrulamakodu");
            }
            ViewBag.Mesaj = "Girdiğiniz E-posta sistemde kayıtlı bulunmamaktadır!";
            return View("Index");
        }

        public ActionResult Dogrulama(string Dogrulama)
        {
            var sorgu = (from i in db.kullanici where i.kllnc_pll_rst.Equals(Dogrulama) select i).SingleOrDefault();
            if(sorgu != null)
            {
                ViewBag.Id = sorgu.kllnc_id;
                return View("yenisifre");
            }
            ViewBag.Mesaj = "Doğrulama Kodu Yanlış!";
            return View("dogrulamakodu");
        }

        public ActionResult YeniSifre(kullanici kullanici, string ParolaTekrar, int Id)
        {
            var kullaniciModel = db.kullanici.Find(Id);

            if (kullanici.kllnc_prl == ParolaTekrar)
            {
                string sifre = Sifrele.MD5Olustur(kullanici.kllnc_prl);
                kullaniciModel.kllnc_prl = sifre;
                db.Entry(kullaniciModel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Login", "Security");
            }
            ViewBag.Mesaj = "Şifreler eşleşmiyor. Lütfen tekrar deneyiniz";
            return View("yenisifre");
        }
    }
    
}