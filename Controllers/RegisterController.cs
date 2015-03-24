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
        public HttpResponseMessage Post(User logginguser)
        {
            var rtnSuccess = Request.CreateResponse<string>(System.Net.HttpStatusCode.BadRequest, "Something went wrong");
            return rtnSuccess;
        }
    }
}
