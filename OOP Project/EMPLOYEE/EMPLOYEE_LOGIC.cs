using OOP_Project.PROJECTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.EMPLOYEE
{
    internal class EMPLOYEE_LOGIC
    {
        EMPLOYEE_REPO _employeerepo = new EMPLOYEE_REPO();
        Projects_Repository _projectsrepo = new Projects_Repository();
        public List<Projects_Model> pendingprojects(string employeename)
        {
            List<Projects_Model> list = readprojectsdata();
            List<Projects_Model> pending = new List<Projects_Model>();
            int count = 0;
            foreach (Projects_Model each in list)
            {
                if (each.EmployeeName == employeename && each.Status == "Pending")
                {
                    pending.Add(list[count]);

                }
                count++;
            }
            return pending;

        }
        public List<Projects_Model> completedprojects(string employeename)
        {
            List<Projects_Model> list = readprojectsdata();
            List<Projects_Model> completed = new List<Projects_Model>();
            int count = 0;
            foreach (Projects_Model each in list)
            {
                if (each.EmployeeName == employeename && each.Status == "Complete")
                {
                    completed.Add(list[count]);
                        
                }
                count++;
            }
            return completed;
        }
        public int countprojects(string employeename)
        {
            List<Projects_Model> list = readprojectsdata();
            int count = 0;
            foreach (Projects_Model model in list)
            {
                if (model.EmployeeName == employeename)
                {
                    count++;
                }

            }
            return count;

        }
        public Projects_Model searchtask(string employeename,string task)
        {
            List<Projects_Model> list = readprojectsdata();
            foreach (Projects_Model each in list)
            {
                if(each.EmployeeName == employeename && each.Tasks == task)
                {
                    return each;
                }
            }
            return null;
        }
        public void markascomplete(int choice, string complete)
        {
            List<Projects_Model> list = readprojectsdata();
            list[choice].Status = complete;
            saveprojectsdata(list);
        }
        public void updatestatus(int choice,string status)
        {
            List<Projects_Model> list = readprojectsdata();
            list[choice].Status = status;
            saveprojectsdata(list);
        }
        public string searchemployee(int choice)
        {
            List<EMPLOYEE_MODEL> list = _employeerepo.ReadAllData();
            string employeename = list[choice].Name;
            return employeename;
        }
        public List<EMPLOYEE_MODEL> readalldata()
        {
            List < EMPLOYEE_MODEL > list = _employeerepo.ReadAllData();
            return list;
        }
        public void savealldata(List<EMPLOYEE_MODEL> list)
        {
            _employeerepo.SaveAllData(list);
        }
        public List<Projects_Model> readprojectsdata()
        {
            List<Projects_Model> list = _projectsrepo.ReadAllData();
            return list;
        }
        public void saveprojectsdata(List<Projects_Model> list)
        {
            _projectsrepo.SaveAllData(list);
        }
    }
}
