using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class OrderStarter : ICommand, ICommandFactory
    {
        string starter;

        public OrderStarter(string starter)
        {
            this.starter = starter;
        }

        public string CommandName
        {
            get
            {
                return "OrderStarter";
            }
        }

        public string Description
        {
            get
            {
                return "Specify name of starter";
            }
        }
        
        public void Execute()
        {
            Console.WriteLine("Here is your starter: {0}", starter);
        }

        public ICommand MakeCommand(string argument)
        {
            return new OrderStarter(argument);
        }
    }
}
