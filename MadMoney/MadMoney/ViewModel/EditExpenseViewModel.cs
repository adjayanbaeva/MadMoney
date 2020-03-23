using MadMoney.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MadMoney.ViewModel
{
    class EditExpenseViewModel
    {
        private static Expense selectedExpense;
        private static string editId;
        public EditExpenseViewModel(string expenseId)
        {
            editId = expenseId;

            //With the expenseID, we already know which object is selected - it has been identified. The next step is to create th object and store it.
            //In order to reference the stored object, we must save it externally / outside of the constructor
            selectedExpense = App.GlobalBudget.GetCopyOfExpenseById(editId);
        }

        //Properties of Expense that have been exposted for binding
        //Remember: You can "get" anything - in this instance, we set the get property to the properties of the existing, stored object
        public string ExpDescrip {get{return selectedExpense.Description;}}
        public decimal ExpAmt { get { return selectedExpense.Amount;} }
        public DateTime ExpDate { get { return selectedExpense.Date; } }
        public ExpenseCategory ExpCateg { get { return selectedExpense.Category; } }


        //Collection needed for Categories picker
        public ReadOnlyCollection<ExpenseCategory> ExpenseCategories
        {
            get
            {
                return ExpenseCategoryManager.Collection;
            }
        }

        //var editexpense = App.GlobalBudget.GetCopyOfExpenseById(idOfExpenseToEdit);

        public static void UpdateChanges(string editdescrip, decimal editamt, DateTime editdate, ExpenseCategory editcat)
        {
            if (editdescrip != selectedExpense.Description)
            {
                App.GlobalBudget.SetDescriptionForExpenseById(editId, editdescrip);
            }

            if (editamt != selectedExpense.Amount)
            {
                App.GlobalBudget.SetAmountForExpenseById(editId, editamt);
            }

            if (editdate != selectedExpense.Date)
            {
                App.GlobalBudget.SetDateForExpenseById(editId, editdate);
            }

            if (editcat != selectedExpense.Category)
            {
                App.GlobalBudget.SetCategoryForExpenseById(editId, editcat);
            }
        }
    }
}
