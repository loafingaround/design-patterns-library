using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Employee : IExpenseApprover
    {
        private string name;

        private decimal approvalLimit;

        public Employee(string name, decimal approvalLimit)
        {
            this.name = name;
            this.approvalLimit = approvalLimit;
        }

        public ApprovalResponse Approve(IExpenseReport expenseReport)
        {
            if(expenseReport.Total > approvalLimit)
            {
                Console.WriteLine("[LOG: amount is too much for {0} to approve.]", name);
                return ApprovalResponse.AboveApprovalLimit;
            }
            else
            {
                Console.WriteLine("[LOG: {0} approved the amount.]", name);
                return ApprovalResponse.Approved;
            }
        }
    }
}
