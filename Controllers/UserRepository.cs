using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;

namespace OrderApplication.Controllers
{
    class UserRepository
    {
        public List<IEntity> userRepository { get; private set; }
        private static UserRepository _instance;
        private static object sync=new object();
        //private OrderContext db = new OrderContext();
        private readonly Database db;
        private  UserRepository()
        {
            userRepository = new List<IEntity>();
            db = new PetaPoco.Database("OrderContext");
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
            User createUser=new User(logginguser.name, logginguser.pass);
            db.Insert(createUser);
            //db.Users.Add(createUser);
            //db.SaveChanges();
            
            return true;
        }
    }
}
