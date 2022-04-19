using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Bussiness_Layer_
{
    public class EmployeeBussinessLayer
    {
        public IEnumerable<Employee> employees
        {
            get
            {
                string connection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                List<Employee> employees = new List<Employee>();
                using (SqlConnection conect = new SqlConnection(connection))
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
        public void addemployee(Employee employee)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection conect = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("saveemployee", conect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", employee.name);
                cmd.Parameters.AddWithValue("@gender", employee.gender);
                cmd.Parameters.AddWithValue("@city", employee.city);
                cmd.Parameters.AddWithValue("@Departmentid", employee.Departmentid);
                conect.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void update_employee(Employee employee)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection conect = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("update_employee", conect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", employee.name);
                cmd.Parameters.AddWithValue("@gender", employee.gender);
                cmd.Parameters.AddWithValue("@city", employee.city);
                cmd.Parameters.AddWithValue("@Departmentid", employee.Departmentid);
                cmd.Parameters.AddWithValue("@Employeeid", employee.employeeid);
                conect.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void delete_employee(int id)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection conect = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("delete_employee", conect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employeeid", id);
                conect.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
