using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    interface IExpenseApprover
    {
        ApprovalResponse Approve(IExpenseReport expenseReport);
    }
}
