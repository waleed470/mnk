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
    public class Board_LocationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Board_Location
        public ActionResult Index()
        {
            return View(db.Boards_Locations.ToList());
        }

        // GET: Board_Location/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board_Location board_Location = db.Boards_Locations.Find(id);
            if (board_Location == null)
            {
                return HttpNotFound();
            }
            return View(board_Location);
        }

        // GET: Board_Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Board_Location/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Board_Location_Id,Board_location_Status,Board_location_Date,Board_location_name")] Board_Location board_Location)
        {
            if (ModelState.IsValid)
            {
                board_Location.Board_location_Status = true;
                board_Location.Board_location_Date = DateTime.Now;
                db.Boards_Locations.Add(board_Location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(board_Location);
        }

        // GET: Board_Location/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board_Location board_Location = db.Boards_Locations.Find(id);
            if (board_Location == null)
            {
                return HttpNotFound();
            }
            return View(board_Location);
        }

        // POST: Board_Location/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Board_Location_Id,Board_location,Board_location_Status")] Board_Location board_Location)
        {
            if (ModelState.IsValid)
            {
                board_Location.Board_location_Date = DateTime.Now;
                db.Entry(board_Location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(board_Location);
        }

        // GET: Board_Location/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board_Location board_Location = db.Boards_Locations.Find(id);
            if (board_Location == null)
            {
                return HttpNotFound();
            }
            return View(board_Location);
        }

        // POST: Board_Location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Board_Location board_Location = db.Boards_Locations.Find(id);
            db.Boards_Locations.Remove(board_Location);
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
