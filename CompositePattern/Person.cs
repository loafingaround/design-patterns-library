using System;

namespace CompositePattern
{
    // this is a leaf object
    class Person : Payee
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        private decimal accountBalanceTotal = 0;

        public decimal AccountBalanceTotal { get { return accountBalanceTotal; } }

        public void Pay(decimal amount)
        {
            accountBalanceTotal += amount;
        }

        public void ReportFinances()
        {
            Console.WriteLine("{0} now has {1:c} in his/her account", Name, AccountBalanceTotal);
        }
    }
}
