using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Ecom.Models;

namespace Ecom.Gateway
{
    public class ProductGateway:BaseGateway
    {
        public List<Category> GetAllCategory()
        {



            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM Category"
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Category> categories = new List<Category>();
            while (reader.Read())
            {
                Category category = new Category()
                {
                    Id = Convert.ToInt32(reader["Id"]),


                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                };
                categories.Add(category);
            }
            reader.Close();
            Connection.Close();
            return categories;

        }

        public List<SubCategory> GetAllSubCategoriesByCategoyId(int categoryId)
        {

            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM SubCategory where CategoryId=" + categoryId
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<SubCategory> subCategories = new List<SubCategory>();
            while (reader.Read())
            {
                SubCategory subCategory = new SubCategory()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    CategoryId = (int)reader["CategoryId"],
                    // Code = reader["Code"].ToString(),
                    Name = reader["Name"].ToString()

                };
                subCategories.Add(subCategory);

            }
            reader.Close();
            Connection.Close();
            return subCategories;
        }


        public List<Product> GetAllProduct()
        {



            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM Product"
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product()
                {
                    Id = Convert.ToInt32(reader["Id"]),


                    Name = reader["Name"].ToString(),
                    Price = Convert.ToInt32(reader["Price"]),
                    Description = reader["Description"].ToString(),
                    Image = reader["Image"].ToString(),
                };
                products.Add(product);
            }
            reader.Close();
            Connection.Close();
            return products;

        }



        public List<Product> GetAllproductsByCategoyId(int categoryId)
        {

            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM Product where CatId=" + categoryId
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                  
                    Name = reader["Name"].ToString(),
                    Price = Convert.ToInt32(reader["Price"]),
                    Description = reader["Description"].ToString(),
                    Image = reader["Image"].ToString(),
                    SubcatId = Convert.ToInt32(reader["SubcatId"]),
                    CatId = Convert.ToInt32(reader["CatId"])
                };
                products.Add(product);

            }
            reader.Close();
            Connection.Close();
            return products;
        }


        public Product GetProductDetails(int productId)
        {
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM Product Where Id=" + productId
            };
            Connection.Open();
            Product product = null;
            Reader = command.ExecuteReader();
            if (Reader.Read())
            {
                product = new Product();
                product.Id = Convert.ToInt32(Reader["Id"]);
                product.Name = Reader["Name"].ToString();
                product.Price = Convert.ToInt32(Reader["Price"]);
                product.Description = Reader["Description"].ToString();
                product.Image = Reader["Image"].ToString();
            }
            Connection.Close();
            return product;
        }


        public int ProductOrder(Order order)
        {

            string query =
                "INSERT INTO OrderTable (Name,Email,Address,ProductName,ProductPrice,ProductId,OrderDetails,Phone) VALUES ('" + order.Name + "','" + 
                order.Email + "','" + order.Address + "'," +
                "'" + order.ProductName + "','" + order.ProductPrice + "','" + order.ProductId + "','" + order.OrderDetails + "','" + order.Phone + "')";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = Connection;
            Connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            command.Connection.Close();
            return rowAffected;
        }

    }
}