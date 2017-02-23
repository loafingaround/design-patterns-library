using EventAggregatorPattern.Events;

namespace EventAggregatorPattern.Publishers
{
    class StockMarketPriceTracker
    {
        IEventAggregator eventAggregator;

        public StockMarketPriceTracker(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        public void SendPriceUpdate(StockPriceUpdate update)
        {
            eventAggregator.Publish(new StockPriceUpdateSent
            {
                Update = update
            });
        }
    }
}
