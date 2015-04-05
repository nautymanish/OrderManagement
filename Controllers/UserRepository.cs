using OrderApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
//using PetaPoco;
using System.Web;

namespace OrderApplication.Controllers
{
    class UserRepository : IDisposable
    {
        public List<IEntity> userRepository { get; private set; }
        private static UserRepository _instance;
        private static object sync=new object();
        //private OrderContext db = new OrderContext();
      //  private readonly Database db;
        private  UserRepository()
        {
            userRepository = new List<IEntity>();
        //    db = new PetaPoco.Database("OrderContext");
        }
        public static  UserRepository getUserRepository {
        get
        {
        lock(sync)
        {
            if(_instance==null)
                _instance=new UserRepository();
            
        }
            return _instance;
        }}

        public  bool Create(User logginguser)
        {
            User createUser = new User(logginguser.name, logginguser.pass, logginguser.activationKey, true);
            new OrderApplication.DAL.DAL_User().CreateUser(createUser);// email is primary so would be unique else sql would send an error
            try
            {
                SendActivationEmail(ref createUser);
            }
            finally
            {
                this.userRepository.Add(createUser);
            }
                //db.Users.Add(createUser);
                //db.SaveChanges();

                
            
            return true;
        }
        private void SendActivationEmail(ref User user)
        {
            
            using (MailMessage mm = new MailMessage("sender@gmail.com", user.name))
            {
                mm.Subject = "Account Activation";
                string body = "Hello " +user.name + ",";
                body += "<br /><br />Please click the following link to activate your account";
                body += "<br /><a href = '" + "www.order.com/index.html?ActivationCode=" + user.activationKey + "'>Click here to activate your account.</a>";
                body += "<br /><br />Thanks";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("sender@gmail.com", "<password>");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }

        internal bool Login(ref User logginguser)
        {

            if (!string.IsNullOrEmpty(logginguser.activationKey) && logginguser.activationKey != Guid.Empty.ToString())
            {

                bool IsLoginSuccess = new DAL.DAL_User().Login(ref logginguser);
                if (IsLoginSuccess)
                {
                    this.userRepository.Add(logginguser);
                }
                //HttpContext.Current.Session["UserRepository"] = this.userRepository;
                return true;
            }
            else
            {
               return new DAL.DAL_User().Login(ref logginguser, true);
            }
            
                return false;
        }

        public void Dispose()
        {
          //  db.Dispose();
        }
    }
}
