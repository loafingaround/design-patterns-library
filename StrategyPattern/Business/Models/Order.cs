using System.Collections.Generic;
using StrategyPattern.Business.Strategies;

namespace StrategyPattern.Business.Models
{
    // Context class
    public class Order
    {
        public Dictionary<Item, int> LineItems { get; } = new Dictionary<Item, int>();

        public ShippingDetails ShippingDetails { get; set; }
        public decimal TotalPrice { get; }

        public ISalesTaxStrategy SalesTaxStrategy { get; set; }

        public decimal GetTax(ISalesTaxStrategy salesTaxStrategy = null)
        {
            salesTaxStrategy = salesTaxStrategy ?? SalesTaxStrategy;

            if (salesTaxStrategy == null)
                return 0;

            return salesTaxStrategy.GetTax(this);
        }
    }
}