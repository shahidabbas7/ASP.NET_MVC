using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace HtmlHelpers.Models
{
    public class Company
    {
        private string name_;
        public Company(string name)
        {
            this.name_ = name;
        }
        public List<department> Departments
        {
            get
            {
                Dbcontext db = new Dbcontext();
                return db.department.ToList();
            }
        }
        public string Companyname
        {
            get
            {
                return name_;
            }
            set
            {
                name_ = value;
            }
        }
    }
}