using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace data_access_entityframework.Models
{ 
    [Table("Employee")]

    public class Employee
    {
        public int employeeid { get; set; }
        public string  name { get; set; }
        public string gender { get; set; }
        public string city { get; set; }
        public int Departmentid { get; set; }
    }
}