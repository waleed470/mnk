using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mnk.Models;
using System.Runtime.Remoting.Contexts;

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

        public ActionResult dashboard ()
        {
           
            return View();
        }


        public ActionResult Gallery()
        {
            ViewBag.GalleryCurrent = "current";
            return View(db.Galleries.ToList());

        }

        public ActionResult Real_Estatee()
        {
            var maxid = db.real_estate.Max(m => m.real_id);
            real_estate real = db.real_estate.Find(maxid);
            ViewBag.message = TempData["message"];
            return View(real);
        }
    
        public ActionResult Real_Estat(int id)
        {
            real_estate real = db.real_estate.Where(m => m.real_id == id).SingleOrDefault();
            ViewBag.RealCurrent = "current";
            ViewBag.Current1 = id;
            return View(real);
        }
        
       
        public ActionResult Real_Form(real_form real_form)
        {
            if (ModelState.IsValid)
            {  
                db.real_form.Add(real_form);
                db.SaveChanges();
                TempData["message"] = "Your Message Sent Successfully!";
                return RedirectToAction("Real_Estatee");
            }

            return View(real_form);
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