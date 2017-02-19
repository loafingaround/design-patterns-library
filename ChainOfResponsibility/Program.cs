using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            // smaller amount of code than with non-CoR solution:

            IExpenseHandler mark = new ExpenseHandler(new Employee("Mark", 0));
            IExpenseHandler bridget = new ExpenseHandler(new Employee("Bridget", 50));
            IExpenseHandler hamish = new ExpenseHandler(new Employee("Hamish", 100));
            IExpenseHandler kristine = new ExpenseHandler(new Employee("Kristine", 2000));
            IExpenseHandler yan = new ExpenseHandler(new Employee("Yan", 100000));

            // set up chain
            mark.RegisterNext(bridget);
            bridget.RegisterNext(hamish);
            hamish.RegisterNext(kristine);
            kristine.RegisterNext(yan);

            decimal amount;

            Console.Write("Enter expense report amount: ");
            string amountStr = Console.ReadLine();

            if(decimal.TryParse(amountStr, out amount))
            {
                IExpenseReport expense = new ExpenseReport(amount);

                // clean interface, hiding business logic of how approval works (which would otherwise involve looping through employees at this point)
                ApprovalResponse response = mark.Approve(expense);

                Console.WriteLine("The request was: {0}", response);
                Console.ReadLine();
            }
        }
    }
}
