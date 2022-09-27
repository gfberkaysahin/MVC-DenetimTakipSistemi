using Denetim_Takip_Sistemi.Models.EntityFramework;
using Denetim_Takip_Sistemi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Denetim_Takip_Sistemi.Controllers
{
    public class HomeController : Controller
    {
        denetimtakipsistemiVTEntities3 db = new denetimtakipsistemiVTEntities3();
        
        // GET: Home
        public ActionResult Index()
        {
            var belge = new BelgeFormViewModel()
            {
                Belge_Tipi = db.belge_tipi.ToList()
            };
            var belgeListe = db.belge.ToList();
            return View(Tuple.Create<kullanici,BelgeFormViewModel,belge_tipi,List<belge>>(new kullanici(), belge,new belge_tipi(),belgeListe));
        }

        [Route("takvim")]
        public ActionResult Takvim()
        {
            var belge = new BelgeFormViewModel()
            {
                Belge_Tipi = db.belge_tipi.ToList()
            };
            var belgeListe = db.belge.ToList();
            return View(Tuple.Create<kullanici, BelgeFormViewModel, belge_tipi,List<belge>>(new kullanici(), belge, new belge_tipi(), belgeListe));
        }

        public JsonResult KullaniciDuzenle(int id)
        {
            var kullaniciModel = db.kullanici.Find(id);
            var kullaniciJson = new
            {
                kllnc_kllncad = kullaniciModel.kllnc_kllncad,
                kllnc_adi = kullaniciModel.kllnc_adi,
                kllnc_kmlk_no = kullaniciModel.kllnc_kmlk_no,
                kllnc_dgm_trh = kullaniciModel.kllnc_dgm_trh,
                kllnc_epsta = kullaniciModel.kllnc_epsta,
                kllnc_cep_tel = kullaniciModel.kllnc_cep_tel,
                kllnc_id = kullaniciModel.kllnc_id,
                kllnc_prl = kullaniciModel.kllnc_prl,
                kllnc_rol = kullaniciModel.kllnc_rol,
                kllnc_eklyn_kllnc = kullaniciModel.kllnc_eklyn_kllnc,
                kllnc_eklnm_trh = kullaniciModel.kllnc_eklnm_trh,
                kllnc_gncllnm_trh = kullaniciModel.kllnc_gncllnm_trh,
                kllnc_gnclln_kllnc = kullaniciModel.kllnc_gnclln_kllnc,
            };
            return Json(kullaniciJson, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BelgeTipiDuzenle(int id)
        {
            var belgetipiModel = db.belge_tipi.Find(id);
            var belge_tipiJson = new
            {
                belge_tipi_tipi = belgetipiModel.belge_tipi_tipi,
                belge_tipi_durum = belgetipiModel.belge_tipi_durum,
                belge_tipi_acklm = belgetipiModel.belge_tipi_acklm,
                belge_tipi_id = belgetipiModel.belge_tipi_id,
                belge_tipi_eklnm_trh = belgetipiModel.belge_tipi_eklnm_trh,
                belge_tipi_eklyn_kllnc = belgetipiModel.belge_tipi_eklyn_kllnc,
                belge_tipi_gncllnm_trh = belgetipiModel.belge_tipi_gncllnm_trh,
                belge_tipi_gncllyn_kllnc = belgetipiModel.belge_tipi_gncllyn_kllnc,

            };
            return Json(belge_tipiJson, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BelgeDuzenle(int id)
        {
            var belgeModel = new BelgeFormViewModel()
            {
                Belge_Tipi = db.belge_tipi.ToList(),
                Belge = db.belge.Find(id)
            };
            var belgeJson = new
            {
                belge_id = belgeModel.Belge.belge_id,
                belge_belge_tipi_id = belgeModel.Belge.belge_belge_tipi_id,
                belge_adi = belgeModel.Belge.belge_adi,
                belge_durum = belgeModel.Belge.belge_durum,
                belge_acklm = belgeModel.Belge.belge_acklm,
                belge_eklnm_trh = belgeModel.Belge.belge_eklnm_trh,
                belge_eklyn_kllnc = belgeModel.Belge.belge_eklyn_kllnc,
                belge_gncllnm_trh = belgeModel.Belge.belge_gncllnm_trh,
                belge_gncllyn_kllnc = belgeModel.Belge.belge_gncllyn_kllnc,
            };
            return Json(belgeJson, JsonRequestBehavior.AllowGet);
        }

        public JsonResult KullaniciTanim()
        {
            var KullaniciData = db.kullanici.ToList();
            return Json(
                new
                { 
                    Result = from obj in KullaniciData
                             select new 
                             {
                                obj.kllnc_kllncad,
                                obj.kllnc_adi,
                                obj.kllnc_epsta,
                                obj.kllnc_kmlk_no,
                                obj.kllnc_eklyn_kllnc,
                                obj.kllnc_eklnm_trh,
                                obj.kllnc_id,
                                obj.kllnc_gnclln_kllnc,
                                obj.kllnc_gncllnm_trh,
                             }
                },JsonRequestBehavior.AllowGet);
        }

        public JsonResult BelgeTipiTanim()
        {
            var BelgeTipiData = db.belge_tipi.ToList();
            return Json(
                new
                {
                    BResult = from obj in BelgeTipiData
                             select new
                             {
                                 obj.belge_tipi_tipi,
                                 obj.belge_tipi_durum,
                                 obj.belge_tipi_acklm,
                                 obj.belge_tipi_eklyn_kllnc,
                                 obj.belge_tipi_eklnm_trh,
                                 obj.belge_tipi_gncllnm_trh,
                                 obj.belge_tipi_gncllyn_kllnc,
                                 obj.belge_tipi_id,

                             }
                }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult KullaniciSil(int id)
        {
            var kullaniciSil = db.kullanici.Find(id);
            if (kullaniciSil == null)
                return Json("0");
            db.kullanici.Remove(kullaniciSil);
            db.SaveChanges();
            return Json("1");
        }

        public JsonResult Belge_TipiSil(int id)
        {
            var belge_tipiSil = db.belge_tipi.Find(id);
            var belgeKontrol = db.belge.ToList();
            foreach (var kontrol in belgeKontrol)
            {
                if (kontrol.belge_belge_tipi_id == belge_tipiSil.belge_tipi_id)
                {
                    return Json("-1");
                }
            }
            if (belge_tipiSil == null)
                return Json("0");
            db.belge_tipi.Remove(belge_tipiSil);
            db.SaveChanges();
            return Json("1");
        }


        [ValidateAntiForgeryToken]
        public ActionResult KullaniciTanimKaydet([Bind(Prefix = "Item1")]kullanici kullanici)
        {
            if (!ModelState.IsValid)
            {
                return Content("Form değerleri geçerli değil");
            }

            string sifre = Sifrele.MD5Olustur(kullanici.kllnc_prl);

            if (kullanici.kllnc_id == 0)
            {
                kullanici.kllnc_prl = sifre;
                db.kullanici.Add(kullanici);
            }
            else
            {
                kullanici.kllnc_prl = sifre;
                db.Entry(kullanici).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            var durum = db.SaveChanges();
            if (durum > 0)
            {
                return Content("Değişiklikler kaydedilemedi!");
            }
            else return View("_KullaniciMesaj");
        }

        [ValidateAntiForgeryToken]
        public ActionResult BelgeTanimKaydet([Bind(Prefix = "Item2.Belge")] belge belge)
        {
            var belgeAd = belge.belge_adi;
            if (!ModelState.IsValid)
            {
                return Content("Form değerleri geçerli değil");
            }
            if (belge.belge_id == 0)
            {
                db.belge.Add(belge);
            }
            else
            {
                db.Entry(belge).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            var durum = db.SaveChanges();
            if (durum > 0)
            {
                return Content("Değişiklikler kaydedilemedi!");
            }
            else
            {
                var sorgu = (from i in db.belge where i.belge_adi.Equals(belgeAd) select i).SingleOrDefault();
                ViewBag.BelgeId = sorgu.belge_id;
                return View("_KullaniciMesaj");
            }
        }

        [ValidateAntiForgeryToken]
        public ActionResult Belge_TipiTanimKaydet([Bind(Prefix = "Item3")] belge_tipi belge_tipi)
        {
            if (!ModelState.IsValid)
            {
                return Content("Form değerleri geçerli değil");
            }
            if (belge_tipi.belge_tipi_id == 0)
            {
                db.belge_tipi.Add(belge_tipi);
            }
            else
            {
                db.Entry(belge_tipi).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            var durum = db.SaveChanges();
            if (durum > 0)
            {
                return Content("Değişiklikler kaydedilemedi!");
            }
            else return View("_KullaniciMesaj");
        }

        [ValidateAntiForgeryToken]
        public ActionResult DosyaKaydet([Bind(Prefix = "Item2.Dosya")] dosya_bilgisi dosya_bilgisi)
        {
            if (!ModelState.IsValid)
            {
                return Content("Form değerleri geçerli değil");
            }
            if(dosya_bilgisi.dosya_blgs_belge_id == 0)
            {
                return Content("Lütfen Öncelikle Belge Bilgilerini Giriniz!");
            }
            if (dosya_bilgisi.dosya_blgs_id == 0)
            {
                db.dosya_bilgisi.Add(dosya_bilgisi);
            }
            else
            {
                db.Entry(dosya_bilgisi).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            var durum = db.SaveChanges();
            if (durum > 0)
            {
                return Content("Değişiklikler kaydedilemedi!");
            }
            else 
            {
                ViewBag.BId = dosya_bilgisi.dosya_blgs_belge_id;
                var dosyaListeleme = db.dosya_bilgisi.ToList();
                return View("_DosyaListe", dosyaListeleme); 
            }
        }


    }
}