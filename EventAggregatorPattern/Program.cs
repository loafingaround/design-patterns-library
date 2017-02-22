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

            MailingList list = new MailingList(ea);

            EmailClient client1 = new EmailClient("Joe's Surface Pro", ea);
            EmailClient client2 = new EmailClient("Rebecca's Mac", ea);
            EmailClient client3 = new EmailClient("Gerry's Android phone", ea);

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

            Console.ReadLine();
        }
    }
}
