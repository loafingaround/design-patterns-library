using EventAggregatorPattern.Events;
using System;

namespace EventAggregatorPattern.Subscribers
{
    class PersonalAssistant : ISubscriber<EmailSentEvent>, ISubscriber<StockPriceUpdateSent>
    {
        private string deviceName;

        public PersonalAssistant(string deviceName, IEventAggregator eventAggregator)
        {
            this.deviceName = deviceName;

            eventAggregator.Subscribe(this);
        }

        private void DisplayStockPriceUpdateAlert(StockPriceUpdate update)
        {
            Console.WriteLine($"{deviceName} >>>>> Incoming stock price for {update.Symbol}");
        }

        private void DisplayEmailAlert(Email email)
        {
            Console.WriteLine($"{deviceName} >>>>> Incoming email: {email.Subject} from {email.From}");
        }

        public void OnEvent(EmailSentEvent e)
        {
            DisplayEmailAlert(e.Email);
        }

        public void OnEvent(StockPriceUpdateSent e)
        {
            DisplayStockPriceUpdateAlert(e.Update);
        }
    }
}
