namespace EventAggregatorPattern
{
    internal interface ISubscriber<T>
    {
        void OnEvent(T e);
    }
}