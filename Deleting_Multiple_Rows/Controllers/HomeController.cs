using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Deleting_Multiple_Rows.Models;
namespace Deleting_Multiple_Rows.Controllers
{
    public class HomeController : Controller
    {
        dbconnection db = new dbconnection();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }
        public ActionResult delete(IEnumerable<int> employeestodelete)
        {
          db.Employees.Where(x => employeestodelete.Contains(x.employeeid)).ToList().ForEach(x=>db.Employees.Remove(x));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}