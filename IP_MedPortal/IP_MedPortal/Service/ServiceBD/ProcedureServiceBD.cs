using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;

namespace WebTransportCompany.Service.ServiceBD
{
    public class ProcedureServiceBD : IProcedure
    {
        private MedPortalContext context = new MedPortalContext();

        public void AddElement(BaseModel model)
        {
            context.Procedures.Add((Procedure)model);
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Procedure model = context.Procedures.Find(id);
            if (model != null)
            {
                context.Procedures.Remove(model);
                context.SaveChanges();
            }
        }

        public BaseModel GetElement(int id)
        {
            Procedure model = context.Procedures.Find(id);
            return model;
        }

        public List<BaseModel> GetList()
        {
            List<BaseModel> models = new List<BaseModel>();
            List<Procedure> procedures = context.Procedures.ToList();
            foreach (Procedure procedure in procedures)
            {
                models.Add(procedure);
            }
            return models;
        }

        public void UpdateElement(BaseModel model)
        {
            context.Entry((Procedure)model).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}