﻿using MadMoney.Model;
using MadMoney.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MadMoney
{
    public partial class App : Application
    {
        public static Budget GlobalBudget = new Budget();
        public static ViewData GlobalViewData = new ViewData();

        public App()
        {

            InitializeComponent();

            // TODO: Replace/delete this placeholder
            // Temporary month creation call until Ainur's AddGoal page is
            // ready to handle creating the initial month when the user sets
            // their initial goal
            App.GlobalBudget.CreateNewMonth(2000M,
                                DateTime.Parse("2020-03-01"));

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
