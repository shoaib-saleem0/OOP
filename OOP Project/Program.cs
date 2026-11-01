using OOP_Project.EMPLOYEE;
using OOP_Project.MANAGER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    internal class Program
    {
        static public void user()
        {
            PHS main = new PHS();
            while (true)
            {
                Console.Clear();
                string Option = main.MainMenu();

                if (Option == "1")
                {
                    MANAGER_UI mainUI = new MANAGER_UI();
                    bool check = mainUI.pass();
                    if (check == true){
                        break;
                    }
                    

                }
                else if (Option == "2")
                {
                    EMPLOYEE_UI _employeeui = new EMPLOYEE_UI();
                   string employeename = _employeeui.ChooseEmployee();
                   _employeeui.EmployeeDriver(employeename);

                }
                else if (Option == "3")
                {
                    break;
                }
                else
                {

                }

            }
            

        }
        static void Main(string[] args)
        {
            
            user();
        }
    }
}
