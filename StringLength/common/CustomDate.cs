using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StringLength.common
{
    public class CustomDateAttribute:RangeAttribute
    {
        public CustomDateAttribute(string minium):base(typeof(DateTime),minium,DateTime.Now.ToShortDateString())
        {

        }
    }
}