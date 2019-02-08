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
    public class ProcedureController : Controller
    {

        private readonly IProcedure service;

        public ProcedureController()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["BD"]) == true)
            {
                service = new ProcedureServiceBD();
            }
            else
            {
                service = new ProcedureServiceFile();

            }
        }
       

        [HttpGet]
        public ActionResult Procedures()
        {
            return View(service.GetList());
        }

        [HttpGet]
        public ActionResult AddProcedure()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddProcedure(Procedure model)
        {
            service.AddElement(model);
            return RedirectToAction("Procedures");
        }

        public ActionResult DeleteAuto(int id)
        {
            service.DelElement(id);
            return RedirectToAction("Procedures");
        }
    }
}