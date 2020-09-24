using System.Collections.Generic;
using StrategyPattern.Business.Strategies;

namespace StrategyPattern.Business.Models
{
    public class Order
    {
        public Dictionary<Item, int> LineItems { get; set; }

        public ShippingDetails ShippingDetails { get; set; }
        public decimal TotalPrice { get; set; }

        public ISalesTaxStrategy SalesTaxStrategy { get; set; }

        public decimal GetTax()
        {
            if (SalesTaxStrategy == null)
                return 0;

            return SalesTaxStrategy.GetTax(this);
        }
    }
}