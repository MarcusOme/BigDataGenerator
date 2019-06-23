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
    public class CoreProductController : Controller
    {
        CoreProductAccessLayer rep = new CoreProductAccessLayer();

        [HttpGet("[action]")]
        public JsonResult InsertProductAction()
        {
            //call to the repository
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                rep.InsertProduct();
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