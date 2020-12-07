using System;

namespace DesigningPatterns.Creational_Patterns
{
    class Fluent_Interface
    {
        static void Main(string[] args)
        {
            FluentEmployee fluentEmployee = new FluentEmployee();
            fluentEmployee.Born("16/08/2000 08:30:00 PM").StaysAt("Moviya").WorkingOn("IT").NameOfTheEmployee("Soham Patel");
            fluentEmployee.employee.print(fluentEmployee.employee);
            Console.ReadLine();
        }
    }

    public class Employee
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }

        public void print(Employee employee)
        {
            Console.WriteLine(employee.FullName);
            Console.WriteLine(employee.DateOfBirth);
            Console.WriteLine(employee.Department);
            Console.WriteLine(employee.Address);
        }
    }

    public class FluentEmployee
    {
        public readonly Employee employee = new Employee();

        public FluentEmployee NameOfTheEmployee(string FullName)
        {
            employee.FullName = FullName;
            return this;// have to write this. if we areite new FluentEmployee then it will return new instance and value will be stored in ne instanciated object
        }

        public FluentEmployee Born(string DateOfBirth)
        {
            employee.DateOfBirth = Convert.ToDateTime(DateOfBirth);
            return this;
        }

        public FluentEmployee WorkingOn(string Department)
        {
            employee.Department = Department;
            return this;
        }

        public FluentEmployee StaysAt(string Address)
        {
            employee.Address = Address;
            return this;
        }
    }
}
