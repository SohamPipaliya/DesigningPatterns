using System;

namespace DesigningPatterns.Creational_Patterns
{
    class Factory
    {
        /*
        Creational pattern
        this pattern is all about to create  an instance of class based on the passed argument or value
        problem with this method is thst it thightly couples the code and if we want to add new class then we have to add reference in factorypattern's static method getcard.
        */

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Bank Name:- ");
            var name = Console.ReadLine();

            var clas = FactoryPattern.GetCard(name);//enter bank name hdfc or sbi or axis, based on that it will create instance of the class
            Console.WriteLine(clas.cvv() + "\n" + clas.ExDate() + "\n" + clas.Name());
            Console.ReadLine();
        }
    }

    public class FactoryPattern
    {
        public static Card GetCard(string card)
        {
            Card cards = null;
            if (card.ToUpper() == "SBI")
            {
                cards = new SBI();
            }
            else if (card.ToUpper() == "HDFC")
            {
                cards = new HDFC();
            }
            else if (card.ToUpper() == "AXIS")
            {
                cards = new AXIS();
            }
            return cards;
        }
    }

    public abstract class Card//or use interface instead of abstract class
    {
        public abstract string Name();
        public abstract string cvv();
        public abstract string ExDate();
    }

    public class SBI : Card
    {
        public override string cvv()
        {
            return "123 SBI";
        }

        public override string ExDate()
        {
            return DateTime.Today.ToString("dd-mm-yyyy") + " SBI";
        }

        public override string Name()
        {
            return "SBI Credit Card";
        }
    }

    public class HDFC : Card
    {
        public override string cvv()
        {
            return "123 HDFC";
        }

        public override string ExDate()
        {
            return DateTime.Today.ToString("dd-mm-yyyy") + " HDFC";
        }

        public override string Name()
        {
            return "HDFC Credit Card";
        }
    }

    public class AXIS : Card
    {
        public override string cvv()
        {
            return "123 AXIS";
        }

        public override string ExDate()
        {
            return DateTime.Today.ToString("dd-mm-yyyy") + " AXIS";
        }

        public override string Name()
        {
            return "AXIS Credit Card";
        }
    }
}
