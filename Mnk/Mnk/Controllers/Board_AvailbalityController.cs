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
    public class Board_AvailbalityController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Board_Availbality
        public ActionResult Index()
        {
            return View(db.Boards_Availability.ToList());
        }

        // GET: Board_Availbality/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board_Availbality board_Availbality = db.Boards_Availability.Find(id);
            if (board_Availbality == null)
            {
                return HttpNotFound();
            }
            return View(board_Availbality);
        }

        // GET: Board_Availbality/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Board_Availbality/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Board_Availbality board_Availbality)
        {
            if (ModelState.IsValid)
            {
                //var toDate = board_Availbality.Availability_to.Date;
                //var fromDate = board_Availbality.Availability_from.Date;

                //var toMonth = board_Availbality.Availability_to.Month;
                //var fromMonth = board_Availbality.Availability_from.Month;

                //if (toDate>fromDate && toMonth > fromMonth)
                //{

                //}
                //board_Availbality.Availability_Date = DateTime.Now;
                //board_Availbality.Availability_from = DateTime.Now;
                board_Availbality.Availability_Date = DateTime.Now;
                db.Boards_Availability.Add(board_Availbality);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(board_Availbality);
        }

        // GET: Board_Availbality/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board_Availbality board_Availbality = db.Boards_Availability.Find(id);
            if (board_Availbality == null)
            {
                return HttpNotFound();
            }
            return View(board_Availbality);
        }

        // POST: Board_Availbality/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Availability_id,Availability_name,Availability_to,Availability_from,Availability_status,Availability_Date")] Board_Availbality board_Availbality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(board_Availbality).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(board_Availbality);
        }

        // GET: Board_Availbality/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board_Availbality board_Availbality = db.Boards_Availability.Find(id);
            if (board_Availbality == null)
            {
                return HttpNotFound();
            }
            return View(board_Availbality);
        }

        // POST: Board_Availbality/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Board_Availbality board_Availbality = db.Boards_Availability.Find(id);
            db.Boards_Availability.Remove(board_Availbality);
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
