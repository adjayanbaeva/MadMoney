using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MadMoney.Model
{
    // Creates and provides access to the single, immutable collection 

    // Note that the collection is immutable, but the ExpenseCategory objects
    // within it are mutable. Ideally the ExpenseCategory objects would be immutable.
    // Could design an IReadOnlyExpenseCategory interface for this purpose
    // ExpenseCategory class itself can't be immutable, though, else changing the
    // category of an expense (on the EditExpense page) would not be possible
    static public class ExpenseCategoryManager
    {
        private static ReadOnlyCollection<ExpenseCategory> _collection = null;
        public static ReadOnlyCollection<ExpenseCategory> Collection
        {
            get
            {
                // If the collection has already been constructed
                if (_collection != null)
                {
                    return _collection;
                }

                var categoryList = new List<ExpenseCategory>();
                foreach (var category in
                    System.Enum.GetValues(typeof(ExpenseCategory.Enum)))
                {
                    categoryList.Add(
                        new ExpenseCategory((ExpenseCategory.Enum)category));
                }

                return _collection = new ReadOnlyCollection<ExpenseCategory>(categoryList);
            }
        }
    }
}
