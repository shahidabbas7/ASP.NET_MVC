using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using data_access_entityframework.Models;
namespace data_access_entityframework.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index(int deptid)
        {
            EmployeeDBcontext empdbcontext = new EmployeeDBcontext();
            List<Employee> employees = empdbcontext.employees.Where(emp1=>emp1.Departmentid== deptid).ToList();
            return View(employees);
        }
        public ActionResult detial(int id)
        {
            EmployeeDBcontext empdbcontext = new EmployeeDBcontext();
           Employee employee= empdbcontext.employees.Single(emp => emp.employeeid == id);
            return View(employee);
        }
    }
}