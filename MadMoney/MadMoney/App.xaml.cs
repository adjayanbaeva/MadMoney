using MadMoney.Model;
using MadMoney.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MadMoney
{
    public partial class App : Application
    {
        // Global budget instance
        public static Budget GlobalBudget = new Budget();
        public static ViewData GlobalViewData = new ViewData();

        public App()
        {
            InitializeComponent();

            App.GlobalBudget.CreateNewMonth(2000M,
                                DateTime.Parse("2020-03-01"));

            MainPage = new NavigationPage(new welcome_page());
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
