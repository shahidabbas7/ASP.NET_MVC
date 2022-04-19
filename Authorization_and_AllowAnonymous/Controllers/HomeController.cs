using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authorization_and_AllowAnonymous.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
       // [Authorize]
        public ActionResult SecureMethod()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult NonSecureMethod()
        {
            return View();
        }
    }
}