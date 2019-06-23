using BigData.Server.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BigData.Server.Controllers
{
    [Route("api/[controller]")]
    public class CoreUserController : Controller
    {
        CoreUserAccessLayer rep = new CoreUserAccessLayer();
        
        [HttpGet("[action]")]
        public JsonResult InsertUserAction()
        {
            //call to the repository
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                rep.InsertUser();
                stopwatch.Stop();
                return Json(new { message = "\nEllapsed time: "+stopwatch.ElapsedMilliseconds+"ms\n---DONE---\n" });
            }catch(Exception ex)
            {
                return Json(new { message = ex.ToString() });
            }
        }
    }
}
