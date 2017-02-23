using System;

namespace EventAggregatorPattern
{
    class StockPriceUpdate
    {
        public string Symbol { get; set; }

        public double Price { get; set; }

        public bool IsUp { get; set; }

        public DateTime Time { get; set; }
    }
}
