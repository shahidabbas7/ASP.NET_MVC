using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustonActionFilter.common;
namespace CustonActionFilter.Controllers
{
    public class HomeController : Controller
    {
        [CustomActionFilter]
        // GET: Home
        
        public ActionResult Index()
        {
            return View();
        }
    }
}