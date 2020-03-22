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
                           DateTime monthYear)
        {
            expenseCollection = new List<Expense>();
            BudgetGoal = goal;
            MonthYear = monthYear;
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
        // Design allows for expenses to exceed the budget goal


        // TODO:
        // Any date in a month is valid input
        // However, unlike Expense, *** extra data (that is: day, hour, minute, second)
        // is truncated as it has no reasonable use. ***
        // Specifically, MonthYear represents the duration of one month in a year
        // rather than a specific point in the year
        public DateTime MonthYear { get; }
        



        public IEnumerable<Expense> Expenses {
            get { return expenseCollection; }
        }


        public void AddExpense(Expense exp)
        {
            expenseCollection.Add(exp);
        }

        public void EditExpense(string id) { }
        // How to specify which Expense to edit?
        // How to submit those edits?



        // No protection for the bad state of multiple expenses erroneously
        // having the same Id. The first (and hopefully only) match
        // will be deleted.
        public bool DeleteExpense(string id)
        {
            var foundExpense =
                expenseCollection.Find(expense => expense.Id == id);

            // For a reference type T, the Remove method on List<T> checks
            // for reference equality, that is, it checks to see if the
            // object parameter is literally the same object in memory as
            // the object in the list.
            return expenseCollection.Remove(foundExpense);
        }



        // View should ask ViewModel to ask Model about
        // what is valid for each of these properties, correct?
        // Not the View's job to make this decision
        // It's the Model's job to know what is valid
        // Seems relevant to put these methods on the Model
        // class directly, versus in a helper class
        // Maybe as a nested/inner class?
    }
}
