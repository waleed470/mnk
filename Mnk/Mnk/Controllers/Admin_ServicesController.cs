using Mnk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Mnk.Controllers
{
    public class Admin_ServicesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin_Services
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public void Insert(FormCollection form)
        {
            var js = new JavaScriptSerializer();
            Services ServiceList = js.Deserialize<Services>(form["ServiceList"]);

            ServiceList.Service_status = true;
            ServiceList.Service_date = DateTime.Now;
            db.Servicess.Add(ServiceList);
            db.SaveChanges();
        }
        [HttpPost]
        public JsonResult Get_Service_data()
        {
            var allservices = db.Servicess.ToList();

            return Json(allservices, JsonRequestBehavior.AllowGet);
        }
        public void Update(FormCollection form)
        {
            var js = new JavaScriptSerializer();
            Services ServicesList = js.Deserialize<Services>(form["ServiceList"]);

            var servic = db.Servicess.Find(ServicesList.Service_Id);


            servic.Service_Name = ServicesList.Service_Name;
            servic.Service_status = ServicesList.Service_status;
            db.Entry(servic).State = EntityState.Modified;
            db.SaveChanges();
        }
        //[HttpPost]
        //public JsonResult Get_Services_data(int id)
        //{
        //    var obj = db.Servicess.Where(m => m.Service_Id == id).ToList();
        //    return Json(obj, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public JsonResult Get_Services_data(int id)
        {
            try
            {
                Services varientPT = db.Servicess.Find(id);

               
                string qty = varientPT.Service_Name;
                bool status = varientPT.Service_status;

             

                Tuple<string,bool> tpl = new Tuple<string,bool>
                (
                qty,
                status
                
                );
              
                return Json(tpl, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(null, JsonRequestBehavior.AllowGet);
            }

        }
    }
}