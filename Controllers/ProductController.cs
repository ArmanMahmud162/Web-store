using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecom.Gateway;
using Ecom.Models;

namespace Ecom.Controllers
{
    public class ProductController : Controller
    {
        ProductGateway gateway=new ProductGateway();

        ECommerceEntities1 db=new ECommerceEntities1();
        //
        // GET: /Producr/
        public ActionResult Save()
        {
            //var getCategoryList = db.Categories.ToList();
            //SelectList list=new SelectList(getCategoryList,"Id","Name");
            //ViewBag.categoryName = list;
            ViewBag.category = gateway.GetAllCategory();
            return View();
        }
        [HttpPost]

        public ActionResult Save(Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(file.FileName));
                file.SaveAs(path);
                db.Products.Add(new Product
                {
                    CatId = product.CatId,
                    SubcatId = product.SubcatId,
                    Name=product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    Image  ="~/Images/"+file.FileName
                });
                db.SaveChanges();
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            ViewBag.category = gateway.GetAllCategory();
            //ViewBag.menu_id = new SelectList(db.Menus, "id", "name", item.menu_id);
           // return View(product);
            return RedirectToAction("ViewProduct");
        }


        //public ActionResult GetAllproductsByCategoyId(int categoryId)
        //{D:\ssl work\work\Ecom\Ecom\Controllers\ProductController.cs
        //    ViewBag.getProduct = gateway.GetAllproductsByCategoyId(categoryId);
        //    return View();
        //}
        //[HttpGet]
        //public ActionResult GetAllproductsByCategoyId()
        //{
        //    ViewBag.category = gateway.GetAllCategory();
        //    //ViewBag.getProduct = gateway.GetAllproductsByCategoyId(categoryId);
        //    return View();
        //}
      
        //public ActionResult GetAllproductsByCategoyId(int categoryId)
        //{
        //    ViewBag.category = gateway.GetAllCategory();
        //    ViewBag.getProduct = gateway.GetAllproductsByCategoyId(categoryId);
        //    return View();
        //}

        public ActionResult ViewProduct()
        {
            ProductGateway gateway = new ProductGateway();
            ViewBag.viewProduct = gateway.GetAllProduct();
           // ViewBag.category = gateway.GetAllCategory();
            
            return View();
        }

        //public ActionResult ViewIndex()
        //{
        //    //string maincon = ConfigurationManager.ConnectionStrings["SSLConString"].ConnectionString;
        //    //DataTable dt = new DataTable();
        //    //using (SqlConnection con = new SqlConnection(maincon))
        //    //{
        //    //    con.Open();
        //    //    string query = "SELECT * FROM Product";
        //    //    SqlDataAdapter sda = new SqlDataAdapter(query, con);
        //    //    sda.Fill(dt);
        //    //    con.Close();

        //    //}
        //    ViewBag.category = gateway.GetAllCategory();
        //    return View();

        //}


        public ActionResult Delete(int id)
        {
            string maincon = ConfigurationManager.ConnectionStrings["SSLConString"].ConnectionString;
            // DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(maincon))
            {
                con.Open();
                string query = "Delete FROM Product Where Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();


            }
            return RedirectToAction("ViewProduct");

        }

        //public ActionResult Save(Product pc, HttpPostedFileBase file)
        //{
        //    string maincon = ConfigurationManager.ConnectionStrings["SSLConString"].ConnectionString;
        //    SqlConnection sqlcon = new SqlConnection(maincon);
        //    string query =
        //        "INSERT INTO Product (CatId,SubcatId,Name,Price,Description,Image) VALUES ('" + pc.CatId + "','" + pc.SubcatId + "','" + pc.Name + "','" + pc.Price + "','" + pc.Description + "','" + pc.Image + "')";
        //    SqlCommand sqlcomm = new SqlCommand(query, sqlcon);
        //    sqlcon.Open();
        //    sqlcomm.Parameters.AddWithValue("@CatId", pc.CatId);
        //    sqlcomm.Parameters.AddWithValue("@SubcatId", pc.SubcatId);
        //    sqlcomm.Parameters.AddWithValue("@Name", pc.Name);
        //    sqlcomm.Parameters.AddWithValue("@Price", pc.Price);
        //    sqlcomm.Parameters.AddWithValue("@Description", pc.Description);



        //    if (file != null && file.ContentLength > 0)
        //    {
        //        string filename = Path.GetFileName(file.FileName);
        //        string imgpth = Path.Combine(Server.MapPath("~/Images/"), filename);
        //        file.SaveAs(imgpth);
        //        pc.Image = filename;
        //        sqlcomm.Parameters.AddWithValue("@Image", pc.Image);
        //    }
        //   // if (file != null) sqlcomm.Parameters.AddWithValue("@Image", "~/Images/" + file.FileName);

        //    sqlcomm.ExecuteNonQuery();
        //    sqlcon.Close();
        //    return View();
        //}
        [HttpPost]
        public JsonResult GetAllSubCategoriesByCategoyId(int categoryId)
        {
            var subCategory = gateway.GetAllSubCategoriesByCategoyId(categoryId);
            return Json(subCategory);
        }
	}
}