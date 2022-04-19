using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BussinessLayer
{
    class EmployeeBussinessLayer
    {
        public IEnumerable<Employee> Employees

        {
            get
            {
                string connectionstring = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                List<Employee> employees = new List<Employee>();
                using(SqlConnection conect=new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("getemployeeSp", conect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conect.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.employeeid = Convert.ToInt32(rdr["employeeid"]);
                        employee.name = rdr["name"].ToString();
                        employee.gender = rdr["gender"].ToString();
                        employee.city = rdr["city"].ToString();
                        employee.Departmentid = Convert.ToInt32(rdr["Departmentid"]);
                        employees.Add(employee);
                    }
                }
                return employees;
            }
            
            
        }
    }
}
