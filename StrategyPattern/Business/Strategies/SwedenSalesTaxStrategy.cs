using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies
{
    public class SwedenSalesTaxStrategy: ISalesTaxStrategy
    {
        public decimal GetTax(Order order)
        {
            decimal totalTax = 0m;

            foreach (var item in order.LineItems)
            {
                switch (item.Key.Type)
                {
                    case ItemType.Food:
                        totalTax += item.Key.Price * 0.06m * item.Value;
                        break;
                    case ItemType.Literature:
                        totalTax += item.Key.Price * 0.08m * item.Value;
                        break;
                    case ItemType.Hardware:
                    case ItemType.Service:
                        totalTax += item.Key.Price * 0.25m * item.Value;
                        break;
                }
            }

            return totalTax;
        }
    }
}