using EventAggregatorPattern.Publishers;
using EventAggregatorPattern.Subscribers;
using System;

namespace EventAggregatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IEventAggregator ea = new SimpleEventAggregator();

            // publishers:

            MailingList list = new MailingList(ea);

            StockMarketPriceTracker tracker = new StockMarketPriceTracker(ea);

            // subscribers:

            EmailClient client1 = new EmailClient("Joe's Surface Pro", ea);
            EmailClient client2 = new EmailClient("Rebecca's Mac", ea);
            EmailClient client3 = new EmailClient("Gerry's Android phone", ea);

            StockMarketTicker tickers = new StockMarketTicker("Gerry's Android phone", ea);

            // now publish some stuff:

            tracker.SendPriceUpdate(new StockPriceUpdate
            {
                Symbol = "LNTH",
                IsUp = true,
                Price = 12.18,
                Time = DateTime.Now - new TimeSpan(1, 4, 23, 5)
            });

            list.Send(new Email
            {
                To = "all@pigsowners.net",
                From = "pat@btinternet.com",
                Subject = "Pig feed event",
                Body = @"Dear all,

Please come along to our pig feed event at 2pm on Saturday ..........

Yours,

Pat"
            });

            tracker.SendPriceUpdate(new StockPriceUpdate
            {
                Symbol = "SND",
                IsUp = false,
                Price = 1.88,
                Time = DateTime.Now
            });

            Console.ReadLine();
        }
    }
}
