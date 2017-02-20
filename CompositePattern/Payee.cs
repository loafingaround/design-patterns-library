namespace CompositePattern
{
    // this is the component
    interface Payee
    {
        decimal AccountBalanceTotal { get; }

        void Pay(decimal amount);

        void ReportFinances();
    }
}
