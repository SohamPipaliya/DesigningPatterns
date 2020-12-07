using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesigningPatterns.Structural_Patterns
{
    class Proxy
    {
        public static void Main()
        {
            Console.WriteLine("Client passing employee with Role Developer to folderproxy");
            Employee emp1 = new Employee("Anurag", "Anurag123", "Developer");
            SharedFolderProxy folderProxy1 = new SharedFolderProxy(emp1);
            folderProxy1.PerformRWOperations();
            Console.WriteLine();
            Console.WriteLine("Client passing employee with Role Manager to folderproxy");
            Employee emp2 = new Employee("Pranaya", "Pranaya123", "Manager");
            SharedFolderProxy folderProxy2 = new SharedFolderProxy(emp2);
            folderProxy2.PerformRWOperations();
            Console.Read();
        }
    }

    public interface ISharedFolder
    {
        void PerformRWOperations();
    }

    public class Employee
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public Employee(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }

    public class SharedFolder : ISharedFolder
    {
        public void PerformRWOperations()
        {
            Console.WriteLine("Performing Read Write operation on the Shared Folder");
        }
    }

    public class SharedFolderProxy : ISharedFolder
    {
        private ISharedFolder folder;
        private Employee employee;

        public SharedFolderProxy(Employee emp)
        {
            employee = emp;
        }

        public void PerformRWOperations()
        {
            if (employee.Role.ToUpper() == "CEO" || employee.Role.ToUpper() == "MANAGER")
            {
                folder = new SharedFolder();
                Console.WriteLine("Shared Folder Proxy makes call to the RealFolder 'PerformRWOperations method'");
                folder.PerformRWOperations();
            }
            else
            {
                Console.WriteLine("Shared Folder proxy says 'You don't have permission to access this folder'");
            }
        }
    }
}
