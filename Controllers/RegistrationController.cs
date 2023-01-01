using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecom.Manager;
using Ecom.Models;

namespace Ecom.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Registration/
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Registration registration)
        {
            RegistrationManager manager = new RegistrationManager();
            string message = manager.Save(registration);
            ViewBag.Message = message;
            return View();
        }
        public ActionResult Registration()
        {
            Session.Abandon();
            return RedirectToAction("Save", "LogIn");
        }
	}
}