using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderApplication.Controllers
{
    interface IEntity
    {
        IEntity Collection { get; }
    }
}
