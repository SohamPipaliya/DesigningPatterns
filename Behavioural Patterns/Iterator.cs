using System;
using System.Collections.Generic;

namespace DesigningPatterns.Behavioural_Patterns
{
    class PatternI
    {
        static void Main(string[] args)
        {
            ConcreteCollection collection = new ConcreteCollection();
            collection.AddEmployee(new Employee("Anurag", 100));
            collection.AddEmployee(new Employee("Pranaya", 101));
            collection.AddEmployee(new Employee("Santosh", 102));
            collection.AddEmployee(new Employee("Priyanka", 103));
            collection.AddEmployee(new Employee("Abinash", 104));
            collection.AddEmployee(new Employee("Preety", 105));

            Iterator iterator = collection.CreateIterator();
            Console.WriteLine("Iterating over collection:");

            for (Employee emp = iterator.First(); !iterator.IsCompleted; emp = iterator.Next())
            {
                Console.WriteLine($"ID : {emp.ID} & Name : {emp.Name}");
            }
            Console.ReadLine();
        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Employee(string name, int id)
        {
            Name = name;
            ID = id;
        }
    }

    public interface IIterator
    {
        Employee First();
        Employee Next();
        bool IsCompleted { get; }
    }

    public class Iterator : IIterator
    {
        private ConcreteCollection collection;
        private int current = 0;
        private int step = 1;

        public Iterator(ConcreteCollection collection)
        {
            this.collection = collection;
        }

        public Employee First()
        {
            current = 0;
            return collection.GetEmployee(current);
        }

        public Employee Next()
        {
            current += step;
            if (!IsCompleted)
            {
                return collection.GetEmployee(current);
            }
            else
            {
                return null;
            }
        }

        public bool IsCompleted => current >= collection.Count; // this is property with get accessore
    }

    public interface ICollection
    {
        Iterator CreateIterator();
    }

    public class ConcreteCollection : ICollection
    {
        private List<Employee> listEmployees = new List<Employee>();

        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        public int Count => listEmployees.Count;

        public void AddEmployee(Employee employee) => listEmployees.Add(employee);

        public Employee GetEmployee(int IndexPosition) => listEmployees[IndexPosition];
    }
}
