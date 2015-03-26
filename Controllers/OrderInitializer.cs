using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderApplication.Controllers
{

    public class OrderInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<OrderContext>
    {
        protected override void Seed(OrderContext context)
        {
            var user = new List<User>
            {
             new User("Nino","Olivetto")
            };

            user.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

        }
    }
    }
