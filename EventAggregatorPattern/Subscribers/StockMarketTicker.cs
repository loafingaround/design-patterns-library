using System;
using EventAggregatorPattern.Events;

namespace EventAggregatorPattern.Subscribers
{
    // added second subscriber type just through implementing ISubscriber<> with different type parameter to indicate type of event its interesed in
    class StockMarketTicker: ISubscriber<StockPriceUpdateSent>
    {
        string deviceName;

        public StockMarketTicker(string deviceName, IEventAggregator eventAggregator)
        {
            this.deviceName = deviceName;

            eventAggregator.Subscribe(this);
        }

        private void DisplayStockPriceUpdate(StockPriceUpdate update)
        {
            Console.WriteLine(
                "------------------------------------------------------------------------"
                + Environment.NewLine
                + deviceName + ":"
                + Environment.NewLine
                + "{0}: {1} to {2:c} ({3:G})", update.Symbol, update.IsUp ? "UP" : "DOWN", update.Price, update.Time
                + Environment.NewLine
                + "------------------------------------------------------------------------");
        }

        public void OnEvent(StockPriceUpdateSent e)
        {
            DisplayStockPriceUpdate(e.Update);
        }
    }
}
