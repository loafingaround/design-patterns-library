using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    internal class CommandParser
    {
        private readonly IEnumerable<ICommandFactory> availableCommands;

        internal CommandParser(IEnumerable<ICommandFactory> availableCommands)
        {
            this.availableCommands = availableCommands;
        }

        internal ICommand Parse(string arg)
        {
            string[] parts = arg.Split(new [] {' '}, 2, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
                return null;

            ICommandFactory factory = availableCommands.FirstOrDefault(f => f.CommandName == parts[0]);

            if (factory != null)
                return factory.MakeCommand(parts[1]);
            else
                return null;
        }
    }
}
