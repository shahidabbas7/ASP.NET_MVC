using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace testpro.Models
{
    public class Context:DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}