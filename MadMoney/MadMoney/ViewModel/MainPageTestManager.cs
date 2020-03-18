using MadMoney.Model;
using System;
using System.Collections.Generic;
using System.Text;
using MadMoney;
using System.Linq;

namespace MadMoney.ViewModel
{
    // This is one of Brillan's testing classes
    // Not going into the product.
    // Creates a dummy BudgetMonth so that the UI can bind to it
    public static class MainPageTestManager
    {
        public static BudgetMonth GetTestMonth()
        {





            return App.GlobalBudget.BudgetMonths.ToArray()[0];
        }


        public static void UpdateGoal(decimal newGoal)
        {
            App.GlobalBudget.BudgetMonths.ToArray()[0].BudgetGoal = newGoal;
        }

    }
}
