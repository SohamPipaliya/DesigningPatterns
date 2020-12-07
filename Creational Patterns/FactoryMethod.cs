using System;

namespace DesigningPatterns.Creational_Patterns
{
    class FactoryMethod
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Bank Name:- ");
            var name = Console.ReadLine();

            var clas = new AXISFactory().GetCard();
            Console.WriteLine(clas.cvv() + "\n" + clas.ExDate() + "\n" + clas.Name());
            Console.ReadLine();
        }
    }

    public abstract class FactoryMethodPattern//can't use interface here because inerface cannot provide method implemetation
    {
        protected abstract ICard MakeCard();

        public ICard GetCard()
        {
            return this.MakeCard();
        }
    }

    public class SBIFactory : FactoryMethodPattern
    {
        protected override ICard MakeCard()
        {
            return new SBIBank();
        }
    }

    public class HDFCFactory : FactoryMethodPattern
    {
        protected override ICard MakeCard()
        {
            return new HDFCBank();
        }
    }

    public class AXISFactory : FactoryMethodPattern
    {
        protected override ICard MakeCard()
        {
            return new AXISBank();
        }
    }

    public interface ICard//or use abstract class instead of interface 
    {
        string Name();
        string cvv();
        string ExDate();
    }

    public class SBIBank : ICard
    {
        public string cvv()
        {
            return "123 SBI";
        }

        public string ExDate()
        {
            return DateTime.Today.ToString("dd-mm-yyyy") + " SBI";
        }

        public string Name()
        {
            return "SBI Credit Card";
        }
    }

    public class HDFCBank : ICard
    {
        public string cvv()
        {
            return "123 HDFC";
        }

        public string ExDate()
        {
            return DateTime.Today.ToString("dd-mm-yyyy") + " HDFC";
        }

        public string Name()
        {
            return "HDFC Credit Card";
        }
    }

    public class AXISBank : ICard
    {
        public string cvv()
        {
            return "123 AXIS";
        }

        public string ExDate()
        {
            return DateTime.Today.ToString("dd-mm-yyyy") + " AXIS";
        }

        public string Name()
        {
            return "AXIS Credit Card";
        }
    }
}
