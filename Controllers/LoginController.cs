using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace OrderApplication.Controllers
{
    public class LoginController : ApiController
    {
        //
        // POST: /Login/
         [HttpPost]
        public User Post(User logginguser)
        {
            return new User(); // blank user
         }
       
        
    }
}
