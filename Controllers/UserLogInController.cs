using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Ecom.Gateway;
using Ecom.Models;

namespace Ecom.Controllers
{
    public class UserLogInController : Controller
    {
        ProductGateway gateway1=new ProductGateway();
        //
        // GET: /UserLogIn/
        public ActionResult Save()
        {
            ViewBag.category = gateway1.GetAllCategory();
            return View();
        }

        [HttpPost]




        public ActionResult Save(UserLogin logInmodel)
        {
            using (ECommerceEntities1 db = new ECommerceEntities1())
            {
                ViewBag.category = gateway1.GetAllCategory();


                var userDetails = db.UserLogins.Where(x => x.Name == logInmodel.Name && x.Password == logInmodel.Password).FirstOrDefault();
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
                    return RedirectToAction("index", "GetProduct");
                }
            }


        }

        public ActionResult Registration()
        {
            Session.Abandon();
            return RedirectToAction("Save", "UserRegistration");
        }
	}
	
}