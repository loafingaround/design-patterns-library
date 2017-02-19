using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SandwichMaker sandwichMaker = new SandwichMaker(new PloughmansSandwichBuilder());
            sandwichMaker.BuildSandwich();
            sandwichMaker.GetSandwich().Display();

            SandwichMaker sandwichMaker2 = new SandwichMaker(new ClubSandwichBuilder());
            sandwichMaker2.BuildSandwich();
            sandwichMaker2.GetSandwich().Display();

            Console.ReadLine();
        }
    }
}
