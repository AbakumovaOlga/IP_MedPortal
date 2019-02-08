using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebTransportCompany.Models
{
    [DataContract]
    public class Doctor : BaseModel
    {

        [DataMember]
        [Required]
        public string Specialty { get; set; }

        [DataMember]
        [ForeignKey("Doctor_Id")]
        public virtual List<Recall> Recalls { get; set; }
    }
}