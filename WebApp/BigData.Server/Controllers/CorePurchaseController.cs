using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BigData.Server.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace BigData.Server.Controllers
{
    [Route("api/[controller]")]
    public class CorePurchaseController : Controller
    {
        CorePurchaseAccessLayer rep = new CorePurchaseAccessLayer();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        public JsonResult InsertPurchaseAction()
        {
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                rep.InsertPurchase();
                stopwatch.Stop();
                return Json(new { message = "\nEllapsed time: " + stopwatch.ElapsedMilliseconds + "ms\n---DONE---\n" });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.ToString() });
            }
        }

        [HttpGet("[action]")]
        public JsonResult TrainModel()
        {
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                rep.TrainModelAction();
                stopwatch.Stop();
                return Json(new { message = "\nEllapsed time: " + stopwatch.ElapsedMilliseconds + "ms\n---DONE---\n" });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.ToString() });
            }
        }

        [HttpGet("[action]")]
        public JsonResult ModelInsert()
        {
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                rep.PurchaseModelInsertion();
                stopwatch.Stop();
                return Json(new { message = "\nEllapsed time: " + stopwatch.ElapsedMilliseconds + "ms\n---DONE---\n" });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.ToString() });
            }
        }
    }
}