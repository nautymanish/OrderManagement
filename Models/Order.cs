using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderApplication.Models
{
    public class Order
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public List<Product> Products { get; set; }
        public double Price{get; set;}

        public Order()
        {
            
        }
    }
}