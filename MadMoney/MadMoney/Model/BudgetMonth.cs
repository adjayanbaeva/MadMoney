using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MadMoney.Model
{
    public class BudgetMonth : INotifyPropertyChanged // ** TODO: Finish implementing this interface
    // OR...May ultimately be unnnecessary
    // Bindings are re-established each time a Page is loaded, correct?
    // Following this guide for INotifyPropertyChanged:
    // https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/raise-change-notifications--bindingsource
    // See also:
    // https://xamarinhelp.com/xamarin-forms-binding/
    {
        private List<Expense> expenseCollection;

        private decimal budgetGoal;
        public event PropertyChangedEventHandler PropertyChanged;

        // Using [CallerMemberName] means that we would be doing runtime
        // reflection, yes? Is there a way to avoid this?
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            // This line is the simplified equivelant of the
            // commented-out if statement below
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            // Note that PropertyChanged? doesn't mean "did the property change?"
            // It means "is PropertyChanged *not* null," specifically,
            // if it is not null, Invoke the method call on it,
            // else do nothing...just like the if statement below

            //if (PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            //}            
        }


        // Which constructors are desired?
        public BudgetMonth(decimal goal,
                           DateTime monthAndYear)
        {
            expenseCollection = new List<Expense>();
            BudgetGoal = goal;
            MonthAndYear = monthAndYear;
        }
        // the StartDate of the month can only be set as the
        // BudgetMonth is constructed

        public decimal BudgetGoal
        {
                get { return budgetGoal; }
                set
                {
                    budgetGoal = value;
                    NotifyPropertyChanged();
                }
        }
        // Expense can go over budget goal



        // TODO: Move AmountRemainingInBudgetGoal and any other methods
        // that calculate and return 
        // if it's not data that the Model stores, then it is something you calculate
        // That calculation is business logic and belongs in the ViewModel
        public decimal AmountRemainingInBudgetGoal { get; }
        // If AmountRemainingInBudgetGoal > 0, user has budget left this month
        // If AmountRemainingInBudgetGoal == 0, user has used up budget exactly
        // If AmountRemainingInBudgetGoal < 0, user has exceeded budget

        // TODO:
        // Any date in a month is valid input
        // However, unlike Expense, extra data (that is: day, hour, minute, second)
        // is truncated as it has no reasonable use.
        // Specifically, MonthAndYear represents the duration of one month in a year
        // rather than a specific point in the year
        public DateTime MonthAndYear { get; }
        



        public IEnumerable<Expense> Expenses {
            get { return expenseCollection; }
        }
        // Instead of: public IEnumerable<Expense> GetExpenses() { return null; }

        // may need to provide additional ways to access/modify Expense collection

        public void AddExpense(Expense exp)
        {
            expenseCollection.Add(exp);
        }

        public void EditExpense(string id) { }
        // How to specify which Expense to edit?
        // How to submit those edits?

        public void DeleteExpense(string id) { }
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
