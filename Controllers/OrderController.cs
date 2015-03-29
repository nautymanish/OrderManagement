using OrderApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderApplication.Controllers
{
    public class OrderController : ApiController
    {
        private List<Product> ProductList;
        public OrderController()
        {
            ProductList = new List<Product>();
            ProductList.AddRange(new Product[]{new Product(1,"Shirt",4), new Product(2,"Skirt",5.0)});

        }

        public IEnumerable<Product> GetProducts()
        {
            return ProductList.AsQueryable();
        }
        [HttpPost]
        public HttpResponseMessage PostOrder(Order[] order)
        {
            return Request.CreateResponse<string>(System.Net.HttpStatusCode.OK, "Done");
        }

    }
}
