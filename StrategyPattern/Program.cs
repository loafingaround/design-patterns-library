using System;
using StrategyPattern.Business.Models;
using StrategyPattern.Business.Strategies;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                }
            };

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", ItemType.Literature, 100m), 1);

            Console.WriteLine(order.GetTax(new SwedenSalesTaxStrategy()));
        }
    }
}
