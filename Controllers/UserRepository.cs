﻿using OrderApplication.Models;
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
            User createUser=new User(logginguser.name, logginguser.pass,logginguser.ActivationKey,true);
            //db.Insert(createUser);
            SendActivationEmail(ref createUser);
            this.userRepository.Add(createUser);
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
                body += "<br /><a href = '" + "www.order.com/index.html?ActivationCode=" + user.ActivationKey + "'>Click here to activate your account.</a>";
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

        internal bool Login(User logginguser)
        {
            User tmpUser;
            if (!string.IsNullOrEmpty(logginguser.ActivationKey) && logginguser.ActivationKey != Guid.Empty.ToString())
            {
                /*    tmpUser = db.Query<User>(PetaPoco.Sql.Builder
                         .Append("SELECT * FROM [User]")
                                                          .Append("WHERE name=@0", logginguser.name)
                                .Append("AND pass=@0", logginguser.pass).Append(" AND ActivationKey=@0", logginguser.ActivationKey)
                            ).Single();
                */
                tmpUser=this.userRepository.Select(user=>(((User)user.Collection).name==logginguser.name 
                    && ((User)user.Collection).pass==logginguser.pass 
                    && ((User)user.Collection).ActivationKey==logginguser.ActivationKey)) as User;
                tmpUser.IsActivated = true;
            }
            else
            {
                tmpUser = this.userRepository.Select(user=>(((User)user.Collection).name==logginguser.name
                    && ((User)user.Collection).pass == logginguser.pass && ((User)user.Collection).IsActivated==true)) as User;

              //  tmpUser = db.SingleOrDefault<User>(" WHERE name=@0 and pass=@1 and IsActivated=1 ", logginguser.name,logginguser.pass);
            }
            if(tmpUser!=null)
            {
                HttpContext.Current.Session["UserRepository"]=this.userRepository;
                return true;
            }
            else
                return false;
        }

        public void Dispose()
        {
          //  db.Dispose();
        }
    }
}
