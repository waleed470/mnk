using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mnk.Models;

namespace Mnk.Controllers
{
    public class Board_mediumController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Board_medium
        public ActionResult Index()
        {
            return View(db.Board_medium.ToList());
        }

        // GET: Board_medium/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board_medium board_medium = db.Board_medium.Find(id);
            if (board_medium == null)
            {
                return HttpNotFound();
            }
            return View(board_medium);
        }

        // GET: Board_medium/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Board_medium/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Board_Medium_Id,Board_Medium_name,Board_Medium_Status,Board_Medium_Date")] Board_medium board_medium)
        {
            if (ModelState.IsValid)
            {
                board_medium.Board_Medium_Status = true;
                board_medium.Board_Medium_Date = DateTime.Now;
                db.Board_medium.Add(board_medium);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(board_medium);
        }

        // GET: Board_medium/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board_medium board_medium = db.Board_medium.Find(id);
            if (board_medium == null)
            {
                return HttpNotFound();
            }
            return View(board_medium);
        }

        // POST: Board_medium/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Board_Medium_Id,Board_Medium_name,Board_Medium_Status,Board_Medium_Date")] Board_medium board_medium)
        {
            if (ModelState.IsValid)
            {
                board_medium.Board_Medium_Date = DateTime.Now;
                db.Entry(board_medium).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(board_medium);
        }

        // GET: Board_medium/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board_medium board_medium = db.Board_medium.Find(id);
            if (board_medium == null)
            {
                return HttpNotFound();
            }
            return View(board_medium);
        }

        // POST: Board_medium/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Board_medium board_medium = db.Board_medium.Find(id);
            db.Board_medium.Remove(board_medium);
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
