using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // here we can add extra functionality to the BreakItem objects
            // at runtime without extending or modifying them or making them
            // aware of the extra functionality, and possibly ending up with class
            // "explosion" as we try to create sub-class for every combination

            BreakfastItem beansOnToast = new BeansOnToast();

            printPurchase(beansOnToast);

            BreakfastItem eggMuffin = new EggMuffin();

            // wrap
            eggMuffin = new Cheese(eggMuffin);
            // wrap again over wrapper
            eggMuffin = new Ketchup(eggMuffin);

            printPurchase(eggMuffin);

            BreakfastItem baconSandwich = new BaconSandwich();

            // wrap
            baconSandwich = new Mustard(baconSandwich);
            // wrap again over wrapper
            baconSandwich = new Ketchup(baconSandwich);
            // wrap a third "layer"
            baconSandwich = new Cheese(baconSandwich);

            printPurchase(baconSandwich);

            Console.ReadLine();
        }

        private static void printPurchase(BreakfastItem item)
        {
            Console.WriteLine("You bought {0} for {1:c}", item.Description, item.Price);
        }
    }
}
