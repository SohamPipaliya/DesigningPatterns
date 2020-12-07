using System;
using System.Collections.Generic;

namespace DesigningPatterns.Behavioural_Patterns
{
    class Visitor
    {
        static void Main(string[] args)
        {
            var x = School.elements;
            School school = new School();
            var visitor1 = new Doctor("James");
            school.PerformOperation(visitor1);
            Console.WriteLine();
            var visitor2 = new Salesman("John");
            school.PerformOperation(visitor2);

            Console.ReadLine();
        }
    }

    public interface IElement
    {
        string Name { get; set; }

        void Accept(IVisitor visitor);
    }

    public class Kid : IElement
    {
        public string Name { get; set; }

        public Kid(string name)
        {
            Name = name;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public interface IVisitor
    {
        string Name { get; set; }

        void Visit(IElement element);
    }

    public class Doctor : IVisitor
    {
        public string Name { get; set; }

        public Doctor(string name)
        {
            Name = name;
        }

        public void Visit(IElement element)
        {
            Kid kid = (Kid)element;
            Console.WriteLine("Doctor: " + this.Name + " did the health checkup of the child: " + kid.Name);
        }
    }

    class Salesman : IVisitor
    {
        public string Name { get; set; }

        public Salesman(string name)
        {
            Name = name;
        }

        public void Visit(IElement element)
        {
            Kid kid = (Kid)element;
            Console.WriteLine("Salesman: " + this.Name + " gave the school bag to the child: " + kid.Name);
        }
    }

    public class School
    {
        public static List<IElement> elements = new List<IElement>();

        static School()
        {
            elements = new List<IElement>
            {
                new Kid("Ram"),
                new Kid("Sara"),
                new Kid("Pam")
            };
        }

        public void PerformOperation(IVisitor visitor)
        {
            foreach (var kid in elements)
            {
                kid.Accept(visitor);
            }
        }
    }
}
