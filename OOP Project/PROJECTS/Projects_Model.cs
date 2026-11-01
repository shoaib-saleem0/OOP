using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.PROJECTS
{
    internal class Projects_Model
    {
        public string Tasks { get; set; }
        public string Title { get; set; }
        public int Deadline { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Note { get; set;  }
        public string EmployeeName {  get; set; }

        public Projects_Model() { }
        public Projects_Model(string title, string tasks, int deadline, string priority, string status,string employeename,string note)
        {
            Tasks = tasks;
            Title = title;
            Deadline = deadline;
            Priority = priority;
            Status = status;
            EmployeeName = employeename;
            Note = note;


        }
        public Projects_Model(string employeename)
        {
            EmployeeName = employeename; 
        }
        public override string ToString()
        {

            return $"{Title},{Tasks},{Deadline},{Priority},{Status},{EmployeeName},{Note}";
        }
        public string GetTitle()
        {
            string title = Title;
            return title;
        }
        public string GetTask()
        {
            string task = Tasks;
            return task;
        }
        public int GetDeadline()
        {
            int deadline = Deadline;
            return deadline;
        }
        public string GetPriority()
        {
            string priority = Priority;
            return priority;
        }
        public string GetStatus()
        {
            string status = Status;
            return status;
        }
        public string GetEmployeename()
        {
            string employeename = EmployeeName;
            return employeename;
        }
        public string GetNote()
        {
            string note = Note;
            return note;
        }

    }
}
