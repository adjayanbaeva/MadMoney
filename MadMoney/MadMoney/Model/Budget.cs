using System;
using System.Collections.Generic;
using System.Text;

namespace MadMoney.Model
{
    // Not static or singleton as it may make sense in the future
    // to have more than one Budget (that is, set of BudgetMonths)
    public class Budget
    {
        private List<BudgetMonth> budgetMonths;
        public Budget()
        {
            budgetMonths = new List<BudgetMonth>();
        }

        public IEnumerable<BudgetMonth> BudgetMonths
        { get { return budgetMonths; } }
        // may need to provide additional ways to access/modify BudgetMonths collection

        public void AddBudgetMonth(BudgetMonth budget)
        {
            budgetMonths.Add(budget);
        }
        // Budgets must enforce that no more than one BudgetMonth
        // exists for any one calendar month
        
        // The design doesn't provide for deleting a budget month
        // public void DeleteBudget(DateTime month) { }
        
    }
}
