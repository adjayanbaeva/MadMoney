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
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainBudgetSummaryPage : ContentPage
    {
        //private IEnumerable<Expense> expenseCollection;

        public MainBudgetSummaryPage()
        {
            //expenseCollection = MainPageTestManager.GetTestMonth().Expenses;


            BindingContext = MainPageTestManager.GetTestMonth();

            InitializeComponent();


        }

        private void PreviousMonthButton_Pressed(object sender, EventArgs e)
        {


            MainPageTestManager.UpdateGoal( MainPageTestManager.GetTestMonth().BudgetGoal - 100);
            return;
        }

        private void NextMonthButton_Pressed(object sender, EventArgs e)
        {
            MainPageTestManager.UpdateGoal(MainPageTestManager.GetTestMonth().BudgetGoal + 100);
            return;
        }

        private void AddExpenseButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddExpense());
        }

        private async void ExpensesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new EditExpense
                {
                    BindingContext = e.SelectedItem as Expense
                });
            }
        }
    }
}
