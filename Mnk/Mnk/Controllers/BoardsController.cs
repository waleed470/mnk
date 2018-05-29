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
    public class BoardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Boards
        public ActionResult Index()
        {
            var boards = db.Boards.Include(b => b.Board_Availbality).Include(b => b.Board_city).Include(b => b.Board_Location).Include(b => b.Board_medium);
            return View(boards.ToList());
        }

        // GET: Boards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = db.Boards.Find(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        // GET: Boards/Create
        public ActionResult Create()
        {
            ViewBag.Availability_id = new SelectList(db.Boards_Availability, "Availability_id", "Availability_name");
            ViewBag.Board_City_Id = new SelectList(db.Board_city, "Board_City_Id", "Board_City_name");
            ViewBag.Board_Location_Id = new SelectList(db.Boards_Locations, "Board_Location_Id", "Board_location_name");
            ViewBag.Board_Medium_Id = new SelectList(db.Board_medium, "Board_Medium_Id", "Board_Medium_name");
            return View();
        }

        // POST: Boards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Broard_Id,Broard_Site_code,Broard_Traffic_from,Broard_Traffic_to,Broard_Width,Broard_Height,Board_Medium_Id,Board_City_Id,Board_Location_Id,Availability_id")] Board board)
        {
            if (ModelState.IsValid)
            {
                db.Boards.Add(board);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Availability_id = new SelectList(db.Boards_Availability, "Availability_id", "Availability_name", board.Availability_id);
            ViewBag.Board_City_Id = new SelectList(db.Board_city, "Board_City_Id", "Board_City_name", board.Board_City_Id);
            ViewBag.Board_Location_Id = new SelectList(db.Boards_Locations, "Board_Location_Id", "Board_location_name", board.Board_Location_Id);
            ViewBag.Board_Medium_Id = new SelectList(db.Board_medium, "Board_Medium_Id", "Board_Medium_name", board.Board_Medium_Id);
            return View(board);
        }

        // GET: Boards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = db.Boards.Find(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            ViewBag.Availability_id = new SelectList(db.Boards_Availability, "Availability_id", "Availability_name", board.Availability_id);
            ViewBag.Board_City_Id = new SelectList(db.Board_city, "Board_City_Id", "Board_City_name", board.Board_City_Id);
            ViewBag.Board_Location_Id = new SelectList(db.Boards_Locations, "Board_Location_Id", "Board_location_name", board.Board_Location_Id);
            ViewBag.Board_Medium_Id = new SelectList(db.Board_medium, "Board_Medium_Id", "Board_Medium_name", board.Board_Medium_Id);
            return View(board);
        }

        // POST: Boards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Broard_Id,Broard_Site_code,Broard_Traffic_from,Broard_Traffic_to,Broard_Width,Broard_Height,Board_Medium_Id,Board_City_Id,Board_Location_Id,Availability_id")] Board board)
        {
            if (ModelState.IsValid)
            {
                db.Entry(board).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Availability_id = new SelectList(db.Boards_Availability, "Availability_id", "Availability_name", board.Availability_id);
            ViewBag.Board_City_Id = new SelectList(db.Board_city, "Board_City_Id", "Board_City_name", board.Board_City_Id);
            ViewBag.Board_Location_Id = new SelectList(db.Boards_Locations, "Board_Location_Id", "Board_location_name", board.Board_Location_Id);
            ViewBag.Board_Medium_Id = new SelectList(db.Board_medium, "Board_Medium_Id", "Board_Medium_name", board.Board_Medium_Id);
            return View(board);
        }

        // GET: Boards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = db.Boards.Find(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        // POST: Boards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Board board = db.Boards.Find(id);
            db.Boards.Remove(board);
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
