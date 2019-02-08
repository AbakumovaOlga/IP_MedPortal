using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;

namespace WebTransportCompany.Service.ServiceBD
{
    public class DoctorServiceBD : IDoctor
    {
        private MedPortalContext context = new MedPortalContext();

        public void AddElement(BaseModel model)
        {
            context.Doctors.Add((Doctor)model);
            context.SaveChanges();
        }

        public void AddRecall(Recall recall)
        {
            Doctor doctor = context.Doctors.Find(recall.DoctorId);
            if (doctor.Recalls == null)
            {
                doctor.Recalls = new List<Recall>();
            }
            doctor.Recalls.Add(recall);
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Doctor model = context.Doctors.Find(id);
            if (model != null)
            {
                context.Doctors.Remove(model);
                context.SaveChanges();
            }
        }

        public BaseModel GetElement(int id)
        {
            Doctor model = context.Doctors.Find(id);
            return model;
        }

        public List<BaseModel> GetList()
        {
            List<BaseModel> models = new List<BaseModel>();
            List<Doctor> doctors = context.Doctors.ToList();
            List<Recall> recalls = context.Recalls.ToList();
            foreach (Doctor doctor in doctors)
            {
                doctor.Recalls = recalls.FindAll(rec => rec.DoctorId == doctor.Id);
                models.Add(doctor);
            }
            return models;
        }

        public Recall GetRecall(string Name, int DoctorId)
        {
            Recall recall = context.Recalls.FirstOrDefault(rec => rec.Name.Equals(Name) && rec.DoctorId == rec.Doctor.Id);
            return recall;
        }

        public void UpdateElement(BaseModel model)
        {
            context.Entry((Doctor)model).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}