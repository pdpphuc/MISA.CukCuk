using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.CukCuk.Entities
{
    public class Employee
    {
        //public static List<Employee> EmployeeList = new List<Employee>() 
        //{
        //    new Employee("NV001", "Phạm Đức Phú Phúc", "phuphuc@gmail.com", "0992921847", "Công ty cổ phần MISA", "Lagi, Bình Thuận"),
        //    new Employee("NV002", "Nguyễn Thị Hiền", "hien707@gmail.com", "0992984243", "Công ty cổ phần MISA", "Cầu Giấy, Hà Nội"),
        //    new Employee("NV003", "Trần Văn Tuấn", "tuantv@gmail.com", "0992938492", "Công ty cổ phần MISA", "Quận 9, TP.HCM"),
        //    new Employee("NV004", "Trần Văn Tuấn", "tuantv@gmail.com", "0992938492", "Công ty cổ phần MISA", "Quận 9, TP.HCM"),
        //    new Employee("NV005", "Trần Văn Tuấn", "tuantv@gmail.com", "0992938492", "Công ty cổ phần MISA", "Quận 9, TP.HCM"),
        //    new Employee("NV006", "Trần Văn Tuấn", "tuantv@gmail.com", "0992938492", "Công ty cổ phần MISA", "Quận 9, TP.HCM"),
        //    new Employee("NV007", "Trần Văn Tuấn", "tuantv@gmail.com", "0992938492", "Công ty cổ phần MISA", "Quận 9, TP.HCM")
        //};
        public Guid EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }

        //public Employee(string employeeCode, string employeeName, string email, string phone, string companyName, string address)
        //{
        //    EmployeeCode = employeeCode;
        //    EmployeeName = employeeName;
        //    Email = email;
        //    Phone = phone;
        //    CompanyName = companyName;
        //    Address = address;
        //}
    }
}