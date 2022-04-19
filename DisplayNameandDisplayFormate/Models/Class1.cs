using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace DisplayNameandDisplayFormate.Models
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class  tblEmployee
    {

    }
    public class EmployeeMetaData
    {

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue =false)]
        public int Id { get; set; }
       
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime? HireDate { get; set; }
        [ScaffoldColumn(true)]
        [DataType(DataType.Currency)]
        public int Salary { get; set; }
        [DisplayFormat(NullDisplayText ="no gender selected")]
        public string Gender { get; set; }
        [ReadOnly(true)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [DataType(DataType.Url)]
        public string PersonalWebSite { get; set; }
    }
}