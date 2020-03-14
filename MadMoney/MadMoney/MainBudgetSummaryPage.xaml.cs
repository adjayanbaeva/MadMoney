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
    }
}
