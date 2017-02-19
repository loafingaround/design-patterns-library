using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class EndOfChainExpenseHandler : IExpenseHandler
    {
        private EndOfChainExpenseHandler()
        {
        }

        public ApprovalResponse Approve(IExpenseReport expenseReport)
        {
            return ApprovalResponse.Denied;
        }

        public void RegisterNext(IExpenseHandler expenseHandler)
        {
            throw new NotImplementedException("You cannot register a " + nameof(EndOfChainExpenseHandler) + " within a chain!");
        }

        public static readonly EndOfChainExpenseHandler Instance = new EndOfChainExpenseHandler();
    }
}
