using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Searching_in_MVC.Models;
using PagedList;
using PagedList.Mvc;

namespace Searching_in_MVC.Controllers
{
    public class EmployeesController : Controller
    {
        private dbconnection db = new dbconnection();

        // GET: Employees
        public ActionResult Index(string searchby, string search, int? page, string sortby)
        {
            ViewBag.sortname = string.IsNullOrEmpty(sortby) ? "name desc" : "";
            ViewBag.gendersort = sortby == "Gender" ? "gender desc" : "Gender";
            var employees = db.Employees.AsQueryable();

            if (searchby == "Gender")
            {
                employees = employees.Where(x => x.gender == search || search == null);
            }
            else
            {
                employees = employees.Where(x => x.name.StartsWith(search) || search == null);

            }
            switch (sortby)
            {
                case "name desc":
                    employees = employees.OrderByDescending(x => x.name);
                    break;
                case "gender desc":
                    employees = employees.OrderByDescending(x => x.gender);
                    break;
                case "Gender":
                    employees = employees.OrderBy(x => x.gender);
                    break;
                default:
                    employees = employees.OrderBy(x => x.name);
                    break;
            }
          return View(employees.ToPagedList(page ?? 1, 3));
        }


        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employeeid,name,gender,city,Departmentid")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employeeid,name,gender,city,Departmentid")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
