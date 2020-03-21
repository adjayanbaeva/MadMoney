using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MadMoney.Model;

namespace MadMoney.ViewModel
{
    public class MainBudgetSummaryPageViewModel
    {
        public MainBudgetSummaryPageViewModel()
        { 
        
        }

        public decimal BudgetGoal_ForCurrentlyShownMonth_Decimal
        {
            get
            {
                return App.GlobalBudget.GetBudgetGoalByMonthYear(
                               App.GlobalViewData.CurrentlyDisplayedMonthYear);
            }

        }

        public string BudgetGoal_ForCurrentlyShownMonth_String
        {
            get
            {
                return BudgetGoal_ForCurrentlyShownMonth_Decimal.ToString("N2");
            }
        }

        public decimal TotalExpenses_ForCurrentlyShownMonth_Decimal
        {
            get
            {
                var expenses = App.GlobalBudget.GetExpensesByMonthYear(
                            App.GlobalViewData.CurrentlyDisplayedMonthYear);

                // Sum in LINQ with a selector:
                // https://www.csharp-examples.net/linq-sum/
                return expenses.ToList().Sum(expense => expense.Amount);
            }
        }

        public string TotalExpenses_ForCurrentlyShownMonth_String
        {
            get
            {
                return TotalExpenses_ForCurrentlyShownMonth_Decimal.ToString("N2");
            }
        }

        // Delta between the user's specified budget goal for the month and the
        // current total of expenses for the month
        public decimal BudgetRemaining_ForCurrentlyShownMonth_Decimal
        {
            get
            {
                return BudgetGoal_ForCurrentlyShownMonth_Decimal - TotalExpenses_ForCurrentlyShownMonth_Decimal;
            }
        }

        public string BudgetRemaining_ForCurrentlyShownMonth_String
        {
            get
            {
                return BudgetRemaining_ForCurrentlyShownMonth_Decimal.ToString("N2");
            }
        }



        // Expense Categories only exposed to the View here for purpose of demoing to Andrea for Add/Edit expense
        public ReadOnlyCollection<ExpenseCategory> ExpenseCategories
        {
            get
            {
                return ExpenseCategoryManager.Collection;
            }
        }


        // For testing purposes only
        public static void UpdateGoal(decimal newGoal)
        {
            App.GlobalBudget.GetBudgetMonthByMonthYear(
                App.GlobalViewData.CurrentlyDisplayedMonthYear).BudgetGoal = newGoal;

        }



        //public IEnumerable<Expense> Expenses
        //{
        //    get
        //    {
        //        return App.GlobalBudget.GetBudgetMonthByMonthYear(;
        //    }
        //}



        


    }
}
