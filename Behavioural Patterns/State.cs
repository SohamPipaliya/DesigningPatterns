using System;

namespace DesigningPatterns.Behavioural_Patterns
{
    class State
    {
        static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();
            Console.WriteLine("Current VendingMachine State : "
                            + vendingMachine.vendingMachineState.GetType().Name + "\n");
            vendingMachine.DispenseProduct();
            vendingMachine.SelectProductAndInsertMoney(50, "Pepsi");
            // Money has been inserted so vending Machine internal state
            // changed to 'hasMoneyState'
            Console.WriteLine("\nCurrent VendingMachine State : "
                            + vendingMachine.vendingMachineState.GetType().Name + "\n");
            vendingMachine.SelectProductAndInsertMoney(50, "Fanta");
            vendingMachine.DispenseProduct();
            // Product has been dispensed so vending Machine internal state
            // changed to 'NoMoneyState'
            Console.WriteLine("\nCurrent VendingMachine State : "
                            + vendingMachine.vendingMachineState.GetType().Name);
            Console.ReadLine();
        }
    }

    public interface IMachineState
    {
        void SelectProductAndInsertMoney(int amount, String productName);

        void DispenseProduct();
    }

    public class NoMoney : IMachineState
    {
        public void DispenseProduct()
        {
            Console.WriteLine("Vending Machine cannot dispense product because money is not inserted and product is not selected");
        }

        public void SelectProductAndInsertMoney(int amount, string productName)
        {
            Console.WriteLine(amount + "Rs has been inserted and " + productName + " has been selected");
        }
    }

    public class HasMoneyState : IMachineState
    {
        public void DispenseProduct()
        {
            Console.WriteLine("Vending Machine  dispensed the product ");
        }

        public void SelectProductAndInsertMoney(int amount, string productName)
        {
            Console.WriteLine("Already Vending machine has money and product selected, So wait till it finish the current dispensing process");
        }
    }

    public class VendingMachine : IMachineState
    {
        //Createing a variable to maintain the internal state
        public IMachineState vendingMachineState { get; set; }

        //Initially the vending machine has NoMoneyState
        public VendingMachine()
        {
            vendingMachineState = new NoMoney();
        }

        public void SelectProductAndInsertMoney(int amount, string productName)
        {
            vendingMachineState.SelectProductAndInsertMoney(amount, productName);
            // Money has been inserted so vending Machine internal state 
            // changed to 'hasMoneyState'
            if (vendingMachineState is NoMoney)
            {
                vendingMachineState = new HasMoneyState();
                Console.WriteLine("VendingMachine internal state has been moved to : " + vendingMachineState.GetType().Name);
            }
        }

        public void DispenseProduct()
        {
            vendingMachineState.DispenseProduct();
            // Product has been dispensed so vending Machine changed the
            // internal state to 'NoMoneyState'
            if (vendingMachineState is HasMoneyState)
            {
                vendingMachineState = new NoMoney();
                Console.WriteLine("VendingMachine internal state has been moved to : " + vendingMachineState.GetType().Name);
            }
        }
    }
}
