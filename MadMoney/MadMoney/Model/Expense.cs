using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MadMoney.Model
{
    public enum ExpenseCategory
    {
        Groceries,
        Restaurants,
        Rent,
        Healthcare,
        Gifts,
        TreatYoSelf
    }

    // Baseline default implementation
    public class Expense // : INotifyPropertyChanged
                         // None of my test data changes Expenses yet
                         // May ultimately be unnnecessary as an Expense may not
                         // change while it is bound to a UI control
                         // Bindings are re-established each time a Page is loaded, correct?

    //AT Notes: we only need to bind to the picker soundcategory class that will be created
    //AT Notes: Since expense object has not yet been created, need to instantiate the object to save the information: View has the infomration and gives it to view model and says, 
    //here's the information, and the viewmodel creates the object with the new expense
    //BindingContext = newAddExpenseViewMode;();


    
    {
        // Which constructors are desired?
        public Expense(ExpenseCategory cat)
        {
            Category = cat;
        }
        public Expense(string descrip,
                       decimal amt,
                       DateTime date,
                       ExpenseCategory cat)
        {
            Guid = Guid.NewGuid();
            Description = descrip;
            Amount = amt;
            Date = date;
            Category = cat;
        }

        public Guid Guid { get; }
        // Immutable after construction
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public ExpenseCategory Category { get; set; }

        public bool IsValidAmount() { return true; }
    }
}
        // need more user input validation methods


        // complete properties on Expense class


        // View should ask ViewModel to ask Model about
        // what is valid for each of these properties, correct?
        // Not the View's job to make this decision
        // It's the Model's job to know what is valid
        // Seems relevant to put these methods on the Model
        // class directly, versus in a helper class
        // Maybe as a nested/inner class?
