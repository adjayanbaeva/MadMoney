using System;
using System.Collections.Generic;
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
    public class Expense
    {
        // Which constructors are desired?
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
        // need more user input validation methods


        // complete properties on Expense class


        // View should ask ViewModel to ask Model about
        // what is valid for each of these properties, correct?
        // Not the View's job to make this decision
        // It's the Model's job to know what is valid
        // Seems relevant to put these methods on the Model
        // class directly, versus in a helper class
        // Maybe as a nested/inner class?


    }
}
