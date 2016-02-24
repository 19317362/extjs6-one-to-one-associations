using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.Class.Chapter_Model.model_associations_one_to_one_csharp_backend
{
    public class EmployeesAssociationsOneToOneController : ApiController
    {
        // GET: api/EmployeesAssociationsOneToOne
        public EmployeesPayload Get()
        {
            string countSql = "SELECT COUNT(employeeNumber) FROM `classicmodels`.`employees`";
            string resultsetSql = "SELECT employeeNumber, lastName, firstName, reportsTo as managerNumber FROM `classicmodels`.`employees`";

            return GetEmployeesPayload(countSql, resultsetSql);
        }

        private EmployeesPayload GetEmployeesPayload(string countSql, string resultsetSql)
        {

            EmployeesPayload payload = new EmployeesPayload();
            List<Employee> employees = new List<Employee>();
            payload.Employees = employees;
            int count = 0;

            using (MySqlConnection cn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=root;database=classicmodels;"))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = countSql;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();

                    object countObject = cmd.ExecuteScalar();
                    count = int.Parse(countObject.ToString());
                    payload.Count = count;

                    cmd.CommandText = resultsetSql;
                    cmd.CommandType = System.Data.CommandType.Text;

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee employee = new Employee()
                        {
                            EmployeeNumber = reader.GetInt32(0),
                            LastName = reader.GetString(1),
                            FirstName = reader.GetString(2),
                            ManagerNumber = reader[3] == DBNull.Value ? 0 : reader.GetInt32(3)
                        };
                        employees.Add(employee);
                    }

                    cn.Close();

                }
            }

            return payload;
        }
    }
}
