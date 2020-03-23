using System;
using System.Collections.Generic;
using System.Text;

namespace MadMoney.ViewModel
{
    public class EditGoalViewModel
    {
        public decimal Goal { get; }

        public decimal BudgetGoal
        {
            get
            {
                return App.GlobalBudget.GetBudgetGoalByMonthYear(App.GlobalViewData.CurrentlyDisplayedMonthYear);
            }

        }

        public string DisplayedMonth
        {
            get
            {
                return App.GlobalViewData.CurrentlyDisplayedMonthYear.ToString("MMMM yyyy");
            }
        }



    }
}
