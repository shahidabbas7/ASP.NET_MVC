using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testpro.Models;

namespace testpro.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            Context db = new Context();
            List<Student> students = db.Students.ToList();
            return View(students);
        }
    }
}