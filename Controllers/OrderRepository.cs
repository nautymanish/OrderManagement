using OrderApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderApplication.Controllers
{
    public class OrderRepository /// we can use factory so that all repositories get handled at a point but due to tie constraints not doing it that way
    {
        private static OrderRepository _instance;
        private static object sync = new object();
        private static List<Order> orders = new List<Order>();
        private OrderRepository()
        {
           
        }
        public static OrderRepository getOrderRepository
        {
        get
        {
        lock(sync)
        {
            if(_instance==null)
                _instance = new OrderRepository();
            
        }
            return _instance;
        }}

        public bool PlaceOrder(Product[] product, int UserId)
        {
            Order newOrder = new Order();
            newOrder.OrderId = new Random().Next(1, Int32.MaxValue);
            newOrder.Products = new List<Product>();
            newOrder.Products.AddRange(product);
            Func<Order,double> calculatePrice = CalculatePrice;
            newOrder.Price=calculatePrice(newOrder);
            newOrder.UserId = UserId;
            new OrderApplication.DAL.DAL_Order().CreateOrder(newOrder);
            orders.Add(newOrder);
            
            return true;
        }
        private  double CalculatePrice(Order order)
        {
            double price = 0;
            order.Products.ForEach((item) => price= price + (item.ProductPrice* item.Quantity));
            return price;
        }
    }
}
