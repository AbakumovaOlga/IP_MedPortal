using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebTransportCompany.Models
{
    [DataContract]
    public class Recall : BaseModel
    {
        [DataMember]
        public int DoctorId { get; set; }
        [DataMember]
        public string  Comment { get; set; }

        [DataMember]
        public int Doctor_Id { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}