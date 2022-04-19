using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DisplayNameandDisplayFormate.Models;
namespace DisplayNameandDisplayFormate.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            dbconnection db = new dbconnection();
           IEnumerable<tblEmployee> tblEmployee = db.tblEmployees.ToList();
            return View(tblEmployee);
        }
        [HttpGet]
        public ActionResult edit(int id)
        {
            dbconnection db = new dbconnection();
            tblEmployee tblEmployee = db.tblEmployees.Single(x => x.Id == id);
            return View(tblEmployee);
        }
        [HttpPost]
        [ActionName("edit")]
        public ActionResult edit_post(int id)
        {
            dbconnection db = new dbconnection();
            tblEmployee employee = db.tblEmployees.Single(x => x.Id == id);
            TryUpdateModel(employee);
            if (ModelState.IsValid)
            {
                EmployeeLayer employeeLayer = new EmployeeLayer();
                employeeLayer.update_employee(employee);
                return RedirectToAction("edit", new { id = employee.Id });
            }
           
            return View();
        }
        public ActionResult detial(int id)
        {
            dbconnection db = new dbconnection();
            tblEmployee tblEmployee = db.tblEmployees.Single(x => x.Id == id);
            return View(tblEmployee);
        }
    }
}