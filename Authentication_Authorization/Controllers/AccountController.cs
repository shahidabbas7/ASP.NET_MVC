using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Authentication_Authorization.Models;
using System.Security;
using System.Web.Security;

namespace Authentication_Authorization.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            User_info user_Info = new User_info();
            return View(user_Info);
        }
        [HttpPost]
        public ActionResult Login(Models.User_info user)
        {
            employeedb empdb = new employeedb();
            bool isvalid = empdb.User_info.Any(x => x.Username == user.Username && x.password == user.password);
            if (isvalid)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
               return RedirectToAction("index", "employees");
            }
            else
            {
                ModelState.AddModelError("", "invalid username and password");
            }
            return View(user);
        }
        public ActionResult SignUp()
        {
            User_info user_Info = new User_info();
            return View(user_Info);
        }
        [HttpPost]
        public ActionResult SignUp(User_info user)
        {
            employeedb empdb = new employeedb();
            var user_data = empdb.User_info.Add(user);
            if (ModelState.IsValid)
            {
                empdb.SaveChanges();
               return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }
    }
}