using MISA.CukCuk.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MISA.CukCuk.Controllers
{
    [RoutePrefix("employees")]
    public class EmployeeController : ApiController
    {
        [Route("")]
        public IEnumerable<Employee> Get()
        {
            //string connectionString = "Server=DESKTOP-IKO3LOH;Database=CukCuk;User Id=sa;Password=123;";
            //SqlConnection sqlConnection = new SqlConnection(connectionString);

            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //sqlCommand.CommandText = "SELECT * FROM Customer";

            //sqlConnection.Open();
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            return Employee.EmployeeList;
        }

        [Route("{employeeCode}")]
        public Employee Get(string employeeCode)
        {
            return Employee.EmployeeList.FirstOrDefault(e => e.EmployeeCode == employeeCode);
        }

        [Route("")]
        public void Post([FromBody] Employee employee)
        {
            Employee.EmployeeList.Add(employee);
        }

        [Route("")]
        public bool Put([FromBody] Employee employee)
        {
            Employee emp = Employee.EmployeeList.FirstOrDefault(e => e.EmployeeCode == employee.EmployeeCode);
            Employee.EmployeeList.Remove(emp);
            Employee.EmployeeList.Add(employee);
            return true;
        }

        [HttpDelete]
        [Route("{employeeCode}")]
        public bool Delete(string employeeCode)
        {
            Employee emp = Employee.EmployeeList.FirstOrDefault(e => e.EmployeeCode == employeeCode);
            if (emp != null)
            {
                Employee.EmployeeList.Remove(emp);
                return true;
            }
            return false;
        }
    }
}
