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
        public bool IsActivated { get; set; }
        IEntity IEntity.Collection
        {
            get { return this; }
        }

        public User(string name, string password, string activationKey, bool createKey=false)
        {
            this.name = name;
            this.pass = password;
            if (!createKey)
                this.ActivationKey = ActivationKey;
            else
                this.ActivationKey = Guid.NewGuid().ToString();

        }


    }
}
