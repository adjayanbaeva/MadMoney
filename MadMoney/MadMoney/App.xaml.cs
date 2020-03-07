using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MadMoney
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainBudgetSummaryPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
