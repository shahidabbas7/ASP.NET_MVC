using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBussinesLayer
{
   
   public class Employee
    {
        public int employeeid { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public int Departmentid { get; set; }
        public virtual Department department { get; set; }
    }
}
