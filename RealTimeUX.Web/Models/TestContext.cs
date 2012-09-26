using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RealTimeUX.Web.Models
{
    public class TestContext : DbContext
    {
        public TestContext()
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<SubItem> SubItems { get; set; }
    }
}