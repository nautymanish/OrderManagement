using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OrderApplication.Controllers
{
    public class OrderContext: DbContext
    {
        public OrderContext()
            : base("OrderContext")
        {
            
        }
        
        public DbSet<User> Users { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}