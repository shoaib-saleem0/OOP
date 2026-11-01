using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_Project.MANAGER
{
    internal class ManagerModel
    {
        private string Admin = "shoaib";
        private string Pass = "123";
        public string Name;


        public string getAdmin()
        {
            string admin = Admin;
            return admin;
        }
        public string getPass()
        {
            string pass = Pass;
            return pass;
        }
    }
}
