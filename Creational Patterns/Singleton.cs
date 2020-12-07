using System;
using System.Threading.Tasks;

namespace DesigningPatterns.Creational_Patterns
{
    class Singleton
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(() => singleton.getInstance.print("Hello"), () => singleton.getInstance.print("World"));

            Console.ReadLine();
        }
    }

    public sealed class singleton
    {
        /*
         * Creational Pattern
         * Single pattern is all about instanciation of class
         * when  class is called by differen activity or canother class it creates multiple instance of thet class which is not good and to solve this problem singleton pattern comes in the picture
         * in single pattern we have two method to prevent the multiple instance of class
         * lazy loading
         * non-lazy or eager loading
         * To apply singleton pattern you have to make constructor private
         * and it is recommanded to apply sealed keyword to the class beacuse nested class can create anothe instance. note by making constructor private class can not be inheritated
         * try each of these only one beacuse using more than one create multiple instance.
         */

        private static int count = 0;
        private static readonly object o = new object();

        private singleton()
        {
            Console.WriteLine(++count);
        }

        /*
         * Lazy Loading
         * in this case multiple calling is handled automatically
        */

        public static readonly Lazy<singleton> instance = new Lazy<singleton>(() => new singleton());
        public static singleton getInstance
        {
            get
            {
                return instance.Value;
            }
        }

        /*
         * Another Lazy Loading
         * in this case to handle multiple calling you have to apply lock which checks and handel threading
         * it is recommanded to use this because it doesn't create instance automaticlly it only creates when class and it's instance is called
        */

        public static singleton instance2 = null;
        public static singleton getInstance2
        {
            get
            {
                if (instance2 == null)
                {
                    lock (o)
                    {
                        if (instance2 == null) // here checking also needed because whenever multiple calling happens each time it assign new instance but if put this here it checks weather it is null or not if it is not null then and then only it assign value
                            instance2 = new singleton();
                    }
                }
                return instance2;
            }
        }

        /*
         * Eager Loading
         * in this case multiple calling is handled automatically
        */

        public static readonly singleton instance3 = new singleton();
        public static singleton getInstance3
        {
            get
            {
                return instance3;
            }
        }

        public void print(string meassage)
        {
            Console.WriteLine(meassage);
        }
    }
}
