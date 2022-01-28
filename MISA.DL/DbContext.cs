using MISA.CukCuk.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL
{
    public class DbContext : IDisposable
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        public DbContext()
        {
            string connectionString = "Server=DESKTOP-IKO3LOH;Database=CukCuk;User Id=sa;Password=123;";
            sqlConnection = new SqlConnection(connectionString);

            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        }

        private IEnumerable<Employee> ExecuteDataReader()
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while(sqlDataReader.Read())
            {
                Employee emp = new Employee();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    string colName = sqlDataReader.GetName(i);
                    object value = sqlDataReader.GetValue(i);
                    PropertyInfo property = emp.GetType().GetProperty(colName);
                    if (property != null && value != DBNull.Value)
                    {
                        property.SetValue(emp, value);
                    }
                }
                yield return emp;
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            sqlCommand.CommandText = "dbo.SP_GetEmployees";
            return ExecuteDataReader();
        }

        public Employee GetEmployee(Guid employeeID)
        {
            sqlCommand.CommandText = "dbo.SP_GetEmployees";
            return ExecuteDataReader().FirstOrDefault(e => e.EmployeeID == employeeID);
        }

        public int InsertEmployee(Employee employee)
        {
            sqlCommand.CommandText = "dbo.SP_InsertEmployee";
            sqlCommand.Parameters.AddWithValue("@EmployeeID", Guid.NewGuid());
            sqlCommand.Parameters.AddWithValue("@EmployeeCode", employee.EmployeeCode);
            sqlCommand.Parameters.AddWithValue("@FullName", employee.FullName);
            sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
            sqlCommand.Parameters.AddWithValue("@Phone", employee.Phone);
            sqlCommand.Parameters.AddWithValue("@Address", employee.Address);
            sqlConnection.Open();
            return sqlCommand.ExecuteNonQuery();
        }

        public int UpdateEmployee(Employee employee)
        {
            sqlCommand.CommandText = "dbo.SP_UpdateEmployee";
            sqlCommand.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID); ;
            sqlCommand.Parameters.AddWithValue("@EmployeeCode", employee.EmployeeCode);
            sqlCommand.Parameters.AddWithValue("@FullName", employee.FullName);
            sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
            sqlCommand.Parameters.AddWithValue("@Phone", employee.Phone);
            sqlCommand.Parameters.AddWithValue("@Address", employee.Address);
            sqlConnection.Open();
            return sqlCommand.ExecuteNonQuery();
        }

        public int DeleteEmployee(Guid employeeID)
        {
            sqlCommand.CommandText = "dbo.SP_DeleteEmployee";
            sqlCommand.Parameters.AddWithValue("@EmployeeID", employeeID); ;
            sqlConnection.Open();
            return sqlCommand.ExecuteNonQuery();
        }

        public void Dispose()
        {
            sqlConnection.Close();
        }
    }
}
