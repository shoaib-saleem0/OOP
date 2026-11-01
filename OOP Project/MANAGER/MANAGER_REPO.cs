using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.MANAGER
{
    internal class MANAGER_REPO
    {
        private string path = "C:\\Users\\ViNCENZO\\Documents\\University\\Data.txt";
        public void saveInFile(ManagerModel data)
        {
            using (StreamWriter File = new StreamWriter(path, true))
            {
                File.WriteLine(data);
            }
            
        }
        public void SaveAllData(List<ManagerModel> managermodel)
        {
            File.WriteAllText(path,"");
            foreach (ManagerModel model in managermodel) { 
                saveInFile(model);
            }
        }
        public List<ManagerModel> ReadAllData()
        {
            List<ManagerModel> managermodel = new List<ManagerModel>();
            using (StreamReader file = new StreamReader(path))
            {
                string line = "";
                while ((line = file.ReadLine()) != null)
                {
                    string[] ALL = line.Split(',');
                    string title = ALL[0];
                    string tasks = ALL[1];
                    string deadline = ALL[2];
                    string priority = ALL[3];
                    string status = ALL[4];
                       
                    ManagerModel data = new ManagerModel();
                    managermodel.Add(data);
                }
                
            }
            return managermodel;
        }
        

    }
}
