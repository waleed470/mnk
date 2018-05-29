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
    public class testo_nomiaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: testo_nomia
        public ActionResult Index()
        {
            return View(db.testo_nomia.ToList());
        }

        // GET: testo_nomia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            testo_nomia testo_nomia = db.testo_nomia.Find(id);
            if (testo_nomia == null)
            {
                return HttpNotFound();
            }
            return View(testo_nomia);
        }

        // GET: testo_nomia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: testo_nomia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase doc, testo_nomia testo_nomia)
        {
            if (ModelState.IsValid)
            {
                var filename = Path.GetFileName(doc.FileName);

                var extension = Path.GetExtension(filename).ToLower();
                if (extension == ".jpg" || extension == ".png")
                {
                    var path = HostingEnvironment.MapPath(Path.Combine("~/Content/Images/", filename));
                    doc.SaveAs(path);
                    testo_nomia.Testo_nomia_image = "~/Content/Images/" + filename;
                }
                testo_nomia.testo_nomia_Date = DateTime.Now;
                db.testo_nomia.Add(testo_nomia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testo_nomia);
        }

        // GET: testo_nomia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            testo_nomia testo_nomia = db.testo_nomia.Find(id);
            if (testo_nomia == null)
            {
                return HttpNotFound();
            }
            return View(testo_nomia);
        }

        // POST: testo_nomia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase doc, testo_nomia testo_nomia)
        {
            if (ModelState.IsValid)
            {
                testo_nomia Message_update = db.testo_nomia.Find(testo_nomia.Testo_nomia_Id);
                Message_update.Testo_nomia_name = testo_nomia.Testo_nomia_name;
                Message_update.Testo_nomia_Massage = testo_nomia.Testo_nomia_Massage;

                if (doc != null)
                {
                    var filename = Path.GetFileName(doc.FileName);
                    var extension = Path.GetExtension(filename).ToLower();
                    if (extension == ".jpg" || extension == ".png")
                    {
                        var path = HostingEnvironment.MapPath(Path.Combine("~/Content/Images/", filename));
                        doc.SaveAs(path);
                        testo_nomia.Testo_nomia_image = "~/Content/Images/" + filename;

                    }
                }


                Message_update.testo_nomia_Date = DateTime.Now;


                db.Entry(Message_update).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testo_nomia);
        }

        // GET: testo_nomia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            testo_nomia testo_nomia = db.testo_nomia.Find(id);
            if (testo_nomia == null)
            {
                return HttpNotFound();
            }
            return View(testo_nomia);
        }

        // POST: testo_nomia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            testo_nomia testo_nomia = db.testo_nomia.Find(id);
            db.testo_nomia.Remove(testo_nomia);
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
