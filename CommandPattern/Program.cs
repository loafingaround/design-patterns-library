using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class Program
    {
        // adding another command is just a matter of implementing ICommand and ICommandFactory, and adding an instance here
        private static ICommandFactory[] availableCommands = new ICommandFactory[]{
            new OrderDrinks(null),
            new OrderStarter(null),
            new OrderMainCourse(null),
            new OrderDessert(null),
            new Pay(0)
        };

        static void Main(string[] args)
        {
            IList<ICommand> commands = new List<ICommand>();

            CommandParser parser = new CommandParser(availableCommands);

            string input = null;

            Console.WriteLine("Enter new command per line and 'end' when finished. Type '?' for usage.");

            input = Console.ReadLine();

            while (input.ToLower() != "end")
            {
                if (input == "?")
                {
                    PrintUsage();
                }
                else
                {
                    ICommand command = parser.Parse(input);

                    if (command != null)
                        commands.Add(command);
                    else
                        Console.WriteLine("Invalid input '{0}'", input);
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine("Executing commands:");
            foreach (ICommand command in commands)
                command.Execute();

            Console.ReadLine();
        }

        // usage printing all in one place, no updating to do here when adding new command, cannot forget to add information as it is part
        // of the implementation for ICommandFactory
        private static void PrintUsage()
        {
            Console.WriteLine("=========================");

            Console.WriteLine("Usage:");

            foreach(ICommandFactory cmd in availableCommands)
            {
                Console.WriteLine("{0}:", cmd.CommandName);
                Console.WriteLine("\t{0}", cmd.Description);
            }

            Console.WriteLine("=========================");
        }
    }
}
