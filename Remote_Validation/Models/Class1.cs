using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Remote_Validation.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class UserInfo
    {
    }
    public class UserMetaData
    {
        [Required]
        [Remote("IsuserNameExist", "UserInfo",ErrorMessage ="Username already in use")]
        public string Username { get; set; }
    }
}