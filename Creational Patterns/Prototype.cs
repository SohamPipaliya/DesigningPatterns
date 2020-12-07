using System;

namespace DesigningPatterns.Creational_Patterns.ShallowCopy
{
    class Prototype
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee();
            emp1.Name = "Anurag";
            emp1.Department = "IT";

            Employee emp2 = emp1;
            emp2.Name = "Soham";
            emp2.Department = "Accoutant";

            //or can use below
            Employee emp3 = emp1.ShallowCopy();
            emp3.Name = "Dot Net  Tutorial";
            emp3.Department = "Online";

            Console.WriteLine("Emplpyee 1: ");
            Console.WriteLine("Name: " + emp1.Name + ", Department: " + emp1.Department);

            Console.WriteLine("Emplpyee 2: ");
            Console.WriteLine("Name: " + emp2.Name + ", Department: " + emp2.Department);

            Console.WriteLine("Emplpyee 3: ");
            Console.WriteLine("Name: " + emp3.Name + ", Department: " + emp3.Department);

            Console.Read();
        }
    }

    public class Employee
    {
        private static int i = 0;

        public Employee()
        {
            i++;
            Console.WriteLine(i);//you will get only one because only once we are instanciating it and second time we are using shallow copy
        }

        public string Name { get; set; }
        public string Department { get; set; }

        public Employee ShallowCopy()
        {
            return (Employee)MemberwiseClone();//method of object class
        }
    }
}

namespace DesigningPatterns.Creational_Patterns.DeepCopy
{
    public class Prototype
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee();
            emp1.Name = "Anurag";
            emp1.Department = "IT";
            emp1.EmpAddress = new Address() { address = "BBSR" };

            Employee emp2 = emp1.GetClone();
            emp2.Name = "Pranaya";
            emp2.EmpAddress.address = "Mumbai";

            Console.WriteLine("Emplpyee 1: ");
            Console.WriteLine("Name: " + emp1.Name + ", Address: " + emp1.EmpAddress.address + ", Dept: " + emp1.Department);

            Console.WriteLine("Emplpyee 2: ");
            Console.WriteLine("Name: " + emp2.Name + ", Address: " + emp2.EmpAddress.address + ", Dept: " + emp2.Department);

            Console.Read();
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public Address EmpAddress { get; set; }

        public Employee GetClone()
        {
            Employee employee = (Employee)this.MemberwiseClone();
            employee.EmpAddress = EmpAddress.GetClone();
            return employee;
        }
    }

    public class Address
    {
        public string address { get; set; }

        public Address GetClone()
        {
            return (Address)this.MemberwiseClone();
        }
    }
}