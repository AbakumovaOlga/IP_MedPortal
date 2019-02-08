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
    public class RecallController : Controller
    {

        private readonly IDoctor service;

        public RecallController()
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
        public ActionResult ListDoctors()
        {
            var list = service.GetList();
            ViewBag.ListDoctors = list;
            return View();
        }

        [HttpGet]
        public ActionResult Recall(string Name, int DoctorId)
        {

            Recall recallModel = service.GetRecall(Name, DoctorId);
            ViewBag.Recalls = recallModel;
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddRecall(int Id)
        {
            var doctor = service.GetElement(Id);
            ViewBag.Doctor = doctor;
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddRecall(Recall recallModel)
        {
            service.AddRecall(recallModel);
            return RedirectToAction("ListDoctors");
        }
    }
}