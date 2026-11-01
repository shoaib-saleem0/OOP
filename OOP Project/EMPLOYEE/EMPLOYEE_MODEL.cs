using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.EMPLOYEE
{
    internal class EMPLOYEE_MODEL
    {
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }

        public EMPLOYEE_MODEL(string employeeid, string name, string email, string designation)
        {
            EmployeeID = employeeid;
            Name = name;
            Email = email;
            Designation = designation;
        }
        public string GetEmployeeID()
        {
            string employeeid = EmployeeID;
            return employeeid;
        }
        public string GetName()
        {
            string name = Name;
            return name;
        }
        public string GetEmail()
        {
            string email = Email;
            return email;
        }
        public string GetDesignation()
        {
            string designation = Designation;
            return designation;
        }
        public override string ToString()
        {
            return $"{EmployeeID},{Name},{Email},{Designation}";
        }
    }
}
