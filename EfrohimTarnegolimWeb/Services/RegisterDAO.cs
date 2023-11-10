using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using EfrohimTarnegolimWeb.Models;
using System.Data.SqlClient;
using System.Data;

namespace EfrohimTarnegolimWeb.Services
{
    public class RegisterDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Users;" +
            "Integrated Security = True; Connect Timeout = 30; Encrypt=False;" +
            "TrustServerCertificate=False;ApplicationIntent = ReadWrite; MultiSubnetFailover=False";
        
        public void InsertRegisterUserToDatabase(UserModel userModel)
        {
            string sqlStatement = "INSERT INTO Users (FullName, Email, Password) VALUES (@FullName, @Email, @Password)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@FullName", SqlDbType.VarChar, 40).Value = "tomer";
                command.Parameters.AddWithValue("@Email", userModel.Email);
                command.Parameters.AddWithValue("@Password", userModel.Password);
                
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }
    }
}
