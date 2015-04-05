using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace OrderApplication.Models
{
    public class User: IEntity
    {
       // [PetaPoco.Ignore]
        public int ID { get; set; }
        public string name { get; private set; }
        public string pass { get; private set; }
        public string activationKey { get; private set; }
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
                this.activationKey = activationKey;
            else
                this.activationKey = Guid.NewGuid().ToString();

        }


    }
}
