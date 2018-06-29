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
    public class BoardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Boards
        public ActionResult Index()
        {
            string idd = Convert.ToString(Session["UserId"]);
            var boards = db.Boards.Where(b => b.Id == idd).ToList();
            return View(boards);
        }

        public ActionResult oder_vender()
        {
            string idd = Convert.ToString(Session["UserId"]);
            var boards = db.Board_booking.Where(b => b.Board.Id==idd).ToList();
            return View(boards);
        }
        public ActionResult Availability (int id)
        {
            Board board_ag_id = db.Boards.Find(id);
            return View(board_ag_id);
        }

        [HttpPost]
        public ActionResult Availability (Board_Availbality Board_Availbality , Board Board)
        {
            if (ModelState.IsValid)
            {

                var Board_Availbility_update = db.Boards_Availability.Where(m => m.Board_id == Board.Broard_Id);
                foreach (var item in Board_Availbility_update)
                {
                    item.Availability_status = false;
                }
                Board_Availbality.Availability_status = true;
                Board_Availbality.Board_id = Board.Broard_Id;
                db.Boards_Availability.Add(Board_Availbality);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult hold_book(Board_booking Board_booking, string type , Board Board)
        {
            if (ModelState.IsValid)
            {
                
                if (type == "Hold")
                {
                    Board_booking.Booking_type = "Hold";
                    Board_booking.Booking_from = Board_booking.Booking_to.AddDays(3);
                    Board_booking.Broard_Id = Board.Broard_Id;
                    string idd = Convert.ToString(Session["UserId"]);
                    Board_booking.Id = idd;
                    
                }
                if (type == "Book")
                {
                    Board_booking.Booking_type = "Book";
                    Board_booking.Broard_Id = Board.Broard_Id;
                    string idd = Convert.ToString(Session["UserId"]);
                    Board_booking.Id = idd;

                }
                db.Board_booking.Add(Board_booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
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
            ////ViewBag.Availability_id = new SelectList(db.Boards_Availability, "Availability_id", "Availability_id");
            ViewBag.Board_City_Id = new SelectList(db.Board_city, "Board_City_Id", "Board_City_name");
            ////ViewBag.Board_image_id = new SelectList(db.Board_image, "Board_image_id", "image");
            ViewBag.Board_Location_Id = new SelectList(db.Boards_Locations, "Board_Location_Id", "Board_location_name");
            ViewBag.Board_Medium_Id = new SelectList(db.Board_medium, "Board_Medium_Id", "Board_Medium_name");
            return View();
        }

        // POST: Boards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Board board, Board_Availbality Board_Availbality, Board_image Board_image,  HttpPostedFileBase []doc)
        {
            
            if (ModelState.IsValid)
            {
                string idd = Convert.ToString(Session["UserId"]);
                board.Id = idd;
                board.Board_date = DateTime.Now;
                db.Boards.Add(board);
                db.SaveChanges();
                var varid = db.Boards.Max(m => m.Broard_Id);
                foreach (var item in doc)
                {
                    var filename = Path.GetFileName(item.FileName);
                    var extension = Path.GetExtension(filename).ToLower();
                    if (extension == ".jpg" || extension == ".png")
                    {
                        var path = HostingEnvironment.MapPath(Path.Combine("~/Content/Images/", filename));
                        item.SaveAs(path);
                        Board_image.image = "~/Content/Images/" + filename;
                        Board_image.Board_id  =  varid;
                        db.Board_image.Add(Board_image);
                        db.SaveChanges();

                    }
                }
                Board_Availbality.Availability_status = true;
                Board_Availbality.Board_id = varid;

                db.Boards_Availability.Add(Board_Availbality);



                db.SaveChanges();


                return RedirectToAction("Index");
            }

            ////ViewBag.Availability_id = new SelectList(db.Boards_Availability, "Availability_id", "Availability_id", board.Availability_id);
            ViewBag.Board_City_Id = new SelectList(db.Board_city, "Board_City_Id", "Board_City_name", board.Board_City_Id);
            ////ViewBag.Board_image_id = new SelectList(db.Board_image, "Board_image_id", "image", board.Board_image_id);
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
            
            ViewBag.Board_City_Id = new SelectList(db.Board_city, "Board_City_Id", "Board_City_name", board.Board_City_Id);
            
            ViewBag.Board_Location_Id = new SelectList(db.Boards_Locations, "Board_Location_Id", "Board_location_name", board.Board_Location_Id);
            ViewBag.Board_Medium_Id = new SelectList(db.Board_medium, "Board_Medium_Id", "Board_Medium_name", board.Board_Medium_Id);
            return View(board);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Board board ,Board_Availbality Board_Availbality, Board_image Board_image, HttpPostedFileBase []doc)
        {
            


            if (ModelState.IsValid)
            {
                Board Board_update = db.Boards.Find(board.Broard_Id);
                Board_update.Broard_Site_code = Board_update.Broard_Site_code;
                Board_update.Broard_Traffic_from = Board_update.Broard_Traffic_from;
                Board_update.Broard_Traffic_to = Board_update.Broard_Traffic_to;
                Board_update.Broard_Width = Board_update.Broard_Width;
                Board_update.Broard_Height = Board_update.Broard_Height;
                Board_update.Board_Medium_Id = Board_update.Board_Medium_Id;
                Board_update.Board_City_Id = Board_update.Board_City_Id;
                Board_update.Board_Location_Id = Board_update.Board_Location_Id;


                var Board_image_update = db.Board_image.Where(m => m.Board_id == board.Broard_Id);

                foreach (var item in Board_image_update)
                {
                    db.Board_image.Remove(item);
                }

                foreach (var item in doc)
                {
                    var filename = Path.GetFileName(item.FileName);
                    var extension = Path.GetExtension(filename).ToLower();
                    if (extension == ".jpg" || extension == ".png")
                    {
                        var path = HostingEnvironment.MapPath(Path.Combine("~/Content/Images/", filename));
                        item.SaveAs(path);
                        Board_image.image = "~/Content/Images/" + filename;
                        Board_image.Board_id = board.Broard_Id;
                        db.Board_image.Add(Board_image);
                        db.SaveChanges();

                    }
                }


                db.Entry(Board_update).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
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
