using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecom.Gateway;
using Ecom.Manager;
using Ecom.Models;

namespace Ecom.Controllers
{
    public class GetProductController : Controller
    {
        ECommerceEntities1 db=new ECommerceEntities1();
        //
        // GET: /GetProduct/
        ProductGateway gateway=new ProductGateway();
        [HttpGet]
        public ActionResult GetProductByCatId()
        {
            ViewBag.category = gateway.GetAllCategory();
            // List<Category> categories = gateway.GetAllCategory();
            return View();
        }
        //[HttpPost]
        public ActionResult GetProductByCatId1(int id)
        {
            ViewBag.category = gateway.GetAllCategory();
            ViewBag.products = gateway.GetAllproductsByCategoyId(id);
            //return;
            return View();
        }
        public ActionResult index()
        {
            ViewBag.category = gateway.GetAllCategory();
            ViewBag.products = gateway.GetAllProduct();
            return View();
        }

        public ActionResult ProductDetails(int id)
        {
            ViewBag.category = gateway.GetAllCategory();
            ViewBag.Details = gateway.GetProductDetails(id);

            return View();
        }

        public ActionResult ProductOrder(int id)
        {
            ViewBag.category = gateway.GetAllCategory();
            ViewBag.Details = gateway.GetProductDetails(id);

            return View();
        }

        [HttpPost]
        public ActionResult ProductOrder(Order order)
        {
            ViewBag.category = gateway.GetAllCategory();
            ProductsManager manager = new ProductsManager();
            string message = manager.ProductOrder(order);
            ViewBag.Message = message;
           // return View();
           // return RedirectToAction(“ProductDetails”,”GetProduct”);
            return RedirectToAction("index");
        }



        public ActionResult Index2()
        {
              ViewBag.category = gateway.GetAllCategory();
              ViewBag.products = gateway.GetAllProduct();
            return View();
        }

        

	}
}