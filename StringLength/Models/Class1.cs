using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using StringLength.common;
using System.Web.Mvc;
namespace StringLength.Models
{
    [MetadataType(typeof(Employeemetadata))]
    public partial class Employee
    {
        //[Compare("name")]
        public String ConfirmName { get; set; }
    }
    public class Employeemetadata
    {
        [StringLength(10, MinimumLength = 5)]
        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$",ErrorMessage ="Please enter letter between A and Z")]
        [Remote("isnameexist", "Employee",ErrorMessage ="Name Already exis")]
        public string name { get; set; }
        [Range(16, 150)]
        public Nullable<int> age { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [CurrentDate]
        public Nullable<System.DateTime> Hiredate { get; set; }
    }

}