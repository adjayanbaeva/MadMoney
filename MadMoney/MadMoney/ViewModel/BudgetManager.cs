using MadMoney.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MadMoney.ViewModel
{
    public static class BudgetManager
    {
        private static Budget budget = new Budget();
        public static Budget GetBudget() { return budget; }
    }
}
