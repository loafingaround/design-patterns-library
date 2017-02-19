using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class OrderDessert: ICommand, ICommandFactory
    {
        string dessert;

        public OrderDessert(string dessert)
        {
            this.dessert = dessert;
        }

        public string CommandName
        {
            get
            {
                return "OrderDessert";
            }
        }

        public string Description
        {
            get
            {
                return "Specify name of dessert";
            }
        }

        public void Execute()
        {
            Console.WriteLine("Here is your dessert: {0}", dessert);
        }

        public ICommand MakeCommand(string argument)
        {
            return new OrderDessert(argument);
        }
    }
}
