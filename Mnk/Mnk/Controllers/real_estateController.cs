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
    public class real_estateController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: real_estate
        public ActionResult Index()
        {
            return View(db.real_estate.ToList());
        }

        // GET: real_estate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            real_estate real_estate = db.real_estate.Find(id);
            if (real_estate == null)
            {
                return HttpNotFound();
            }
            return View(real_estate);
        }

        // GET: real_estate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: real_estate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( real_estate real_estate , HttpPostedFileBase doc)
        {
            if (ModelState.IsValid)
            {
                var filename = Path.GetFileName(doc.FileName);

                var extension = Path.GetExtension(filename).ToLower();
                if (extension == ".jpg" || extension == ".png")
                {
                    var path = HostingEnvironment.MapPath(Path.Combine("~/Content/Images/", filename));
                    doc.SaveAs(path);
                    real_estate.real_image = "~/Content/Images/" + filename;
                }
                real_estate.real_status = true;
                 real_estate.real_date = DateTime.Now;



                db.real_estate.Add(real_estate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(real_estate);
        }

        // GET: real_estate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            real_estate real_estate = db.real_estate.Find(id);
            if (real_estate == null)
            {
                return HttpNotFound();
            }
            return View(real_estate);
        }

        // POST: real_estate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase doc , real_estate real_estate)
        {
            if (ModelState.IsValid)
            {
                real_estate real_estate_update = db.real_estate.Find(real_estate.real_id);
                real_estate_update.real_name = real_estate.real_name;
                real_estate_update.real_discription = real_estate.real_discription;
                real_estate_update.real_status = real_estate.real_status;

                if (doc != null)
                {
                    var filename = Path.GetFileName(doc.FileName);
                    var extension = Path.GetExtension(filename).ToLower();
                    if (extension == ".jpg" || extension == ".png")
                    {
                        var path = HostingEnvironment.MapPath(Path.Combine("~/Content/Images/", filename));
                        doc.SaveAs(path);
                        real_estate_update.real_image = "~/Content/Images/" + filename;

                    }
                }



                db.Entry(real_estate_update).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(real_estate);
        }

        // GET: real_estate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            real_estate real_estate = db.real_estate.Find(id);
            if (real_estate == null)
            {
                return HttpNotFound();
            }
            return View(real_estate);
        }

        // POST: real_estate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            real_estate real_estate = db.real_estate.Find(id);
            db.real_estate.Remove(real_estate);
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
