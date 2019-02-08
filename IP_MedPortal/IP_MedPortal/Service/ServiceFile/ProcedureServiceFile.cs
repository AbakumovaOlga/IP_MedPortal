using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;

namespace WebTransportCompany.Service.ServiceFile
{
    public class ProcedureServiceFile :AbstractService, IProcedure
    {
        string Name = "Procedure";
        new string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Procedure";
        new XmlSerializer xsSubmit = new XmlSerializer(typeof(Procedure));

        public ProcedureServiceFile()
        {
            base.Name = Name;
            base.xsSubmit = xsSubmit;
            base.currentPath = currentPath;
        }


    }


}