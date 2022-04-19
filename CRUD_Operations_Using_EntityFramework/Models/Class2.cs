using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CRUD_Operations_Using_EntityFramework.Models
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
       
    }
    public class EmployeeMetaData
    {

        public int employeeid { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        [Display(Name ="Department")]
        public int Departmentid { get; set; }
       
    }
    
}