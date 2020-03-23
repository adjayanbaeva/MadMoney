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

        public string MonthYear_ForCurrentlyShownMonth_String
        {
            get
            {
                return App.GlobalViewData.CurrentlyDisplayedMonthYear.ToString("MMMM yyyy");
            }
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

                // Sum in LINQ using a selector:
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




        // TODO:
        // Ideally, the ViewModel would handle all string formatting for the View.
        // Seems like this would involve programmatically configuring the ItemTemplate,
        // DataTemplate, and/or ViewCell of the ListView
        // (For now, setting the formatting directly in the XAML)
        public IEnumerable<Expense> Expenses
        {
            get
            {
                return App.GlobalBudget.GetBudgetMonthByMonthYear(
                            App.GlobalViewData.CurrentlyDisplayedMonthYear).Expenses;
            }
        }



        // Maybe the methods on the viewmodel class should be static and thus invoked
        // using the class name rather than from the instance of the viewmodel
        // that the view has.
        // Would better follows Kal's example of the static SoundManager class
        public void LoadPreviousMonth()
        {
            LoadAdjacentMonthHelper(AdjacentMonth.Previous);
        }

        public void LoadNextMonth()
        {
            LoadAdjacentMonthHelper(AdjacentMonth.Next);
        }

        // Represents the number of months to add or subtract from a DateTime
        private enum AdjacentMonth
        { 
            Previous = -1,
            Next = 1
        }


        private void LoadAdjacentMonthHelper(AdjacentMonth direction)
        {
            // Determine which chronological month we are going to
            DateTime destMonth =
                App.GlobalViewData.CurrentlyDisplayedMonthYear.AddMonths((int)direction);

            // If no budget exists yet for that month
            if (false == App.GlobalBudget.BudgetMonthExistByMonthYear(destMonth))
            {
                // create the budget for that month
                // (copy the goal from the current month)
                var copiedGoal = App.GlobalBudget.GetBudgetGoalByMonthYear(
                    App.GlobalViewData.CurrentlyDisplayedMonthYear);
                App.GlobalBudget.CreateNewMonth(copiedGoal, destMonth);
            }

            // Now that we know that a budget exists for the month that we are going to
            // Set the currently displayed month to be the destination month
            App.GlobalViewData.CurrentlyDisplayedMonthYear = destMonth;
        }

        //// For testing purposes only
        //public static void UpdateGoal(decimal newGoal)
        //{
        //    App.GlobalBudget.GetBudgetMonthByMonthYear(
        //        App.GlobalViewData.CurrentlyDisplayedMonthYear).BudgetGoal = newGoal;

        //}



        //// Expense Categories only exposed to the View here for purpose of
        //// demoing to Andrea for Add/Edit expense
        //public ReadOnlyCollection<ExpenseCategory> ExpenseCategories
        //{
        //    get
        //    {
        //        return ExpenseCategoryManager.Collection;
        //    }
        //}



    }
}
