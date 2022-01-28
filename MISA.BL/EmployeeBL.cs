using MISA.CukCuk.Entities;
using MISA.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL
{
    public class EmployeeBL
    {
        private EmployeeDL employeeDL = new EmployeeDL();

        public IEnumerable<Employee> GetEmployees()
        {
            return employeeDL.GetEmployees();
        }

        public Employee GetEmployee(Guid employeeID)
        {
            return employeeDL.GetEmployee(employeeID);
        }

        public int InsertEmployee(Employee employee)
        {
            return employeeDL.InsertEmployee(employee);
        }

        public int UpdateEmployee(Employee employee)
        {
            return employeeDL.UpdateEmployee(employee);
        }

        public int DeleteEmployee(Guid employeeID)
        {
            return employeeDL.DeleteEmployee(employeeID);
        }
    }
}
