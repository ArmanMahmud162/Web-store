using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecom.Gateway;
using Ecom.Models;

namespace Ecom.Controllers
{

    public class GetOrderController : Controller
    {
        private ECommerceEntities1 db = new ECommerceEntities1();
        private OrderGateway gateway = new OrderGateway();
        private ProductGateway gateway1 = new ProductGateway();
        //
        // GET: /GetOrder/
        public ActionResult OrderView()
        {
            ViewBag.category = gateway1.GetAllCategory();
            ViewBag.orders = gateway.GetAllOrder();
            return View();
        }

        public ActionResult Delete(int id)
        {
            string maincon = ConfigurationManager.ConnectionStrings["SSLConString"].ConnectionString;
            // DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(maincon))
            {
                con.Open();
                string query = "Delete FROM OrderTable Where Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();


            }
            return RedirectToAction("OrderView");

        }

        public ActionResult Edit(int id)
        {
            OrderTable orderTable=new OrderTable();
            DataTable dt=new DataTable();
            string maincon = ConfigurationManager.ConnectionStrings["SSLConString"].ConnectionString;
            // DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(maincon))
            {
                con.Open();
                string query = "Select * from OrderTable Where Id=@Id";
                SqlDataAdapter sda=new SqlDataAdapter(query,con);
                sda.SelectCommand.Parameters.AddWithValue("@Id", id);
                sda.Fill(dt);
            }
            if (dt.Rows.Count == 1)
            {
                orderTable.Id = Convert.ToInt32(dt.Rows[0][0].ToString());
                orderTable.Name = dt.Rows[0][1].ToString();
                orderTable.Phone = dt.Rows[0][2].ToString();
                orderTable.Email = dt.Rows[0][3].ToString();
                orderTable.Address = dt.Rows[0][4].ToString();
                orderTable.ProductName = dt.Rows[0][5].ToString();
                orderTable.ProductPrice = Convert.ToInt32(dt.Rows[0][6].ToString());
                orderTable.ProductId = Convert.ToInt32(dt.Rows[0][7].ToString());
                orderTable.OrderDetails = dt.Rows[0][8].ToString();
               
               
            }
            return View(orderTable);
        }

        [HttpPost]

        public ActionResult Edit(OrderTable orderTable)
        {
            string maincon = ConfigurationManager.ConnectionStrings["SSLConString"].ConnectionString;
            // DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(maincon))
            {
                con.Open();
                string query =
                    "Update OrderTable Set Name=@Name,Phone=@Phone,Email=@Email,Address=@Address,ProductName=@ProductName,ProductPrice=@ProductPrice,ProductId=@ProductId,OrderDetails=@OrderDetails Where Id=@Id";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@Id", orderTable.Id);
                cmd.Parameters.AddWithValue("@Name", orderTable.Name);
                cmd.Parameters.AddWithValue("@Phone", orderTable.Phone);
                cmd.Parameters.AddWithValue("@Email", orderTable.Email);
                cmd.Parameters.AddWithValue("@Address", orderTable.Address);
                cmd.Parameters.AddWithValue("@ProductName", orderTable.ProductName);
                cmd.Parameters.AddWithValue("@ProductPrice", orderTable.ProductPrice);
                cmd.Parameters.AddWithValue("@ProductId", orderTable.ProductId);
                cmd.Parameters.AddWithValue("@OrderDetails", orderTable.OrderDetails);
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("OrderView");
        }

    }
}