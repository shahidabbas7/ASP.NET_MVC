//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Crud_Scafolding.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int employeeid { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string city { get; set; }
        public Nullable<int> Departmentid { get; set; }
    
        public virtual department department { get; set; }
    }
}
