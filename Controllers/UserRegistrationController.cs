using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecom.Gateway;
using Ecom.Manager;
using Ecom.Models;

namespace Ecom.Controllers
{
    public class UserRegistrationController : Controller
    {
        ProductGateway gateway=new ProductGateway();
        //
        // GET: /UserRegistration/
        public ActionResult Save()
        {
            ViewBag.category = gateway.GetAllCategory();
            return View();
        }
        [HttpPost]
        public ActionResult Save(UserRegistration registration)
        {
            ViewBag.category = gateway.GetAllCategory();
            UserRegistrationManager manager = new UserRegistrationManager();
            string message = manager.Save(registration);
            ViewBag.Message = message;
            return View();
        }
        public ActionResult Registration()
        {
            Session.Abandon();
            return RedirectToAction("Save", "UserLogIn");
        }
	}
}