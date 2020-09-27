using System.Collections.Generic;
using StrategyPattern.Business.Strategies.SalesTax;
using StrategyPattern.Business.Strategies.Invoice;

namespace StrategyPattern.Business.Models
{
    // Context class
    public class Order
    {
        public Dictionary<Item, int> LineItems { get; } = new Dictionary<Item, int>();

        public ShippingDetails ShippingDetails { get; set; }
        public decimal TotalPrice { get; }

        public ISalesTaxStrategy SalesTaxStrategy { get; set; }

        public IInvoiceStrategy InvoiceStrategy { get; set; }

        public decimal GetTax(ISalesTaxStrategy salesTaxStrategy = null)
        {
            salesTaxStrategy = salesTaxStrategy ?? SalesTaxStrategy;

            if (salesTaxStrategy == null)
                return 0;

            return salesTaxStrategy.GetTax(this);
        }

        public void FinalizeOrder()
        {
            // Some logic to make certain checks, e.g. is there at least 1 payment with a payment provider type of "Invoice", is the amount due > 0,
            // is the shipping status "Waiting For Payment" - else return an error

            InvoiceStrategy.Generate(this);
        }
    }
}