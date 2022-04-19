using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using data_access_entityframework.Models;
namespace data_access_entityframework.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            EmployeeDBcontext deptdbcontext = new EmployeeDBcontext();
            List<Department> department = deptdbcontext.departments.ToList();
            return View(department);
        }
    }
}