﻿using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies.SalesTax
{
    // strategy class
    public class UsSalesTaxStrategy: ISalesTaxStrategy
    {
        public decimal GetTax(Order order)
        {
            switch (order.ShippingDetails.DestinationCountry.ToLowerInvariant())
            {
                case "la": return order.TotalPrice * 0.095m;
                case "ny": return order.TotalPrice * 0.04m;
                case "nyc": return order.TotalPrice * 0.045m;
                default: return 0m;
            }
        }
    }
}