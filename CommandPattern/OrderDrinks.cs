using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    // we could have command and factory implementations in separate classes; we put them in same class here for simplicity
    class OrderDrinks : ICommand, ICommandFactory
    {
        string[] drinks;

        public OrderDrinks(string[] drinks)
        {
            this.drinks = drinks;
        }

        public string Description
        {
            get
            {
                return "Specify comma-separated list of drinks";
            }
        }

        public string CommandName
        {
            get
            {
                return "OrderDrinks";
            }
        }

        public void Execute()
        {
            Console.WriteLine("Here are your drinks:");
            foreach (string drink in drinks)
                Console.WriteLine("\t* {0}", drink);
        }

        public ICommand MakeCommand(string argument)
        {
            string[] drinks = argument.Split(new []{ ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return new OrderDrinks(drinks);
        }
    }
}
