using System;
using System.Collections.Generic;
using System.Text;

namespace MadMoney.Model
{
    // Baseline default implementation
    public class BudgetMonth
    {
        private List<Expense> expenseCollection;

        // Which constructors are desired?
        public BudgetMonth(decimal goal,
                           DateTime date)
        {
            expenseCollection = new List<Expense>();
            BudgetGoal = goal;
            StartDate = date;
        }
        // the StartDate of the month can only be set as the
        // BudgetMonth is constructed

        public decimal BudgetGoal { get; set; }
        // Expense can go over budget goal

        // If AmountRemainingInBudgetGoal > 0, user has budget left this month
        // If AmountRemainingInBudgetGoal == 0, user has used up budget exactly
        // If AmountRemainingInBudgetGoal < 0, user has exceeded budget
        public decimal AmountRemainingInBudgetGoal { get; }

        // ??? A BudgetMonth's StartDate (that is the first of the month)
        // Cannot be modified by users after the BudgetMonth is created
        public DateTime StartDate { get; }
        // explore using a different type for this?

        public IEnumerable<Expense> Expenses {
            get { return expenseCollection; }
        }
        // Instead of: public IEnumerable<Expense> GetExpenses() { return null; }

        // may need to provide additional ways to access/modify Expense collection

        public void AddExpense(Expense exp)
        {
            expenseCollection.Add(exp);
        }

        public void EditExpense(Guid guid) { }
        // How to specify which Expense to edit?
        // How to submit those edits?

        public void DeleteExpense(Guid guid) { }
        // How to specify which Expense to delete?


        // View should ask ViewModel to ask Model about
        // what is valid for each of these properties, correct?
        // Not the View's job to make this decision
        // It's the Model's job to know what is valid
        // Seems relevant to put these methods on the Model
        // class directly, versus in a helper class
        // Maybe as a nested/inner class?
    }
}
