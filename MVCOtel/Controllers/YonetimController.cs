using MVCOtel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Configuration;

namespace MVCOtel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class YonetimController : Controller
    {
        // GET: Yonetim
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet] //formu göster
        public ActionResult SliderEkle()
        {
            ViewBag.OlmayanResimYolu = ConfigurationManager.AppSettings["olmayanresim"];
            return View();
        }
        [HttpPost] //formu kaydet
        public ActionResult SliderEkle(SliderM s, HttpPostedFileBase resim)
        {
            if (resim != null && resim.ContentLength > 0)
            {
                s.ResimYolu = resim.FileName;
                string yol = Server.MapPath("/Content/slider/");
                yol += resim.FileName;
                if (System.IO.File.Exists(yol)) //dosyaadı varsa
                    yol.Replace(resim.FileName, Guid.NewGuid().ToString() + ".jpg");
                resim.SaveAs(yol);
            }

            if (ModelState.IsValid)
            {
                ApplicationDbContext ctx = new ApplicationDbContext();
                ctx.Sliderlar.Add(s);
                ctx.SaveChanges();
                return RedirectToAction("SliderListe");
            }
            return View();
        }

        public ActionResult SliderListe()
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            return View(ctx.Sliderlar.ToList());
        }

        public ActionResult SliderSil(int id) {
            ApplicationDbContext ctx = new ApplicationDbContext();
            var silinecek = ctx.Sliderlar.Find(id);
            ctx.Sliderlar.Remove(silinecek);
            ctx.SaveChanges();
            return RedirectToAction("SliderListe");
        }

        public ActionResult OdaSil(int id)
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            var silinecek = ctx.Odalar.Find(id);
            ctx.Odalar.Remove(silinecek);
            ctx.SaveChanges();
            return RedirectToAction("OdaListele");
        }



        [HttpGet]
        public ActionResult OdaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OdaEkle(OdaM oda, HttpPostedFileBase resim)
        {

            if (resim!=null && resim.ContentLength > 0)
            {
                oda.ResimURL = resim.FileName;
                string yol = Server.MapPath("/Content/oda/");
                resim.SaveAs(yol + resim.FileName);
            }
            if (ModelState.IsValid)
            {
                ApplicationDbContext ctx = new ApplicationDbContext();
                ctx.Odalar.Add(oda);
                ctx.SaveChanges();
                return RedirectToAction("OdaListele");
            }
            return View();
        }

        public ActionResult OdaListele()
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            return View(ctx.Odalar.ToList());
        }
        [HttpGet]
        public ActionResult OdaDuzenle(int? id)
        {
            if (id == null)
            {
                ViewBag.mesaj = "Bir oda seçmediniz, id bekleniyor";
                return View();
            } else
            {
                ApplicationDbContext ctx = new ApplicationDbContext();
                var oda = ctx.Odalar.Find(id);
                return View(oda);
            }
        }
        [HttpPost]
        public ActionResult OdaDuzenle(OdaM oda, HttpPostedFileBase resim)
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            var eski = ctx.Odalar.Find(oda.OdaMID);
            var klasor = Server.MapPath("/Content/oda/");
            //eğer resim yüklenmişse
            if (resim !=null && resim.ContentLength > 0)
            {
                //eski resim silinmeli
                if (string.IsNullOrEmpty(eski.ResimURL))
                    System.IO.File.Delete(klasor + eski.ResimURL);
                //kayıt edilmeli
                resim.SaveAs(klasor + resim.FileName);
                //modeldeki url değişmeli
                oda.ResimURL = resim.FileName;
            }
            else
            { //resim yüklenmemişse
                oda.ResimURL = eski.ResimURL;
              //eski resmi kaybetmemeliyiz
            }
            if (ModelState.IsValid) {
                //oda detayları kayıt edilmeli
                ctx.Entry(oda).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("OdaListele");
            }
            return View(oda);
        }
    }
}