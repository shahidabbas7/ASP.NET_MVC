using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CRUD_Operations_Using_EntityFramework.Models
{
    [MetadataType(typeof(DepartmentMetaData))]
    public partial class department
    {
    }
    public class DepartmentMetaData
    {
        [Display(Name ="Department Name")]
        public String Name { get; set; }
    }
}