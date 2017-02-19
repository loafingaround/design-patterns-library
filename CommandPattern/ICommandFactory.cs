using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    interface ICommandFactory
    {
        string CommandName { get; }

        string Description { get; }

        ICommand MakeCommand(string argument);
    }
}
