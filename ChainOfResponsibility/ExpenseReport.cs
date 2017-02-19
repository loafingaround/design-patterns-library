﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class ExpenseReport : IExpenseReport
    {
        public ExpenseReport(decimal total)
        {
            Total = total;
        }
        
        public decimal Total { get; set; }
    }
}
