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
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public double Price{get; private set;}
    }
}