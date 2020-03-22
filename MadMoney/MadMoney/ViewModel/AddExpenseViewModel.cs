using MadMoney.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MadMoney.ViewModel
{
    public class AddExpenseViewModel
    {
        public ReadOnlyCollection<ExpenseCategory> ExpenseCategories
        {
            get
            {
                return ExpenseCategoryManager.Collection;
            }
        }

        public static void Add(string descrip, decimal amount, DateTime expDate, ExpenseCategory expcat)
        {
            App.GlobalBudget.AddExpense(descrip, amount, expDate, expcat);
        }

    }
}