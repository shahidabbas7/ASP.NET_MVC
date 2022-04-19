using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace DisplayNameandDisplayFormate.Models
{
    public class EmployeeLayer
    {
        public void update_employee(tblEmployee employee)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection conect = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("update_employee", conect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FullName", employee.FullName);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Age", employee.Age);
                cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
                cmd.Parameters.AddWithValue("@EmailAddress", employee.EmailAddress);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@PersonalWebSite", employee.PersonalWebSite);
                conect.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}