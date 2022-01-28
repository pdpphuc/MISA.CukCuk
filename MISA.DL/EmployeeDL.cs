using MISA.CukCuk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL
{
    public class EmployeeDL
    {
        public IEnumerable<Employee> GetEmployees()
        {
            using(DbContext db = new DbContext())
            {
               return db.GetEmployees();
            }
        }

        public Employee GetEmployee(Guid employeeID)
        {
            using (DbContext db = new DbContext())
            {
                return db.GetEmployee(employeeID);
            }
        }

        public int InsertEmployee(Employee employee)
        {
            using (DbContext db = new DbContext())
            {
                return db.InsertEmployee(employee);
            }
        }

        public int UpdateEmployee(Employee employee)
        {
            using (DbContext db = new DbContext())
            {
                return db.UpdateEmployee(employee);
            }
        }

        public int DeleteEmployee(Guid employeeID)
        {
            using (DbContext db = new DbContext())
            {
                return db.DeleteEmployee(employeeID);
            }
        }
    }
}
