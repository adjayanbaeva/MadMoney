using MadMoney.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MadMoney
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class welcome_page3 : ContentPage
    {
        public welcome_page3()
        {
            InitializeComponent();
            
            BindingContext = new EditGoalViewModel();
         
        }

        private void OnSaveChanges_Clicked(object sender, EventArgs e)
        {
            if (currentGoal.Text == " " || currentGoal.Text == null || currentGoal.Text == "")
            {
                ErrorLabel.Text = "Please enter valid amount";

            }
            else
            {
                var goal = decimal.Parse(currentGoal.Text);
                if (goal < 0)
                {
                    ErrorLabel.Text = "Please enter valid amount";
                }
                else
                {
                    App.GlobalBudget.SetBudgetGoalByMonthYear(goal, App.GlobalViewData.CurrentlyDisplayedMonthYear);


                    Navigation.PushAsync(new MainBudgetSummaryPage());
                }
            }
        }

        private void OnCancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainBudgetSummaryPage());
        }
    }
}