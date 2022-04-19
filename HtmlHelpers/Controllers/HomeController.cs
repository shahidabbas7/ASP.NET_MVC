using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HtmlHelpers.Models;
namespace HtmlHelpers.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Dbcontext db = new Dbcontext();
            //ViewBag.department = new SelectList(db.department, "id", "name","1");
            //List<SelectListItem> selectListItems = new List<SelectListItem>();
            //foreach (department department in db.department)
            //{
            //    SelectListItem selectListItem = new SelectListItem
            //    {
            //        Text = department.Name,
            //        Value = department.id.ToString(),
            //        Selected = department.isselected.HasValue ? department.isselected.Value : false
            //    };
            //    selectListItems.Add(selectListItem);
            //}
            //ViewBag.department = selectListItems;
            Company company = new Company("newtech");
            ViewBag.departments = new SelectList(company.Departments, "id", "name");
            ViewBag.companyname = company.Companyname;
            return View();
        }
        public ActionResult index1()
        {
            Company company = new Company("new");
            return View(company);
        }
        [HttpGet]
        public ActionResult departmentlist()
        {
            companyrb companyrb = new companyrb();
            return View(companyrb);
        }
        [HttpPost]
        public string departmentlist(companyrb companyrb)
        {
            if (string.IsNullOrEmpty(companyrb.selectedDepartment))
            {
                return "no value is selected";
            }
            else
            {
                return "you selected id=" + companyrb.selectedDepartment;
            }
            
        }
    }
}