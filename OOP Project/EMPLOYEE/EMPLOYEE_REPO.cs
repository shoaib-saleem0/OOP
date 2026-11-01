using OOP_Project.MANAGER;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.EMPLOYEE
{
    internal class EMPLOYEE_REPO
    {
        private string path = "C:\\Users\\ViNCENZO\\Documents\\University\\EmployeeData.txt";
        public void saveInFile(EMPLOYEE_MODEL data)
        {
            using (StreamWriter File = new StreamWriter(path, true))
            {
                File.WriteLine(data);
            }

        }
        public void SaveAllData(List<EMPLOYEE_MODEL> employeemodel)
        {
            File.WriteAllText(path, "");
            foreach (EMPLOYEE_MODEL model in employeemodel)
            {
                saveInFile(model);
            }
        }
        public List<EMPLOYEE_MODEL> ReadAllData()
        {
            List<EMPLOYEE_MODEL> employeemodel = new List<EMPLOYEE_MODEL>();
            using (StreamReader file = new StreamReader(path))
            {
                string line = "";
                while ((line = file.ReadLine()) != null)
                {
                    string[] ALL = line.Split(',');
                    string employeeid = ALL[0];
                    string name = ALL[1];
                    string email = ALL[2];
                    string designation = ALL[3];
                    

                    EMPLOYEE_MODEL data = new EMPLOYEE_MODEL(employeeid,name,email,designation);
                    employeemodel.Add(data);
                }

            }
            return employeemodel;
        }
        
    }
}
