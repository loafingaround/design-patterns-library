using System;
using System.Collections.Generic;

namespace CompositePattern
{
    // this is a node object
    class Group : Payee
    {
        public decimal AccountBalanceTotal
        {
            get
            {
                decimal total = 0;

                foreach (Payee party in Members)
                    total += party.AccountBalanceTotal;

                return total;
            }
        }

        internal List<Payee> Members { get; set; } = new List<Payee>();

        public void Pay(decimal amount)
        {
            decimal amountEach = amount / Members.Count;

            foreach (Payee party in Members)
                party.Pay(amountEach);
        }

        public void ReportFinances()
        {
            foreach (Payee payee in Members)
                payee.ReportFinances();
        }
    }
}
