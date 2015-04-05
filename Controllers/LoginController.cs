using OrderApplication.Models;
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
            var UserDetails = new User(logginguser.name, logginguser.pass, logginguser.activationKey);
           UserRepository userRepository=UserRepository.getUserRepository;
           if (userRepository.Login(ref logginguser))
               return logginguser;
           else
               return null;
             //return new User(logginguser.name, logginguser.pass, logginguser.ActivationKey); // blank user
         }
       
        
    }
}
