using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness_Layer_;
namespace Bussiness_Layer_in_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeBussinessLayer emplayer = new EmployeeBussinessLayer();
            List<Employee> employees = emplayer.employees.ToList();
            return View(employees);
        }
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_get()
        {
            Employee employee = new Employee();
            return View(employee);
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_post()//Create(/*FormCollection formCollection*/ /*string name,string gender,string city, int Departmentid*/ /*Employee employee*/)
        {
            //Employee employee = new Employee();
            //employee.name = formCollection["name"];
            //employee.gender = formCollection["gender"];
            //employee.city = formCollection["city"];
            //employee.Departmentid = Convert.ToInt32(formCollection["Departmentid"]);
            //employee.name = name;
            //employee.gender = gender;
            //employee.city = city;
            //employee.Departmentid = Departmentid;
            Employee employee = new Employee();
            TryUpdateModel(employee);
            if (ModelState.IsValid)
            {
                //Employee employee = new Employee();
                //UpdateModel(employee);
                EmployeeBussinessLayer emplayer = new EmployeeBussinessLayer();
                emplayer.addemployee(employee);
                return RedirectToAction("Index");//any method can be used to map view data to model but keep in 
                                                 //mind that in mapping data using parameter the name of variable must match to the name of 
                                                 //text box in view
            }
            return View(employee);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBussinessLayer emplayer = new EmployeeBussinessLayer();
            Employee employee = emplayer.employees.Single(emp => emp.employeeid == id);
            return View(employee);
        }
         [HttpPost]
         [ActionName("Edit")]
        public ActionResult Edit_post(int id/*[Bind(/*Include ="gender,city,employeeid,Departmentid"*/ /*Exclude ="name")]Employee employee*/)
        {
            EmployeeBussinessLayer emplayer = new EmployeeBussinessLayer();
            Employee employee = emplayer.employees.Single(x => x.employeeid == id);
            UpdateModel<IEmployee>(employee); 
            //UpdateModel(employee, new string[] { "gender", "city", "employeeid" });//method 1 to prvent uninteded updates
            //UpdateModel(employee, null,null,new string[] { "name" });//method 2 to prvent uninteded updates
            if (ModelState.IsValid)
            {
             emplayer.update_employee(employee);
                return RedirectToAction("Index");
            }
           
            return View(employee);
        }
        [HttpPost]
      public ActionResult delete(int id)
        {
            EmployeeBussinessLayer employeeBussinessLayer = new EmployeeBussinessLayer();
            employeeBussinessLayer.delete_employee(id);
            return RedirectToAction("Index");
        }
    }
}