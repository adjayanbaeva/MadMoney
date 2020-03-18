using System;
using System.Collections.Generic;
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

        //public IEnumerable<Expense> Expenses
        //{
        //    get
        //    {
        //        return App.GlobalBudget.GetBudgetMonthByMonthYear(;
        //    }
        //}


    }
}
