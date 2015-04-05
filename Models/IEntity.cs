using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderApplication.Models
{
    interface IEntity
    {
        IEntity Collection { get; }
    }


   
}
