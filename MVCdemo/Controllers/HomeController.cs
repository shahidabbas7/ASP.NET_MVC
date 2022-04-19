using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeBussinesLayer;
namespace MVCdemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            EmployeeLayer emplayer = new EmployeeLayer();
            IEnumerable<Employee> employee = emplayer.GetEmployees.ToList();
            return View(employee);
        }
        [HttpGet]
        public ActionResult edit(int id)
        {
            EmployeeLayer emplayer = new EmployeeLayer();
            Employee employee = emplayer.GetEmployees.Single(emp => emp.employeeid == id);
            DepartmentLayer departmentLayer = new DepartmentLayer();
            ViewBag.departmentlist = new SelectList(departmentLayer.get_department, "id", "name");
            return View(employee);
        }
        [HttpPost]
        [ActionName("edit")]
        public ActionResult edit_post(int id)
        {
            EmployeeLayer emplayer = new EmployeeLayer();
            Employee employee = emplayer.GetEmployees.Single(emp => emp.employeeid == id);
            TryUpdateModel(employee);
            if(ModelState.IsValid)
            {
                emplayer.update_employee(employee);
                return RedirectToAction("index");
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult delete(int id)
        {
            EmployeeLayer emplayer = new EmployeeLayer();
             emplayer.delete_employee(id);
            return RedirectToAction("index");
        }
    }
}