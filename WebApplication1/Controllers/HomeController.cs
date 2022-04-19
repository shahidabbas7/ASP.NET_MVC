using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Hello from mvc Application";
        }
        public ActionResult detial()
        {
            /* ViewBag.list = new List<string>
             {
               "Pakistan",
               "India",
               "Afghanistan",
               "turky",
               "England"
             };*/
             ViewData["countries"] = new List<string>
            {
              "Pakistan",
              "India",
              "Afghanistan",
              "turky",
              "England"
            };
            return View();
        }
        public ActionResult detial1()
        {
            Employee emp = new Employee()
            {
                id = 1,
                name = "Shahid",
                gender = "male",
                City = "Lahore"
            };
            return View(emp);
        }
    }
}