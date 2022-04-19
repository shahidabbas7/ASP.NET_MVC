using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CmsShoppingCart.Areas.Admin.Data
{
    public class DBconn:DbContext
    {
        public DbSet<PageDTO> pages { get; set; }

        public System.Data.Entity.DbSet<CmsShoppingCart.Models.ModelView.PagesVm> PagesVms { get; set; }
    }
}