using EventAggregatorPattern.Events;

namespace EventAggregatorPattern.Publishers
{
    // class has no access to subscribers, i.e. is decoupled from it
    class MailingList
    {
        IEventAggregator eventAggregator;

        public MailingList(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        public void Send(Email email)
        {
            // do not have to check that event is not null
            // i.e. whether there were any subscribers
            // can pass Publish any type of object
            eventAggregator.Publish(new EmailSentEvent
            {
                Email = email
            });
        }
    }
}
