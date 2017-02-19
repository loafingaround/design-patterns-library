using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    class Sandwich
    {
        // "Product"
        // use properties instead of long list of constructor parameters - easier to maintain and use
        public string Name { get; set; }
        public BreadType BreadType { get; set; }
        public MeatType MeatType { get; set; }
        public CheeseType CheeseType { get; set; }
        public bool HasMustard { get; set; }
        public bool HasMayo { get; set; }
        public bool IsToasted { get; set; }
        public List<string> Vegetables { get; set; }

        public void Display()
        {
            Console.WriteLine("{0} sandwich:", Name);
            Console.WriteLine("==================");
            Console.WriteLine("Bread: {0}", BreadType == BreadType.White ? "white" : BreadType == BreadType.Wholemeal ? "wholemeal" : "Italian");
            Console.WriteLine("Meat: {0}", MeatType == MeatType.Turkey ? "turkey" : "ham");
            Console.WriteLine("Cheese: {0}", CheeseType == CheeseType.Cheddar ? "cheddar" : "Swiss");
            Console.WriteLine("Mustard: {0}", toHumanResponse(HasMustard));
            Console.WriteLine("Toasted: {0}", toHumanResponse(IsToasted));
            Console.WriteLine("Vegtables: {0}", String.Join(", ", Vegetables));
        }

        private string toHumanResponse(bool flag)
        {
            return flag ? "yes" : "no";
        }
    }

    public enum MeatType
    {
        Turkey = 0,
        Ham = 1
    }

    public enum BreadType
    {
        White = 0,
        Wholemeal = 1,
        Italian = 2
    }

    public enum CheeseType
    {
        Cheddar = 0,
        Swiss = 1
    }
}
