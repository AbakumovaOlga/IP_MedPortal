using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTransportCompany.Models
{
    public abstract class BaseModel
    {
        public int Id { set; get; }

        public String Name { set; get; }
    }
}