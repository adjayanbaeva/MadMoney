using System;
using System.ComponentModel;
using System.Text;

namespace MadMoney.Model
{
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
        /// Category of the Expense.
        /// Example: Groceries
        /// </summary>
        public ExpenseCategory Category { get; set; }
        // TODO: Remember when serializing this property to file
        // Serialize as the string representation of the enum
        // Not the value. String is sturdier. More likely to withstand
        // changes to the enum between between builds of the app


        // ** NOTE:
        // Shift in advice about where data validation logic belongs
        // I think that I may have misunderstood this before
        // it's business logic data, so it belongs in the ViewModel(s)
        // Model's job to implement the in-memory data store
        // Subjective whether file i/o class should be interacted with
        // by the ViewModel or the Model
        // Pros and cons for each
    }
}
