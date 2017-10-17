using SparesFinder.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparesFinder.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getSalesYear()
        {

            DataManager dm = new DataManager();
            var result = dm.getSalesByYear();
            return Json(new { Data = result }, JsonRequestBehavior.AllowGet);
        }

        //[Route("Home/getSalesYearBelow/{maxsales}")]
        public JsonResult getSalesYearBelow(decimal id)
        {

            DataManager dm = new DataManager();
            var result = dm.getSalesByYear().Where(t => t.Total < id).ToList();
           
            return Json(new { Data = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getSalesSummaryOfYear(int id)
        {

            DataManager dm = new DataManager();
            var result = dm.getSalesSummaryOfYear(id);
            return Json(new { Data = result }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}