using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HtmlHelpers.Models
{
    public class companyrb
    {
        public string selectedDepartment { get; set; }
        public List<department> departments
        {
           
            get
            {
                Dbcontext dbcontext = new Dbcontext();
                return dbcontext.department.ToList();
            }
        }
    }
}