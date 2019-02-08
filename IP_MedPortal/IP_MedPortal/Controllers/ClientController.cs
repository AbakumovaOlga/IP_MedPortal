using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;
using WebTransportCompany.Service.ServiceBD;
using WebTransportCompany.Service.ServiceFile;

namespace WebTransportCompany.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClient service;

        public ClientController()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["BD"]) == true)
            {
                service = new ClientServiceBD();
            }
            else
            {
                service = new ClientServiceFile();

            }
        }

        public ActionResult Autorization()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Autorization(Client client)
        {
            if (client.Login != "" && client.Password != "")
            {
                if (service.Authorization(client))
                {
                    FormsAuthentication.SetAuthCookie(client.Login, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }
            return RedirectToAction("Autorization", "Сlient");
        }


        public ActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration1()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(Client client)
        {
            if (client.Login != "" && client.Password != "")
            {
                if (service.Registrations(client))
                {
                    FormsAuthentication.SetAuthCookie(client.Login, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return RedirectToAction("Registration", "Client");
        }

    }
}

