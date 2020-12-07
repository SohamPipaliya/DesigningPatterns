using System;

namespace DesigningPatterns.Creational_Patterns
{
    class AbstractFactory
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Animal Type Name:- ");
            var type = Console.ReadLine();

            var animal = AnimalFactory.CreateAnimalFactory(type);
            Console.WriteLine("Enter a Animal Name:- ");
            var anmimalname = animal.GetAnimal(Console.ReadLine());

            Console.WriteLine(anmimalname.GetType().Name + " speak " + anmimalname.Speak());
            Console.ReadLine();
        }
    }

    public abstract class AnimalFactory
    {
        public abstract Animal GetAnimal(string AnimalType);

        public static AnimalFactory CreateAnimalFactory(string FactoryType)
        {
            if (FactoryType.ToUpper().Equals("SEA"))
                return new SeaAnimalFactory();
            else
                return new LandAnimalFactory();
        }
    }

    public class SeaAnimalFactory : AnimalFactory
    {
        public override Animal GetAnimal(string AnimalType)
        {
            Animal animal = null;
            if (AnimalType.ToUpper().Equals("OCTOPUS"))
            {
                animal = new Octopus();
            }
            else if (AnimalType.ToUpper().Equals("SHARK"))
            {
                animal = new Shark();
            }
            return animal;
        }
    }

    public class LandAnimalFactory : AnimalFactory
    {
        public override Animal GetAnimal(string AnimalType)
        {
            Animal animal = null;
            if (AnimalType.ToUpper().Equals("LION"))
            {
                animal = new Lion();
            }
            else if (AnimalType.ToUpper().Equals("DOVE"))
            {
                animal = new Dove();
            }
            else if (AnimalType.ToUpper().Equals("SPARROW"))
            {
                animal = new Sparrow();
            }
            return animal;
        }
    }

    public interface Animal //or use abstract class instead of interface 
    {
        string Speak();
    }

    public class Lion : Animal
    {
        public string Speak()
        {
            return "Roar";
        }
    }

    public class Sparrow : Animal
    {
        public string Speak()
        {
            return "Cheeechee";
        }
    }

    public class Dove : Animal
    {
        public string Speak()
        {
            return "Ghooghoo";
        }
    }

    public class Octopus : Animal
    {
        public string Speak()
        {
            return "SQUAWCK";
        }
    }

    public class Shark : Animal
    {
        public string Speak()
        {
            return "High decimal human can not listen and bear";
        }
    }
}
