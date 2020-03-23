using MadMoney.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MadMoney
{
    // Initial Set Goal Page
    // No cancel button, the user must enter a goal
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class welcome_page2 : ContentPage
    {


        public welcome_page2()
        {

            InitializeComponent();

            BindingContext = new WelcomePageViewModel();
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {



            /*

            if (Regex.IsMatch(currentGoal.Text, @"^[0-9]+(\.[0-9]{1,2})?$"))
            {
                var goal = decimal.Parse(currentGoal.Text);
                App.GlobalBudget.SetBudgetGoalByMonthYear(goal, App.GlobalViewData.CurrentlyDisplayedMonthYear);
                Navigation.PushAsync(new MainBudgetSummaryPage());
            }
            else
            {
                ErrorLabel.Text = "*Please enter valid amount";
            }  */

             

            if (currentGoal.Text == " " || currentGoal.Text == null || currentGoal.Text == "")
            {
                ErrorLabel.Text = "*Please enter valid amount";

            }
            else
            {
                var goal = decimal.Parse(currentGoal.Text);
                if (goal < 0)
                {
                    ErrorLabel.Text = "*Please enter valid amount";
                }
                else if (Regex.IsMatch(currentGoal.Text, @"^[0-9]+(\.[0-9]{1,2})?$"))
                {
                    App.GlobalBudget.SetBudgetGoalByMonthYear(goal, App.GlobalViewData.CurrentlyDisplayedMonthYear);


                    Navigation.PushAsync(new MainBudgetSummaryPage());
                }
                else
                {
                    ErrorLabel.Text = "*Please enter valid amount";
                }


            }

        }


    }
}
