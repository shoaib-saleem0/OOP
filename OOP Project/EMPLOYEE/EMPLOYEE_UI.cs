using OOP_Project.MANAGER;
using OOP_Project.PROJECTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.EMPLOYEE
{
    internal class EMPLOYEE_UI
    {
        EMPLOYEE_LOGIC _employeelogic = new EMPLOYEE_LOGIC();
        EMPLOYEE_REPO _employeerepo = new EMPLOYEE_REPO();
        Projects_Repository _projectrepo = new Projects_Repository();
        public void EmployeeDriver(string employeename)
        {
            while(true){
                Console.Clear();
                EmployeesHeader(employeename);
            string option = EmployeesMenu();
                if (option == "1")
                {
                    ViewAssignedProjects(employeename);
                    Console.WriteLine("Press Any Key To Continue");
                    Console.ReadKey();
                }
                else if (option == "2")
                {
                    Console.Clear();
                    UpdateStatus(employeename);
                }
                else if (option == "3")
                {
                    Console.Clear();
                    MarkComplete(employeename);
                }
                else if (option == "4")
                {
                    Console.Clear();
                    ViewDeadlines(employeename);
                    Console.WriteLine("Press Any Key To Continue");
                    Console.ReadKey();

                }
                else if (option == "5")
                {
                    Console.Clear();
                    SearchTask(employeename);
                }
                else if (option == "6")
                {
                    Console.Clear();
                    ShowNoofProjects(employeename);
                    Console.WriteLine("Press Any Key To Continue");
                    Console.ReadKey();
                }
                else if (option == "7")
                {
                    CompletedProjects(employeename);
                    Console.WriteLine("Press Any Key To Continue");
                    Console.ReadKey();
                }
                else if (option == "8")
                {
                    Console.Clear();
                    PendingProjects(employeename);
                    Console.WriteLine("Press Any Key To Continue");
                    Console.ReadKey();
                }
                else if (option == "9")
                {
                    Console.Clear();
                    viewnotes(employeename);
                    Console.WriteLine("Press Any Key To Continue");
                    Console.ReadKey();
                }
                else if (option == "10")
                {
                    break;
                }
            }
        }
       
        public string EmployeesMenu()
        {
            Console.WriteLine("1.VIEW ASSIGNED PROJECTS");
            Console.WriteLine("2.UPDATE STATUS");
            Console.WriteLine("3.MARK COMPLETE");
            Console.WriteLine("4.VIEW DEADLINES");
            Console.WriteLine("5.SEARCH TASK");
            Console.WriteLine("6.SHOW NUMBER OF PROJECTS");
            Console.WriteLine("7.VIEW COMPLETED PROJECTS");
            Console.WriteLine("8.VIEW PENDING PROJECTS");
            Console.WriteLine("9.VIEW ADDED NOTES");
            Console.WriteLine("10.EXIT");
            Console.WriteLine("Choose an Option(1-10): ");
            string option = Console.ReadLine();
            return option;
        }
        public void viewnotes(string employeename)
        {
            Console.Clear();
            Console.WriteLine("================================================================");
            Console.WriteLine("========================== VIEW NOTES ==========================");
            Console.WriteLine("================================================================");
            List<Projects_Model> list = _employeelogic.readprojectsdata();
            int count = 0;
            Console.WriteLine("NO. \tTitle\t\tNotes");
            foreach (Projects_Model model in list)
            {
                if (model.EmployeeName == employeename)
                {
                    Console.WriteLine(count + " \t" + model.GetTitle() + "\t" +model.GetNote());


                }
                count++;
            }
        }
        public void PendingProjects(string employeename)
        {
            Console.Clear();
            Console.WriteLine("================================================================");
            Console.WriteLine("======================== PENDING PROJECTS ======================");
            Console.WriteLine("================================================================");
            DisplayList(_employeelogic.pendingprojects(employeename));        }
        public void DisplayList(List<Projects_Model> list)
        {
            Console.Clear();

            int count = 0;
            Console.WriteLine("NO. \tTitle\t\tTasks\t\t\tDeadline\tPriority\tStatus");
            foreach (Projects_Model model in list)
            {

                Console.WriteLine(count + " " + model.GetTitle() + "\t" + model.GetTask() + "\t    " + model.GetDeadline() + "\t\t" + model.GetPriority() + "\t\t" + model.GetStatus());

                count++;
            }
        }
        public void CompletedProjects(string employeename)
        {
            Console.Clear();
            Console.WriteLine("================================================================");
            Console.WriteLine("======================= COMPLETED PROJECTS =====================");
            Console.WriteLine("================================================================");
            DisplayList(_employeelogic.completedprojects(employeename));
        }
        public void ShowNoofProjects(string employeename)
        {
            Console.Clear();
            Console.WriteLine("================================================================");
            Console.WriteLine("======================== ASSIGNED PROJECTS =====================");
            Console.WriteLine("================================================================");
            Console.WriteLine("The Number Of Projects Assigned To You Are");
            int count = _employeelogic.countprojects(employeename);
            Console.WriteLine(count);
        }
        public void SearchTask(string employeename)
        {
            Console.Clear();
            Console.WriteLine("================================================================");
            Console.WriteLine("========================= SEARCH BY TASK =======================");
            Console.WriteLine("================================================================");
            Console.WriteLine("Enter Task to Search");
            string task = Console.ReadLine();
            Projects_Model model = _employeelogic.searchtask(employeename,task);
            if(model == null)
            {
                Console.WriteLine("NO TASK FOUND");
            }
            else
            {
                Console.WriteLine("Title\t\tTasks\t\t\tDeadline\tPriority\tStatus");
                Console.WriteLine(model.GetTitle() + "\t" + model.GetTask() + "\t    " + model.GetDeadline() + "\t\t" + model.GetPriority() + "\t\t" + model.GetStatus());
                Console.WriteLine("Press Any Key To Continue!");
                Console.ReadKey();
            }

        }
        public void ViewDeadlines(string employeename)
        {
            Console.Clear();
            Console.WriteLine("================================================================");
            Console.WriteLine("========================== VIEW DEADLINES ======================");
            Console.WriteLine("================================================================");
            List<Projects_Model> list = _employeelogic.readprojectsdata();
            int count = 0;
            Console.WriteLine("NO. \tTitle\t\tDeadline\tPriority");
            foreach (Projects_Model model in list)
            {
                if(model.EmployeeName == employeename)
                {
                    Console.WriteLine(count + "\t" + model.GetTitle() + "\t" + model.GetDeadline() + "\t\t" + model.GetPriority());
                        
                    
                }
                count++;
            }

        }
        public void MarkComplete(string employeename)
        {
            Console.Clear();
            Console.WriteLine("================================================================");
            Console.WriteLine("======================== MARK AS COMPLETE ======================");
            Console.WriteLine("================================================================");
            ViewAssignedProjects(employeename);
            Console.WriteLine("Enter Project No. You Wanna Marked as Complete: ");
            int choice = int.Parse(Console.ReadLine());
            _employeelogic.markascomplete(choice,"Complete");
        }
        public void UpdateStatus(string employeename)
        {
            Console.Clear();
            Console.WriteLine("================================================================");
            Console.WriteLine("======================= UPDATE TASK STATUS =====================");
            Console.WriteLine("================================================================");
            ViewAssignedProjects(employeename);
            Console.WriteLine("Enter Project No. To Update Status of: ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Status To Update: ");
            string status = Console.ReadLine();
            _employeelogic.updatestatus(choice,status);
        }

        public string ChooseEmployee()
        {
            Console.Clear();

            Console.WriteLine("================================================================");
            Console.WriteLine("======================== CHOOSE EMPLOYEE =======================");
            Console.WriteLine("================================================================");
            ViewEmployees();
            Console.WriteLine("Select Employee NO. To Continue: ");
            int choice = int.Parse(Console.ReadLine());
            string employeename = _employeelogic.searchemployee(choice);
            return employeename;
        }
        public void EmployeesHeader(string employeename)
        {
            Console.WriteLine("===============================");
            Console.WriteLine($"        WELCOME {employeename}   ");
            Console.WriteLine("===============================");
            Console.WriteLine("        EMPLOYEE MENU          ");
            Console.WriteLine("===============================");

        }
        
        public void ViewAssignedProjects(string employeename)
        {
            Console.Clear();
            Console.WriteLine("================================================================");
            Console.WriteLine("======================== VIEW ALL PROJECTS =====================");
            Console.WriteLine("================================================================");
            List<Projects_Model> list = _employeelogic.readprojectsdata();
            int count = 0;
            Console.WriteLine("NO. \tTitle\t\tTasks\t\tDeadline\tPriority\tStatus");
            foreach (Projects_Model model in list)
            {
                if(model.EmployeeName == employeename)
                {
                    Console.WriteLine(count + " " + model.GetTitle() + "\t" + model.GetTask() + "\t    " + model.GetDeadline() + "\t\t" + model.GetPriority() + "\t\t" + model.GetStatus());
                    
                }
                count++;
            }
            
        }
        public void ViewEmployees()
        {
            List<EMPLOYEE_MODEL> list = _employeelogic.readalldata();
            int count = 0;
            Console.WriteLine("NO.\tEmployeeID\tNAME");
            foreach (EMPLOYEE_MODEL each in list)
            {
                Console.WriteLine(count + "\t" + each.GetEmployeeID() + "\t\t" + each.GetName());
                count++;
            }
            
            
        }
    }
}
