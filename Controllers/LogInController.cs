using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecom.Models;

namespace Ecom.Controllers
{
    public class LogInController : Controller
    {
        //
        // GET: /LogIn/
        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]




        public ActionResult Save(LogIn logInmodel)
        {
            using (ECommerceEntities1 db = new ECommerceEntities1())
            {


                var userDetails = db.LogIns.Where(x => x.Name == logInmodel.Name && x.Password == logInmodel.Password).FirstOrDefault();
                // var userDetails = db.Logins.FirstOrDefault(x => x.Name == logInmodel.Name && x.Password == logInmodel.Password);


                // ReSharper disable once ReplaceWithSingleCallToFirstOrDefault
                // var v = db.Logins.Where(a => a.Name == logInmodel.Name).FirstOrDefault();
                if (userDetails == null)
                {

                    ViewBag.Message = "Invalid Name or Password";
                    // logInmodel.LoginErrorMessage = "Invalid Name or Password";
                    return View();

                }
                else
                {
                    Session["Id"] = userDetails.Id;
                    return RedirectToAction("Create", "Category");
                }
            }


        }

        public ActionResult Registration()
        {
            Session.Abandon();
            return RedirectToAction("Save", "Registration");
        }
	}
}