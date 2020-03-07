using MadMoney.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MadMoney.ViewModel
{
    // This is one of Brillan's testing classes
    // Not going into the product.
    // Creates a dummy BudgetMonth so that the UI can bind to it
    public static class MainPageTestManager
    {


        private static BudgetMonth february =
             new BudgetMonth(2000M, DateTime.Parse("2020-02-01"));

        public static BudgetMonth GetTestMonth()
        {
            february.AddExpense(
                new Expense("Trader Joe's",
                            42.50M,
                            DateTime.Parse("2020-02-01"),
                            ExpenseCategory.Groceries));
            february.AddExpense(
                new Expense("Amazon.com",
                            125.37M,
                            DateTime.Parse("2020-02-13"),
                            ExpenseCategory.TreatYoSelf));

            return february;
        }


        public static void UpdateGoal(decimal newGoal)
        {
            february.BudgetGoal = newGoal;
        }

    }
}
