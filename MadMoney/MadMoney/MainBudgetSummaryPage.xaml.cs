using MadMoney.Model;
using MadMoney.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MadMoney
{
    [DesignTimeVisible(false)]
    public partial class MainBudgetSummaryPage : ContentPage
    {
        private MainBudgetSummaryPageViewModel ViewModel = null;

        public MainBudgetSummaryPage()
        {
            App.GlobalBudget.AddExpense("Amazon.com",
                            125.37M,
                            DateTime.Parse("2020-03-13"),
                            ExpenseCategory.Enum.TreatYoSelf);


            App.GlobalBudget.AddExpense("Trader Joe's",
                            42.50M,
                            DateTime.Parse("2020-03-01"),
                            ExpenseCategory.Enum.Groceries);
          

            BindingContext = ViewModel = new MainBudgetSummaryPageViewModel();



            InitializeComponent();

            // Demo code from when discussing with Ainur about possibilities
            // for not showing a 0 (or any default value) in the set goal field
            // the first time that the page is shown
            // BudgetGoalText.Text = String.Empty;
        }

        private void PreviousMonthButton_Pressed(object sender, EventArgs e)
        {


            // Demo code for when we were pretending that this was Andrea's
            // Event handler for her Save Expense button handler
            // (or more properly, the ViewModel method that the event handler
            // calls)
            // Maintaining it here for reference for the time being
            //string des = "Trader Joe's";
            //decimal amt = 245.90M;
            //DateTime date = DateTime.Parse("2020-02-01");
            //ExpenseCategory.Enum cat = ExpenseCategory.Enum.Groceries;
            //App.GlobalBudget.AddExpense(des, amt, date, cat);


            // Simlar demo code for Ainur's Save button on the GetGoal page
            //App.GlobalBudget.CreateNewMonth(amt, date);

            MainBudgetSummaryPageViewModel.UpdateGoal( ViewModel.BudgetGoal - 100);
            return;
        }

        private void NextMonthButton_Pressed(object sender, EventArgs e)
        {
            MainBudgetSummaryPageViewModel.UpdateGoal( ViewModel.BudgetGoal + 100);
            return;
        }

        private void AddExpenseButton_Top_Pressed(object sender, EventArgs e)
        {

        }

        private void FilterExpensesButton_Pressed(object sender, EventArgs e)
        {

        }
    }
}
