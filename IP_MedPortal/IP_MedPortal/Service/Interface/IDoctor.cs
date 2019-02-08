using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTransportCompany.Models;

namespace WebTransportCompany.Service.Interface
{
    public interface IDoctor :IMain
    {
        void AddRecall(Recall recall);
        Recall GetRecall(string Name, int DoctorId);
    }
}