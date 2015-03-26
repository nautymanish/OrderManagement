using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace OrderApplication.Controllers
{
    public class User: IEntity
    {
        [PetaPoco.Ignore]
        public int ID { get; set; }
        public string name { get; private set; }
        public string pass { get; private set; }
        public string ActivationKey { get; private set; }

        IEntity IEntity.Collection
        {
            get { return this; }
        }

        public User(string name, string password)
        {
            this.name = name;
            this.pass = password;
            this.ActivationKey = Guid.NewGuid().ToString();
        }


    }
}
