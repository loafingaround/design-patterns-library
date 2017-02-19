using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class Pay: ICommand, ICommandFactory
    {
        decimal amount;

        public Pay(decimal amount)
        {
            this.amount = amount;
        }

        public string CommandName
        {
            get
            {
                return "Pay";
            }
        }

        public string Description
        {
            get
            {
                return "Specify amount to pay";
            }
        }

        public void Execute()
        {
            Console.WriteLine("You have paid: {0:c}", amount);
        }

        public ICommand MakeCommand(string argument)
        {
            decimal amount;

            if (!decimal.TryParse(argument, out amount))
                throw new ArgumentException(String.Format("Argument '${amount}' specified is not a decimal"));

            return new Pay(amount);
        }
    }
}
