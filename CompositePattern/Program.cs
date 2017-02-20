using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // create tree of payees:

            Group employees = new Group
            {
                Members =
                {
                    new Person("John"),
                    new Person("Rebecca"),
                    new Person("Claire")
                }
            };
            Group anattSolutions = new Group
            {
                Members =
                {
                    new Person("Matt"),
                    new Person("Anita")
                }
            };
            Group cpnkGlobal = new Group
            {
                Members =
                {
                    new Person("Raj"),
                    new Person("Peter"),
                    new Person("Freda"),
                    anattSolutions
                }
            };
            Group contractors = new Group
            {
                Members =
                {
                    cpnkGlobal,
                    new Person("Sharmeela")
                }
            };
            Group freeLancers = new Group
            {
                Members =
                {
                    new Person("Simon"),
                    new Person("Gina")
                }
            };
            Group rootComponent = new Group
            {
                Members =
                {
                    employees,
                    contractors,
                    freeLancers,
                    new Person("Paddy")
                }
            };

            // can treat any level of hierarchy, leaf or node, the same
            // very little work to do here
            rootComponent.Pay(2310000);

            rootComponent.Pay(11535146);

            rootComponent.ReportFinances();

            Console.ReadLine();
        }
    }
}
