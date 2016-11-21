using MVCOtel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOtel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Slider()
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            return View(ctx.Sliderlar.OrderBy(x=>x.Sira).ToList());
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ActionSection()
        {
            return View();
        }

        public ActionResult OurTeam()
        {
            return View();
        }

        public ActionResult Testimonial()
        {
            return View();
        }

        public ActionResult Portfolio()
        {
            return View();
        }

        public ActionResult Pricing() //odalar
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            return View(ctx.Odalar.OrderBy(x=>x.Fiyat).ToList());
        }
        public ActionResult Business()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

    }
}