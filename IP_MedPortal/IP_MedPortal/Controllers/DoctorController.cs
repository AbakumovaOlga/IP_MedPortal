using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;
using WebTransportCompany.Service.ServiceBD;
using WebTransportCompany.Service.ServiceFile;

namespace WebTransportCompany.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctor service;

        public DoctorController()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["BD"]) == true)
            {
                service = new DoctorServiceBD();
            }
            else
            {
                service = new DoctorServiceFile();

            }
        }

        [HttpGet]
        public ActionResult Doctors()
        {
            return View(service.GetList());
        }

        [HttpGet]
        public ActionResult AddDoctor()

        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddDoctor(Doctor doctor)
        {
            service.AddElement(doctor);
            return RedirectToAction("Doctors");
        }

        public ActionResult DeleteDoctor(int id)
        {
            service.DelElement(id);
            return RedirectToAction("Doctors");
        }
    }
}