using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeBussinesLayer
{
    public class DepartmentLayer
    {
       public IEnumerable<Department> get_department
        {
            get
            {
                string connection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                List<Department> departments = new List<Department>();
                using(SqlConnection conect=new SqlConnection(connection))
                {
                    SqlCommand cmd = new SqlCommand("get_departments", conect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conect.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Department department = new Department();
                        department.id = Convert.ToInt32(rdr["id"]);
                        department.name = rdr["name"].ToString();
                        departments.Add(department);
                    }
                    return departments;
                }
            }
        }
    }
}
