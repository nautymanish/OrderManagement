using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderApplication.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int Quantity { get; set; }
        public Product(int ProductId, string ProductName, double ProductPrice, int Quantity)
        {
            this.ProductId = ProductId;
            this.ProductName = ProductName;
            this.ProductPrice = ProductPrice;
            this.Quantity = Quantity;
        }

    }
}