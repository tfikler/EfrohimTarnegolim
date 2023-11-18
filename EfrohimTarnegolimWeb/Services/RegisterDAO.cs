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
            string sqlStatement = "INSERT INTO RegisteredUsers (FullName, Email, Password, IDNumber, YearOfStudies) VALUES (@FullName, @Email, @Password, @IDNumber, @YearOfStudies)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@FullName", SqlDbType.NChar, 40).Value = userModel.FullName;
                command.Parameters.Add("@Email", SqlDbType.VarChar, 40).Value = userModel.Email;
                command.Parameters.Add("@Password", SqlDbType.VarChar, 40).Value=userModel.Password;
                command.Parameters.Add("@IDNumber", SqlDbType.VarChar, 40).Value = userModel.IDNumber;
                command.Parameters.Add("@YearOfStudies", SqlDbType.VarChar, 40).Value = userModel.YearOfStudies;

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
