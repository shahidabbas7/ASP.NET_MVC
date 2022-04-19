using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckBoxList.Models;
using System.Text;
namespace CheckBoxList.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            Dbconection db = new Dbconection();
            CityList cityList = new CityList();
            return View(db.cities);
        }
        [HttpPost]
        public string Index(city city)
        {
            CityList cityList = new CityList();
            StringBuilder sb = new StringBuilder();
            foreach(var item in cityList.cityls)
            {
                if (item.isselected)
                {
                    sb.Append(item.Name + "");
                }
            }
            return "checkbox items are" + sb.ToString();
        }
        [HttpGet]
        public ActionResult Listbox()
        {
            Dbconection db = new Dbconection();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach(city city in db.cities)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = city.Name,
                    Value = city.id.ToString(),
                    Selected = city.isselected

                };
                selectListItems.Add(selectList);
            }
            CityModelView modelView = new CityModelView();
            modelView.cities = selectListItems;
            return View(modelView);
        }
        [HttpPost]
        public string Listbox(IEnumerable<string> selectedcities)
        {
            if (selectedcities == null)
            {
                return "you selected no item";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("you selected" + string.Join(",", selectedcities));
                return sb.ToString();
            }
        }
        }
}