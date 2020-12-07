using System;
using System.Collections.Generic;

namespace DesigningPatterns.Behavioural_Patterns
{
    class Mediator
    {
        static void Main(string[] args)
        {
            IFacebookGroupMediator facebookMediator = new ConcreteFacebookGroupMediator();

            User Ram = new ConcreteUser(facebookMediator, "Ram");
            User Dave = new ConcreteUser(facebookMediator, "Dave");
            User Smith = new ConcreteUser(facebookMediator, "Smith");
            User Rajesh = new ConcreteUser(facebookMediator, "Rajesh");
            User Sam = new ConcreteUser(facebookMediator, "Sam");
            User Pam = new ConcreteUser(facebookMediator, "Pam");
            User Anurag = new ConcreteUser(facebookMediator, "Anurag");
            User John = new ConcreteUser(facebookMediator, "John");

            facebookMediator.RegisterUser(Ram);
            facebookMediator.RegisterUser(Dave);
            facebookMediator.RegisterUser(Smith);
            facebookMediator.RegisterUser(Rajesh);
            facebookMediator.RegisterUser(Sam);
            facebookMediator.RegisterUser(Sam);
            facebookMediator.RegisterUser(Pam);
            facebookMediator.RegisterUser(Anurag);
            facebookMediator.RegisterUser(John);

            Dave.Send("dotnettutorials.net - this website is very good to learn Design Pattern");

            Console.WriteLine();

            Rajesh.Send("What is Design Patterns? Please explain ");

            Console.ReadLine();
        }
    }

    public interface IFacebookGroupMediator
    {
        void SendMessage(string msg, User user);

        void RegisterUser(User user);
    }

    public class ConcreteFacebookGroupMediator : IFacebookGroupMediator
    {
        private List<User> usersList = new List<User>();

        public void RegisterUser(User user)
        {
            usersList.Add(user);
        }

        public void SendMessage(string message, User user)
        {
            foreach (var item in usersList)
            {
                if (item != user)//to check weather user is registered or not
                {
                    item.Receive(message);
                }
            }
        }
    }

    public abstract class User
    {
        protected IFacebookGroupMediator mediator;
        protected string name;

        public User(IFacebookGroupMediator mediator, string UserName)
        {
            this.mediator = mediator;
            this.name = UserName;
        }

        public abstract void Send(string message);

        public abstract void Receive(string message);
    }

    public class ConcreteUser : User
    {
        public ConcreteUser(IFacebookGroupMediator mediator, string UserName) : base(mediator, UserName)
        {

        }

        public override void Receive(string message)
        {
            Console.WriteLine(this.name + ": Received Message:" + message);
        }

        public override void Send(string message)
        {
            Console.WriteLine(this.name + ": Sending Message=" + message + "\n");
            mediator.SendMessage(message, this);
        }
    }
}
