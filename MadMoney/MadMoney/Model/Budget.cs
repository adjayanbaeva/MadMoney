using System;
using System.Collections.Generic;
using System.Text;

namespace MadMoney.Model
{
    // Not static or singleton as it may make sense in the (hypothetical) future
    // to have more than one Budget (that is, set of BudgetMonths)
    public class Budget
    {
        private List<BudgetMonth> budgetMonths;
        public Budget()
        {
            budgetMonths = new List<BudgetMonth>();
        }

        // TODO:
        //BudgetMonth class type is best as an implementation detail of the Model
        public IEnumerable<BudgetMonth> BudgetMonths
        { get { return budgetMonths; } }
        // may need to provide additional ways to access/modify BudgetMonths collection

        public void CreateNewMonth(decimal goal, DateTime monthAndYear)
        {
            budgetMonths.Add(new BudgetMonth(goal, monthAndYear));
            // Budget should not expose the BudgetMonth type at all
            // BudgetMonth is a class type that is internal to the implementation
            // of the model

            // TODO:
            // Budget must enforce that no more than one BudgetMonth
            // exists for any one calendar month
        }


        // The design doesn't provide for deleting a budget month
        // public void DeleteBudget(DateTime month) { }


        // ask budget, here, give me all of the expenses for this budget month

        // ask the model, hey, give me the budget for this month
        // hey, give me the expenses for this month
        // things that are calculated (instead of stored) should be handled in
        // the viewmodel rather than in the model
        // viewmodels will likely implement thier own  (or possibly utility classes
        // shared between viewmodels) 
    }
}
