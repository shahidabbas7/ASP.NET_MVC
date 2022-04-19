using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTTPSRequest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [RequireHttps]
        public string Index()
        {
            return "this page is only accessible throgh HTTPS";
        }
    }
}