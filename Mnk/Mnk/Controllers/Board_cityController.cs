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
    public class Board_cityController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Board_city
        public ActionResult Index()
        {
            return View(db.Board_city.ToList());
        }

        // GET: Board_city/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board_city board_city = db.Board_city.Find(id);
            if (board_city == null)
            {
                return HttpNotFound();
            }
            return View(board_city);
        }

        // GET: Board_city/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Board_city/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Board_City_Id,Board_City_name,Board_City_Status,Board_City_Date")] Board_city board_city)
        {
            board_city.Board_City_Status = true;
            board_city.Board_City_Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Board_city.Add(board_city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(board_city);
        }

        // GET: Board_city/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board_city board_city = db.Board_city.Find(id);
            if (board_city == null)
            {
                return HttpNotFound();
            }
            return View(board_city);
        }

        // POST: Board_city/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Board_City_Id,Board_City_name,Board_City_Status,Board_City_Date")] Board_city board_city)
        {
            if (ModelState.IsValid)
            {
                board_city.Board_City_Date = DateTime.Now;
                db.Entry(board_city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(board_city);
        }

        // GET: Board_city/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board_city board_city = db.Board_city.Find(id);
            if (board_city == null)
            {
                return HttpNotFound();
            }
            return View(board_city);
        }

        // POST: Board_city/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Board_city board_city = db.Board_city.Find(id);
            db.Board_city.Remove(board_city);
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
