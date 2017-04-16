using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_HomeAngularJS.Models;

namespace WebApplication_HomeAngularJS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //CategoryModel m = new CategoryModel();
            //m.CategoryID = 1;
            //m.CategoryName = "CategoryName";
            //m.AddedDateTime = DateTime.Now;

            return View();
        }
    }
}
