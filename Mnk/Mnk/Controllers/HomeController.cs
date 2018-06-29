using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mnk.Models;

namespace Mnk.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.Current = "current";
            ViewBag.message = TempData["message2"];
            return View(db.Contact_us.ToList());
        }

        public ActionResult Gallery()
        {
            ViewBag.GalleryCurrent = "current";
            return View(db.Galleries.ToList());

        }
        
        public ActionResult Real_Estate()
        {
            ViewBag.RealCurrent = "current";


            return View();
        } 

        public ActionResult About()
        {
            ViewBag.AboutCurrent = "current";
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact ()
        {
            ViewBag.ContactCurrent = "current";
            ViewBag.message = TempData["message"];
            return View();
        } 

        [HttpPost]
        
        public ActionResult Contact(Contact_us Contact_us)
        {
            if (ModelState.IsValid)
            {
                db.Contact_us.Add(Contact_us);
                db.SaveChanges();
                TempData["message"] = "Your Message Sent Successfully";
               
                return RedirectToAction("Contact");
            }

            return View(Contact_us);
        }

        [HttpPost]

        public ActionResult Contact2(Contact_us Contact_us)
        {
            if (ModelState.IsValid)
            {
                db.Contact_us.Add(Contact_us);
                db.SaveChanges();
                TempData["message2"] = "Your Message Sent Successfully";

                return RedirectToAction("Index");
            }

            return View(Contact_us);
        }



    }
}