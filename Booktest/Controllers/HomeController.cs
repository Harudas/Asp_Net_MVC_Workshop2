using Booktest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Booktest.Models;

namespace Booktest.Controllers
{
    public class HomeController : Controller
    {
        Models.ModelCenter db = new Models.ModelCenter();
        
        public ActionResult Index()
        {
            ViewBag.SearchResult = db.Get_BookData_ByCondtioin();
            return View();
        }


        [HttpPost()]
        public JsonResult Delete(string Book_Id)
        {
            try
            {
                Models.ModelCenter db = new Models.ModelCenter();
               db.Delete_Bookdata(Book_Id);
                return this.Json(true);
            }

            catch (Exception ex)
            {
                return this.Json(false);
            }
        }

        public JsonResult inser(string id)
        {
            string[] s = id.Split('|');
            db.inser(s[0], s[1], s[2], s[3], s[4], s[5]);
            return this.Json(true);
        }

    }
}