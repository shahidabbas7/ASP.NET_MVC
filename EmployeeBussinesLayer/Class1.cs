using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeBussinesLayer
{
    public class EmployeeLayer
    {
      public  IEnumerable<Employee> GetEmployees
        {
            get
            {
                string conection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                List<Employee> employees = new List<Employee>();
                using (SqlConnection conect = new SqlConnection(conection))
                {
                    SqlCommand cmd = new SqlCommand("getemployeeSp", conect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conect.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.employeeid = Convert.ToInt32(rdr["employeeid"]);
                        employee.name = rdr["name"].ToString();
                        employee.gender = rdr["gender"].ToString();
                        employee.city = rdr["city"].ToString();
                        employee.Departmentid = Convert.ToInt32(rdr["Departmentid"]);
                        employees.Add(employee);
                    }
                    return employees;
                }
            }
        }
      public void add_employee(Employee employee)
        {
            string conection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            
            using (SqlConnection conect = new SqlConnection(conection))
            {
                SqlCommand cmd = new SqlCommand("saveemployee", conect);
                cmd.CommandType = CommandType.StoredProcedure;
                conect.Open();
                cmd.Parameters.AddWithValue("@name", employee.name);
                cmd.Parameters.AddWithValue("@gender", employee.gender);
                cmd.Parameters.AddWithValue("@city", employee.city);
                cmd.Parameters.AddWithValue("@Departmentid", employee.Departmentid);
                cmd.ExecuteNonQuery();
            }
            }  
      public void update_employee(Employee employee)
        {
            string conection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection conect = new SqlConnection(conection))
            {
                SqlCommand cmd = new SqlCommand("update_employee", conect);
                cmd.CommandType = CommandType.StoredProcedure;
                conect.Open();
                cmd.Parameters.AddWithValue("@name", employee.name);
                cmd.Parameters.AddWithValue("@gender", employee.gender);
                cmd.Parameters.AddWithValue("@city", employee.city);
                cmd.Parameters.AddWithValue("@Departmentid", employee.Departmentid);
                cmd.Parameters.AddWithValue("@Employeeid", employee.employeeid);
                cmd.ExecuteNonQuery();
            }
        }
     public void delete_employee(int id)
        {
            String connection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using(SqlConnection conect=new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("delete_employee", conect);
                cmd.CommandType = CommandType.StoredProcedure;
                conect.Open();
                cmd.Parameters.AddWithValue("@employeeid", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
