using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mnk.Models;
using System.IO;
using System.Web.Hosting;

namespace Mnk.Controllers
{
    public class Services_detailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Services_details
        public ActionResult Index()
        {
            var services_details = db.Services_details.Include(s => s.Services);
            return View(services_details.ToList());
        }

        // GET: Services_details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services_details services_details = db.Services_details.Find(id);
            if (services_details == null)
            {
                return HttpNotFound();
            }
            return View(services_details);
        }

        // GET: Services_details/Create
        public ActionResult Create()
        {
            ViewBag.Service_Id = new SelectList(db.Servicess, "Service_Id", "Service_Name");
            return View();
        }

        // POST: Services_details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
       
        public ActionResult Create(HttpPostedFileBase doc, Services_details services_details)
        {
            if (ModelState.IsValid)
            {
                var filename = Path.GetFileName(doc.FileName);

                var extension = Path.GetExtension(filename).ToLower();
                if (extension == ".jpg" || extension == ".png")
                {
                    var path = HostingEnvironment.MapPath(Path.Combine("~/Content/Images/", filename));
                    doc.SaveAs(path);
                    services_details.Service_Detail_Image = "~/Content/Images/" + filename;
                }
                services_details.service_Status = true;
                services_details.service_Date = DateTime.Now;
                db.Services_details.Add(services_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.Service_Id = new SelectList(db.Servicess, "Service_Id", "Service_Name", services_details.Service_Id);
            return View(services_details);
        }

        // GET: Services_details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services_details services_details = db.Services_details.Find(id);
            if (services_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Service_Id = new SelectList(db.Servicess, "Service_Id", "Service_Name", services_details.Service_Id);
            return View(services_details);
        }

        // POST: Services_details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Service_Detail_Id,Service_Detail_Name,Service_Detail_Description,Service_Detail_Image,service_Status,service_Date,Service_Id")] Services_details services_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(services_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Service_Id = new SelectList(db.Servicess, "Service_Id", "Service_Name", services_details.Service_Id);
            return View(services_details);
        }

        // GET: Services_details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services_details services_details = db.Services_details.Find(id);
            if (services_details == null)
            {
                return HttpNotFound();
            }
            return View(services_details);
        }

        // POST: Services_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Services_details services_details = db.Services_details.Find(id);
            db.Services_details.Remove(services_details);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
