using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;

namespace WebTransportCompany.Service.ServiceFile
{
    public class DoctorServiceFile : AbstractService, IDoctor
    {
        string Name = "Doctor";
        new string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Doctor";
        new XmlSerializer xsSubmit = new XmlSerializer(typeof(Doctor));

        public  DoctorServiceFile()
        {
            base.Name = Name;
            base.xsSubmit = xsSubmit;
            base.currentPath = currentPath;
        }

        public void AddRecall(Recall recall)
        {
            Doctor doctor = (Doctor)base.GetElement(recall.DoctorId);
            if (doctor.Recalls.Find(rec => rec.Name.Equals(recall.Name)) != null)
            {
                throw new Exception("Уже есть отзыв с таким номером");
            }
            else
            {
                recall.DoctorId = doctor.Id;
                doctor.Recalls.Add(recall);
                UpdateElement(doctor);
            }
        }

        public Recall GetRecall(string Name, int DoctorId)
        {
            Doctor doctor = (Doctor)base.GetElement(DoctorId);
            Recall recall = doctor.Recalls.FirstOrDefault(rec => rec.Name == Name);
            return recall;
        }
    }
}