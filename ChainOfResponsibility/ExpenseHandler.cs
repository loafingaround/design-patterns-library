using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class ExpenseHandler : IExpenseHandler
    {
        private readonly IExpenseApprover approver;
        private IExpenseHandler next;

        public ExpenseHandler(IExpenseApprover expenseApprover)
        {
            this.approver = expenseApprover;
            this.next = EndOfChainExpenseHandler.Instance; // use null object pattern to assign default value, where not registered, i.e. for end of chain
        }

        public ApprovalResponse Approve(IExpenseReport expenseReport)
        {
            ApprovalResponse response = approver.Approve(expenseReport);

            if (response == ApprovalResponse.AboveApprovalLimit)
            {
                Console.WriteLine("[LOG: passing up the chain.]");
                return this.next.Approve(expenseReport);
            }

            return response;
        }

        public void RegisterNext(IExpenseHandler expenseHandler)
        {
            this.next = expenseHandler;
        }
    }
}
