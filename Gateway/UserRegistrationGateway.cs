using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Ecom.Models;

namespace Ecom.Gateway
{
    public class UserRegistrationGateway:BaseGateway
    {
        public int Save(UserRegistration registration)
        {

            string query =
                "INSERT INTO UserRegistration (Name,Phone,Email,Address,Password,ConfirmPass) VALUES ('" + registration.Name + "','" + registration.Phone + "','" + registration.Email + "','" + registration.Address + "','" + registration.Password + "','" + registration.ConfirmPass + "')";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = Connection;
            Connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            command.Connection.Close();
            return rowAffected;
        }

        public int Savelogin(UserRegistration registration)
        {

            string query1 =
              "INSERT INTO UserLogin (Name,Password) VALUES ('" + registration.Name + "','" + registration.Password + "')";
            SqlCommand command = new SqlCommand();
            command.CommandText = query1;
            command.Connection = Connection;
            Connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            command.Connection.Close();
            return rowAffected;
        }
        public bool IsEmailExist(string email)
        {
            string query = "SELECT * FROM UserRegistration WHERE Email='" + email + "'";
            SqlCommand Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            bool isCodeExist = Reader.HasRows;
            Connection.Close();
            return isCodeExist;
        }
    }
}