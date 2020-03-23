using System;
using System.Collections.Generic;
using System.Text;

namespace MadMoney.ViewModel
{
    public class WelcomePageViewModel
    {
        public decimal Goal { get; }

        public string DisplayedMonth
        {
            get {
                return App.GlobalViewData.CurrentlyDisplayedMonthYear.ToString("MMMM yyyy");
                }
        }



        public void AddGoal(string goal, string goalMonth)
        {


        }
    }

    
}
