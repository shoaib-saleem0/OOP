using OOP_Project.EMPLOYEE;
using OOP_Project.MANAGER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    internal class PHS
    {
        //MAIN MENU OF THE APP
        static public void user()
        {            while (true)
            {
                Console.Clear();
                string Option = MainMenu();

                if (Option == "1")
                {
                    MANAGER_UI mainUI = new MANAGER_UI();
                    bool check = mainUI.pass();
                    if (check == true)
                    {
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
        static public string MainMenu()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("========================================");
            Console.WriteLine("         PROJECT HANDLING SYSTEM        ");
            Console.WriteLine("========================================");
            Console.WriteLine("========================================");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine("                 USER                   ");
            Console.WriteLine();
            Console.WriteLine("1.MANAGER");
            Console.WriteLine("2.EMPLOYEE");
            Console.WriteLine("3.EXIT");
            Console.WriteLine("SELECT AN OPTION:");
            string Option = Console.ReadLine();
            return Option;
        }
    }
}
