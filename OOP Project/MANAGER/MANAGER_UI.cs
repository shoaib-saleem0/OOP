using OOP_Project.EMPLOYEE;
using OOP_Project.PROJECTS;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_Project.MANAGER
{
    internal class MANAGER_UI
    {
        MANAGER_LOGIC _managerlogic = new MANAGER_LOGIC();
        Projects_Repository _projectsrepo = new Projects_Repository();
        EMPLOYEE_REPO _employeerepo = new EMPLOYEE_REPO();
        ManagerModel _managermodel = new ManagerModel();
        public string ManagerMenu()
        {
            Console.Clear();
            Console.WriteLine("                 WELCOME                 ");
            Console.WriteLine("========================================");
            Console.WriteLine($"                 {_managermodel.Name}     ");
            Console.WriteLine("========================================");
            Console.WriteLine("========================================");
            Console.WriteLine("              MANAGER MENU              ");
            Console.WriteLine("========================================");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine("1.CREATE PROJECT");
            Console.WriteLine("2.UPDATE TASK");
            Console.WriteLine("3.UPDATE PROJECT");
            Console.WriteLine("4.SORT BY DEADLINE");
            Console.WriteLine("5.VIEW LIST");
            Console.WriteLine("6.DELETE PROJECT");
            Console.WriteLine("7.ASSIGN PROJECT");
            Console.WriteLine("8.ADD EMPLOYEE");
            Console.WriteLine("9.VIEW EMPLOYEE LIST");
            Console.WriteLine("10.ADD/UPDATE NOTES");
            Console.WriteLine("11.VIEW NOTES");
            Console.WriteLine("12.VIEW ASSIGNED TASKS");
            Console.WriteLine("13.DELETE EMPLOYEE");
            Console.WriteLine("14.EXIT");
            Console.WriteLine("SELECT AN OPTION: (1-13)");
            string Option = Console.ReadLine();
            return Option;
        }
        public bool pass()
        {
            for (int i = 0; i < 3; i++) { 

                Console.WriteLine("Enter Admin and Password: ");
            Console.Write("ADMIN: ");
            string admin = Console.ReadLine();
            Console.Write("PASS: ");
            string pass = Console.ReadLine();
            bool check = _managerlogic.pass(admin,pass);
               
                if (check)
                {
                    ManagerDriver();
                    break;
                }
                else
                {
                    Console.WriteLine("THE CREDENTIALS ARE WRONG!\nPLEASE TRY AGAIN!");
                    Console.WriteLine("Press Any Key To Continue!");
                    Console.ReadKey();
                }
                
            }
            Console.WriteLine("THANK YOU USING THIS PROGRAM");
            Console.WriteLine("THE PROGRAM HAS ENDED");
            return true;


        }
        public void ManagerDriver()
        {
            
                while (true) { 
            string option = ManagerMenu();
            
                Console.Clear();
                    if (option == "1")
                    {
                        AddProject();
                    }
                    else if (option == "2")
                    {
                        UpdateTask();

                    }
                    else if (option == "3")
                    {
                        UpdateProject();
                    }
                    else if (option == "4")
                    {
                        SortbyDeadline();

                    }
                    else if (option == "5")
                    {
                        ShowallProjects();
                    }
                    else if (option == "6")
                    {
                        DeleteProject();

                    }
                    else if (option == "7")
                    {
                        AssignTo();
                    }
                    else if (option == "8")
                    {
                        AddEmployee();
                    }
                    else if (option == "9")
                    {
                        EmployeesList();
                    }
                    else if (option == "10")
                    {
                        UpdateNote();
                    }
                    else if (option == "11")
                    {
                        ViewNotes();
                    }
                    else if (option == "12")
                    {
                        ViewAssignedTask();
                    }
                    else if (option == "13")
                    {
                        DeleteEmployee();
                    }
                    else if (option == "14")
                    {
                        break;
                    }
                }

            
        }
        public void DisplayData(List<Projects_Model> publicModel )
        {
            Console.Clear();
            int count = 0;
            Console.WriteLine("NO. \tTitle\t\tTasks\t\tDeadline\tPriority\tStatus\t\tEmployeeName\tNOTES");
            foreach (Projects_Model model in publicModel)
            {



                Console.WriteLine(count + " " + model.Title + "\t" + model.Tasks + "\t    " + model.Deadline + "\t\t" + model.Priority + "\t\t" + model.Status + "\t\t" +
                    model.EmployeeName + "\t\t" + model.Note);
                count++;
            }

        }
        public void EmployeesList()
        {
            ViewEmployees();
            Console.WriteLine("Press Any Key To Continue!");
            Console.ReadKey();
        }
        public void DeleteEmployee()
        {
            ViewEmployees();
            Console.WriteLine("Select Employee NO. to Delete: ");
            int choice = int.Parse(Console.ReadLine());
            _managerlogic.deleteemployee(choice);
        }
        public void ShowallProjects()
        {
            ViewList();
            Console.WriteLine("Press Any Key To Continue!");
            Console.ReadKey();
        }
        public void ViewAssignedTask()
        {
            Console.Clear();
            Console.WriteLine("Following are the assigned tasks: ");
            DisplayData(_managerlogic.assignedprojects());
            Console.WriteLine("Press Any Key To Continue!");
            Console.ReadKey();
        }
        public void ViewNotes() {
            Console.Clear();
            List<Projects_Model> list = _managerlogic.readalldata();
            Console.WriteLine("Title\t\t\t" + "NOTES");
            foreach (Projects_Model each in list)
            {
                
                Console.WriteLine(each.Title+"\t      "+each.Note);
            }
            Console.WriteLine("Press Any Key To Continue!");
            Console.ReadKey();
        }
        public void UpdateNote()
        {
            Console.Clear();
            ViewList();
            Console.WriteLine("Select Project NO. You Wanna Update Note of: ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Note: ");
            string note = Console.ReadLine();
            _managerlogic.updatenote(choice,note);
        }
        public void ViewEmployees()
        {
            Console.Clear();
            List<EMPLOYEE_MODEL> list = _employeerepo.ReadAllData();
            int count = 0;
            Console.WriteLine("NO.\tEmployeeID\tNAME\tEMAIL\t\t\t\t\tDesignation");
            foreach (EMPLOYEE_MODEL each in list)
            {
                Console.WriteLine(count+"\t"+each.EmployeeID+"\t\t"+each.Name+"\t"+each.Email+"\t\t"+each.Designation);
                count++;
            }
            
        }
        public void AddEmployee()
        {
            Console.Clear();
            EMPLOYEE_MODEL model = EmployeeInput();
            _managerlogic.addemployee(model);

        }
        public EMPLOYEE_MODEL EmployeeInput()
        {
            
            Console.WriteLine("Enter Employee ID: ");
            string employeeid = Console.ReadLine();
            Console.WriteLine("Enter Employee Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Employee Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Employee Designation: ");
            string designation = Console.ReadLine();
            EMPLOYEE_MODEL employee = new EMPLOYEE_MODEL(employeeid,name,email,designation);
            return employee;
        }
        public void AssignTo()
        {
            Console.Clear();
            ViewList();
            Console.WriteLine("Select Project NO. You Wanna Assign: ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Employee Name You Wanna Assign To");
            string employeename = Console.ReadLine();
            _managerlogic.assignto(choice,employeename);

        }
        public void DeleteProject()
        {
            Console.Clear();
            ViewList();
            Console.WriteLine("Enter Project NO. to DELETE: ");
            int choice = int.Parse(Console.ReadLine());
            _managerlogic.deleteproject(choice);

        }
        public void SortbyDeadline()
        {
            _managerlogic.sortbydeadline();
        }
        public void UpdateProject()
        {
            Console.Clear();
            ViewList();
            Console.WriteLine("Enter Project NO. to Update: ");
            int choice = int.Parse(Console.ReadLine());
            Projects_Model data = TakeInput();
            _managerlogic.updateproject(choice,data);

            
        }
        public void UpdateTask()
        {
            Console.Clear();
            ViewList();
            Console.WriteLine("Enter Project NO. to Update Task: ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter New Task TO Update: ");
            string task = Console.ReadLine();
            _managerlogic.updatetask(choice,task);

        }
        public void AddProject()
        {
            Console.Clear();
            Projects_Model data = TakeInput();
            _managerlogic.saveproject(data);
        }
        
        public Projects_Model TakeInput()
        {
            Console.Clear();

            Console.WriteLine("Enter details about Project: ");
            Console.WriteLine("Enter Title");
            string title;
            title = Console.ReadLine();

            Console.WriteLine("Enter Task:");
            string task;
            task = Console.ReadLine();

            Console.WriteLine("Enter Deadline (in weeks): ");
            int deadline;
            deadline = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Priority (Low, Medium, High): ");
            string priority;
            priority = Console.ReadLine();

            Console.WriteLine("Enter Status(Pending, Working, Complete): ");
            string status;
            status = Console.ReadLine();
            Console.WriteLine("Employee You Wanna Assign To");
            string employeename = Console.ReadLine();
            Console.WriteLine("Enter Note: ");
            string note = Console.ReadLine();
            Projects_Model input = new Projects_Model(title,task,deadline,priority,status,employeename,note);
            return input;
        }
        
        public void ViewList()
        {
            Console.Clear();
            List<Projects_Model> publicModel = _managerlogic.readalldata();
            int count = 0;
            Console.WriteLine("NO. \tTitle\t\tTasks\t\tDeadline\tPriority\tStatus\t\tEmployeeName\tNOTES");
            foreach (Projects_Model model in publicModel)
            {

                

                Console.WriteLine(count+" "+model.Title+"\t"+model.Tasks+"\t    "+model.Deadline+"\t\t"+model.Priority+"\t\t"+model.Status+"\t\t"+
                    model.EmployeeName+"\t\t"+model.Note);
                count++;
            }
            
        }
    }
}
