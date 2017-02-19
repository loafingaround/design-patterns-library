using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class OrderMainCourse: ICommand, ICommandFactory
    {
        string mainCourse;

        public OrderMainCourse(string mainCourse)
        {
            this.mainCourse = mainCourse;
        }

        public string CommandName
        {
            get
            {
                return "OrderMainCourse";
            }
        }

        public string Description
        {
            get
            {
                return "Specify name of main course";
            }
        }

        public void Execute()
        {
            Console.WriteLine("Here is your main course: {0}", mainCourse);
        }

        public ICommand MakeCommand(string argument)
        {
            return new OrderMainCourse(argument);
        }
    }
}
