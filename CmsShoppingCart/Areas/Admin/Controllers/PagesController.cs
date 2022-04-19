using CmsShoppingCart.Areas.Admin.Data;
using CmsShoppingCart.Models.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CmsShoppingCart.Areas.Admin.Controllers
{
    public class PagesController : Controller
    {
        // GET: Admin/Pages
        public ActionResult Index()
        {
            List<PagesVm> pagelist;
            using(DBconn dBconn=new DBconn())
            {
                pagelist = dBconn.pages.ToArray().OrderBy(x => x.Sorting).Select(x => new PagesVm(x)).ToList();
            }
            return View(pagelist);
        }
        [HttpGet]
       public ActionResult addpage()
        {
            PageDTO pagesVm = new PageDTO();
            return View(pagesVm);
        }
        [HttpPost]
        public ActionResult addpage(PagesVm model)
        {
            PageDTO page = new PageDTO();
            if (ModelState.IsValid)
            {
                using (DBconn db=new DBconn())
                {
                  string slug;
                    page.Title = model.Title;
                    if (string.IsNullOrWhiteSpace(model.Slug))
                    {
                        slug = model.Title.Replace(" ", "-").ToLower();
                    }
                    else
                    {
                        slug = model.Slug.Replace(" ", "-").ToLower();
                    }
                    if (db.pages.Any(x => x.Title == model.Title || db.pages.Any(y => y.Slug == slug)))
                    {
                        ModelState.AddModelError(" ", "the title or slug already exist");
                    }
                    else
                    {
                        page.Slug = slug;
                        page.Body = model.Body;
                        page.HasSidebar = model.HasSidebar;
                        page.Sorting = 100;
                        db.pages.Add(page);
                        db.SaveChanges();
                        TempData["sm"] = "Successfully added New Page";
                    }
                    
                }
            }
            else
            {
                return View(page);
            }
            return View("addpage");
        }

    }
}