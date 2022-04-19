using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace data_access_entityframework.Models
{
    [Table("department")]
    public class Department
    {
        public int id { get; set; }
        public string name { get; set; }
        
    }
}