using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;

namespace WebTransportCompany.Service.ServiceBD
{
    public class ClientServiceBD: IClient
    {
        private MedPortalContext context = new MedPortalContext();

        public void AddElement(BaseModel model)
        {
            context.Clients.Add((Client)model);
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Client client = context.Clients.Find(id);
            if (client != null)
            {
                context.Clients.Remove(client);
                context.SaveChanges();
            }
        }

        public BaseModel GetElement(int id)
        {
            Client client = context.Clients.Find(id);
            return client;
        }

        public List<BaseModel> GetList()
        {
            List<BaseModel> BaseModel = new List<BaseModel>();
            List<Client> Clients = context.Clients.ToList();
            foreach (Client client in Clients)
            {
                BaseModel.Add(client);
            }
            return BaseModel;
        }

        public void UpdateElement(BaseModel model)
        {
            context.Entry((Client)model).State = EntityState.Modified;
            context.SaveChanges();
        }

        public bool Registrations(Client client)
        {
            Client Client = context.Clients.FirstOrDefault(rec => rec.Login.Equals(client.Login));
            if (Client != null)
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
            Client Client = context.Clients.FirstOrDefault(rec => rec.Login.Equals(client.Login) && rec.Password.Equals(client.Password));
            if (Client == null)
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