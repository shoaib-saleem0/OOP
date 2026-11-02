using OOP_Project.PROJECTS;
using OOP_Project.EMPLOYEE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace OOP_Project.MANAGER
{
    internal class MANAGER_LOGIC
    {
        
        ManagerModel _managermodel = new ManagerModel();
        public List<Projects_Model> statusfilter(List<Projects_Model> list, string status)
        {
            List<Projects_Model> arranged = new List<Projects_Model>();
            for (int i = 0; i < list.Count; i++)
            {
                string Status = list[i].Status.ToLower();
                if (Status == status.ToLower())
                {
                    arranged.Add(list[i]);
                }
            }
            return arranged;
        }
        public List<Projects_Model> rangefilter(List<Projects_Model> list, string maxs,string mins)
        {
            List<Projects_Model> arranged = new List<Projects_Model>();
            int max = int.Parse(maxs);
            int min = int.Parse(mins);
            for (int i=0; i < list.Count; i++)
            {
                if (list[i].Deadline >=min && list[i].Deadline >= max)
                {
                    arranged.Add(list[i]);
                }
            }
            return arranged;
        }
        public List<Projects_Model> namefilter(List<Projects_Model> list, string Title)
        {
            string name = Title;
            List<Projects_Model> arranged = new List<Projects_Model>();
            int count = name.Length;
            
            for (int q = 0; q < list.Count; q++)
            {
                string title = list[q].Title.ToLower();
                int ind = 0;
                int check = 0;
                for (int i = 0; i < title.Length; i++)
                {

                    
                    if (count == check)
                    {
                        arranged.Add(list[i]);
                        break;
                    }
                    if (title[i] == name[ind])
                    {
                        check++;
                        ind++;
                    }
                    else
                    {
                        check = 0;
                        ind = 0;
                        
                    }

                }

            }
            return arranged;
        }
        public bool pass(string admin,string pass)
        {
           
            if (admin == _managermodel.getAdmin() && pass == _managermodel.getPass())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        Projects_Repository _projectsrepo = new Projects_Repository();
        EMPLOYEE_REPO _employeerepo = new EMPLOYEE_REPO();
        public List<Projects_Model> assignedprojects()
        {
            List<Projects_Model> list = readalldata();
            List<Projects_Model> assigned = new List<Projects_Model>();
            foreach (Projects_Model each in list)
            {
                if (each.EmployeeName != "")
                {
                    assigned.Add(each);
                }
                
            }
            return assigned;
        }
        public void deleteemployee(int choice)
        {
            List<EMPLOYEE_MODEL> list = _employeerepo.ReadAllData();
            list.RemoveAt(choice);
            _employeerepo.SaveAllData(list);

        }
        public List<Projects_Model> readalldata()
        {
            List<Projects_Model> list = _projectsrepo.ReadAllData();
            return list;
        }
        public void updatenote(int choice,string note)
        {
            List<Projects_Model> list = _projectsrepo.ReadAllData();
            list[choice].Note = note;
            _projectsrepo.SaveAllData(list);
        }
        public void addemployee(EMPLOYEE_MODEL model)
        {
            _employeerepo.saveInFile(model);
        }
        public void assignto(int choice,string employeename)
        {
            List<Projects_Model> list = _projectsrepo.ReadAllData();
            list[choice].EmployeeName = employeename;
            _projectsrepo.SaveAllData(list);
        }
        public void deleteproject(int choice)
        {
            List<Projects_Model> list = _projectsrepo.ReadAllData();
            list.RemoveAt(choice);
            _projectsrepo.SaveAllData(list);
        }
        public void sortbydeadline()
        {
            List<Projects_Model> list = _projectsrepo.ReadAllData();

            for(int i =0; i<list.Count;i++) { 
                for(int q =0; q<list.Count; q++)
                {
                    if (list[i].Deadline < list[q].Deadline)
                    {
                        Projects_Model temp = list[i];
                        list[i] = list[q];
                        list[q] = temp;
                    }
                }
            
            }
            _projectsrepo.SaveAllData(list);
        }
        public void updateproject(int choice,Projects_Model model)
        {
            List<Projects_Model> list = _projectsrepo.ReadAllData();
            list[choice] = model;
            _projectsrepo.SaveAllData(list);
        }
        public void saveproject(Projects_Model project)
        {
            _projectsrepo.saveInFile(project);
        }
        public void updatetask(int choice, string task)
        {
            List<Projects_Model> list = _projectsrepo.ReadAllData();
            list[choice].Tasks = task;

            _projectsrepo.SaveAllData(list);
        }
    }
}
