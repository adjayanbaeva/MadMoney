using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MadMoney.Model
{
    // ? Write a proposal for this class
  
    //public class ExpenseCategory2
    //{
    //    public char Emoji { get; set; }
    //    public string Name { get; set; }
    //}

    
    // TODO (Lynn):
    // ExpenseCategory more appropriately its own class type
    // rather than just an enum.
    // to contain the emoji that corresponds to each category
    // as well as the string the corresponds to each category
    public enum ExpenseCategory
    { 
        Groceries,
        Restaurants,
        Rent,
        Healthcare,
        Gifts,
        TreatYoSelf
    }





    public class ExpenseCategory2
    {
        public ExpenseCategory Category { get; set; }


    }





    public class Expense // : INotifyPropertyChanged <- May not need this
        // May ultimately be unnnecessary as I don't think that an Expense
        // can change while a page is loaded (rather between pages)
        // Bindings are re-established each time a Page is loaded, correct?
    {
        /// <summary>
        /// Constructor for new created Expenses.
        /// </summary>
        /// <param name="descrip"></param>
        /// <param name="amt"></param>
        /// <param name="date"></param>
        /// <param name="cat"></param>
        public Expense(string descrip,
                       decimal amt,
                       DateTime date,
                       ExpenseCategory cat)
        {
            _id = Guid.NewGuid();
            Description = descrip;
            Amount = amt;
            Date = date;
            Category = cat;
        }
        /// <summary>
        /// Constructor for Expenses deserialized from file.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descrip"></param>
        /// <param name="amt"></param>
        /// <param name="date"></param>
        /// <param name="cat"></param>
        public Expense(string id,
                       string descrip,
                       decimal amt,
                       DateTime date,
                       ExpenseCategory cat)
        {
            _id = new Guid(id);
            Description = descrip;
            Amount = amt;
            Date = date;
            Category = cat;
        }

        /// <summary>
        /// Data field that backs Id property
        /// </summary>
        private Guid _id;

        /// <summary>
        /// Unique identifier for the Expense.
        /// Example: 0f8fad5b-d9cb-469f-a165-70867728950e
        /// </summary>
        // Immutable after construction / deserialization from disk
        public string Id
        {
            get { return _id.ToString(); }
        }

        /// <summary>
        /// Name that describes the Expense.
        /// Example: "Trader Joe's"
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Amount of the Expense in USD dollars and cents.
        /// Example: $42.50
        /// </summary>
        public decimal Amount { get; set; }
        // TODO: ViewModel(s) to validate user input before constructing an
        // Expense (two decimal places)
        // Could be put in a shared utility class for the Set Goal, Add Expense
        // and Edit Expense pages.
        // Or, both Ainur and Andrea could implement it independently for practice.
        // Also support (but don't require) comma seperators
        // Either way works for Brillan.

        /// <summary>
        /// Year, month and day of the Expense.
        /// Example: 2020-02-01 (February 1, 2020)
        /// Note: Time (hour, minute, second) is accepted and stored for
        /// future use.
        /// </summary>
        public DateTime Date { get; set; }


        /// <summary>
        /// Category of the Expense. (Currently of ExpenseCategory enum type.)
        /// Example: Groceries
        /// </summary>
        // TODO: Needs to be updated to be of the type of the enum class wrapper type
        // that Lynn is working on this as a part of Filter Expenses page development
        // This new class type to get its own cs file, correct?
        public ExpenseCategory Category { get; set; }


        // ** NOTE:
        // Shift in advice about where data validation logic belongs
        // I think that I may have misunderstood this before
        // it's business logic data, so it belongs in the ViewModel(s)
        // Model's job to implement the in-memory data store
        // Subjective whether file i/o class should be interacted with
        // by the ViewModel or the Model
        // Pros and cons for each
        // TODO: Ask Kal/TAs
    }
}
