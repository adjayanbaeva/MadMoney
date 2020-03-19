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

        public decimal BudgetGoal
        {
            get
            {
                return App.GlobalBudget.GetBudgetGoalByMonthYear(App.GlobalViewData.CurrentlyDisplayedMonthYear);
            }

        }

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
