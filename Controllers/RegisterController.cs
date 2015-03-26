using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace OrderApplication.Controllers
{
    public class RegisterController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(User registerUser)
        {
            HttpResponseMessage rtnSuccess; 
            var userController = UserRepository.getUserRepository;
            if (userController.Create(registerUser))
            {
                rtnSuccess = Request.CreateResponse<string>(System.Net.HttpStatusCode.OK, "Done");
            }
            else
            {
                rtnSuccess = Request.CreateResponse<string>(System.Net.HttpStatusCode.NotImplemented, "Something went wrong");
            }
            return rtnSuccess;
        }
    }
}
