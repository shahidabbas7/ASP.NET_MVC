using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Bussiness_Layer_
{
   public interface IEmployee
    {
       int employeeid { get; set; }
        string gender { get; set; }
       string city { get; set; }
         int Departmentid { get; set; }
    }
    public class Employee:IEmployee
    { 
        public int employeeid { get; set; }
        public string name { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public int Departmentid { get; set; }
    }
}
