using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Ecom.Models;

namespace Ecom.Gateway
{
    public class OrderGateway:BaseGateway
    {
        public List<Order> GetAllOrder()
        {



            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM OrderTable"
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Order> orders = new List<Order>();
            while (reader.Read())
            {
                Order order = new Order()
                {
                    Id = Convert.ToInt32(reader["Id"]),


                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    Address = reader["Address"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    ProductId = Convert.ToInt32(reader["ProductId"]),
                    ProductName = reader["ProductName"].ToString(),
                    ProductPrice = Convert.ToInt32(reader["ProductPrice"]),
                    OrderDetails = reader["OrderDetails"].ToString()

                };
                orders.Add(order);
            }
            reader.Close();
            Connection.Close();
            return orders;

        }
    }
}