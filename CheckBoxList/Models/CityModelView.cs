using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace CheckBoxList.Models
{
    public class CityModelView
    {
       public IEnumerable<SelectListItem> cities { get; set; }
      public  IEnumerable<string> Selectedcities { get; set; }
    }
}