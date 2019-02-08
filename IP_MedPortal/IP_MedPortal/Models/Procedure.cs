using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebTransportCompany.Models
{
    [DataContract]
    public class Procedure:BaseModel
    {
        [DataMember]
        [Required]
        public decimal PriceOfProc { get; set; }
    }
}