using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebTransportCompany.Models
{
    [DataContract]
    public class Client : BaseModel
    {
        [DataMember]
        [Required]
        public string Login { get; set; }
        [DataMember]
        [Required]
        public string Password { get; set; }
    }
}