using EventAggregatorPattern.Events;
using System;
using System.Text;

namespace EventAggregatorPattern.Subscribers
{
    // simulates an email client

    // class has no access to publisher, i.e. is decoupled from it

    // signature of class expresses intent w/o reading through class
    // several different approaches to event aggregator pattern exist
    // this is one of them (apparently advocated by Jeremy Miller, author of StructureMap)
    class EmailClient: ISubscriber<MessageSentEvent>
    {
        private string name;

        public EmailClient(string name, IEventAggregator eventAggregator)
        {
            this.name = name;

            eventAggregator.Subscribe(this);
        }

        private void DisplayEmail(Email email)
        {
            // build up string and output in one go, else various console outputs from different Screen objects get intermingled
            StringBuilder toPrint = new StringBuilder();

            toPrint.AppendFormat("--------- Email client on {0} ---------", name).AppendLine();

            toPrint.AppendFormat("Message").AppendLine();
            toPrint.AppendFormat(@"""""""""""""""").AppendLine();

            toPrint.AppendFormat("Subject: {0}", email.Subject).AppendLine();
            toPrint.AppendFormat("From: {0}", email.From).AppendLine();
            toPrint.AppendFormat("To: {0}", email.To).AppendLine();
            toPrint.AppendFormat("Body:").AppendLine();
            toPrint.AppendFormat(email.Body).AppendLine();

            toPrint.AppendFormat("===============================").AppendLine();

            Console.Write(toPrint.ToString());
        }

        public void OnEvent(MessageSentEvent e)
        {
            DisplayEmail(e.Email);
        }
    }
}
