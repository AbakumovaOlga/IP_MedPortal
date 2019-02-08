using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;

namespace WebTransportCompany.Service.ServiceFile
{
    public class ClientServiceFile : AbstractService, IClient
    {
        new string Name = "Client";
        new string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Client";
        new XmlSerializer xsSubmit = new XmlSerializer(typeof(Client));

        public ClientServiceFile()
        {
            base.Name = Name;
            base.xsSubmit = xsSubmit;
            base.currentPath = currentPath;
        }

        public bool Registrations(Client client)
        {
            List<Client> clients = new List<Client>();
            List<BaseModel> context = base.GetList();
            foreach (Client customer in context)
            {
                clients.Add(customer);
            }
            Client user = clients.FirstOrDefault(rec => rec.Login.Equals(client.Login));
            if (user != null)
            {
                return false;
            }
            else
            {
                AddElement(client);
                return true;
            }
        }

        public bool Authorization(Client client)
        {
            List<Client> clients = new List<Client>();
            List<BaseModel> context = base.GetList();
            foreach (Client customer in context)
            {
                clients.Add(customer);
            }
            Client user = clients.FirstOrDefault(rec => rec.Login.Equals(client.Login) && rec.Password.Equals(client.Password));
            return user != null;

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
} 