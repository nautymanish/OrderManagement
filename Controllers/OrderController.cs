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
       
        public IEnumerable<Product> GetProducts()
        {
            //return ProductList.AsQueryable();
            return new OrderApplication.DAL.DAL_Product().GetProducts();
        }
        [HttpPost]
        public HttpResponseMessage PostOrder(int ID,Product[] orderProducts)
        {
           
            OrderRepository orderRepo = OrderRepository.getOrderRepository;
            var result=orderRepo.PlaceOrder(orderProducts,ID);
            if (result)
                return Request.CreateResponse<string>(System.Net.HttpStatusCode.OK, "Done");
            else
                return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Issue with order");
        }

    }
}
