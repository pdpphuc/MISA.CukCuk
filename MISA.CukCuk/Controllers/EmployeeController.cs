using MISA.BL;
using MISA.CukCuk.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MISA.CukCuk.Controllers
{
    [RoutePrefix("api/v1/employees")]
    public class EmployeeController : ApiController
    {
        private EmployeeBL employeeBL = new EmployeeBL();

        [Route("")]
        public IEnumerable<Employee> Get()
        {
            return employeeBL.GetEmployees();
        }

        [Route("{employeeID}")]
        public Employee Get(Guid employeeID)
        {
            return employeeBL.GetEmployee(employeeID);
        }

        [Route("")]
        public int Post([FromBody] Employee employee)
        {
            return employeeBL.InsertEmployee(employee);
        }

        [Route("")]
        public int Put([FromBody] Employee employee)
        {
            return employeeBL.UpdateEmployee(employee);
        }

        [HttpDelete]
        [Route("{employeeID}")]
        public int Delete(Guid employeeID)
        {
            return employeeBL.DeleteEmployee(employeeID);
        }
    }
}
