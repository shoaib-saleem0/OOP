using OOP_Project.MANAGER;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.PROJECTS
{
    internal class Projects_Repository
    {
        private string path = "C:\\Users\\ViNCENZO\\Documents\\University\\ProjectsData.txt";
        public void saveInFile(Projects_Model data)
        {
            using (StreamWriter File = new StreamWriter(path, true))
            {
                File.WriteLine(data.ToString());
            }

        }
        public void SaveAllData(List<Projects_Model> projectsmodel)
        {
            File.WriteAllText(path, "");
            foreach (Projects_Model model in projectsmodel)
            {
                saveInFile(model);
            }
        }
        public List<Projects_Model> ReadAllData()
        {
            List<Projects_Model> models = new List<Projects_Model>();
            using (StreamReader file = new StreamReader(path))
            {
                string line = "";
                while ((line = file.ReadLine()) != null)
                {
                    string[] ALL = line.Split(',');
                    string title = ALL[0];
                    string tasks = ALL[1];
                    int deadline =int.Parse(ALL[2]);
                    string priority = ALL[3];
                    string status = ALL[4];
                    string employeename=ALL[5];
                    string Notes = ALL[6];

                    Projects_Model data = new Projects_Model(title, tasks, deadline, priority, status,employeename,Notes);
                    models.Add(data);
                }

            }
            return models;
        }
    }
}
