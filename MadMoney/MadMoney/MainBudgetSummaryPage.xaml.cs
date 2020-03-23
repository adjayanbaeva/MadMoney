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
        // Storage for the viewmodel object
        // Doing this instead of (MainBudgetSummaryPageViewModel)BindingContext
        // for readability since we will need a temp var for it eventually
        // anyway in OnAppearing
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

            App.GlobalBudget.AddExpense("Veggie Grill",
                            29.65M,
                            DateTime.Parse("2020-03-29"),
                            ExpenseCategory.Enum.Restaurants);

            App.GlobalBudget.AddExpense("Sanrio",
                            76.34M,
                            DateTime.Parse("2020-03-25"),
                            ExpenseCategory.Enum.Gifts);

            App.GlobalBudget.AddExpense("Rent",
                            1000M,
                            DateTime.Parse("2020-03-1"),
                            ExpenseCategory.Enum.Rent);

            App.GlobalBudget.AddExpense("Copay",
                            20M,
                            DateTime.Parse("2020-03-12"),
                            ExpenseCategory.Enum.Healthcare);


            // Save reference to the viewmodel instance
            // will remove it and re-add it OnAppearing
            ViewModel = new MainBudgetSummaryPageViewModel();



            InitializeComponent();

            // Demo code from when discussing with Ainur about possibilities
            // for not showing a 0 (or any default value) in the set goal field
            // the first time that the page is shown
            // BudgetGoalText.Text = String.Empty;
        }


        // Whenever this page is loaded, and also every time this page is
        // navigated to from another page (such as when a page above it on
        // the stack is popped)
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ResetBindingContext();
        }

        private void ResetBindingContext()
        {

            // Clear the BindingContext for the MainPage, then set it back to
            // the same ViewModel. Goal is to force the UI to re-query all
            // the properties that it is bound to on the viewmodel.

            BindingContext = null;
            BindingContext = ViewModel;

            // For some reason setting it to null is required, doesn't work
            // without that. I wonder why!
            // Perhaps the compiler optimizes away the re-assignment of ViewModel
            // to BindingContext, as though it could not possibly have an effect?
            // This viewmodel class type, while instantiable, has no state.
            // Wait. If the class type truly has no state, it should probably
            // be static after all. Whoops! I'll attribute that design oversight
            // to me being new to using properties on classes.

            // TODO: OBSERVE AND VERIFY
            // (Does that work for getting all of the UI elements to refresh?)
            // Yes, it does.
            // Probably still the best practice to navigate back to the main
            // (That is, the MainPage navigating to itself)

        }



        private void PreviousMonthButton_Pressed(object sender, EventArgs e)
        {
            ViewModel.LoadPreviousMonth();

            ResetBindingContext();

            // See also:
            // Budget.AddExpense() for another place that is currently
            // making a call to create a new month that doesn't yet exist
            // In this case, need more elaborate logic



            // Since migrating the data binding to a proper viewmodel, this
            // vestigal UI demo no longer functions.
            //MainBudgetSummaryPageViewModel.UpdateGoal( ViewModel.BudgetGoal_ForCurrentlyShownMonth_Decimal - 100);

        }

        private void NextMonthButton_Pressed(object sender, EventArgs e)
        {
            ViewModel.LoadNextMonth();


            ResetBindingContext();

            // See also:
            // Budget.AddExpense() for another place that is currently
            // making a call to create a new month that doesn't yet exist
            // In this case, need more elaborate logic


            // Since migrating the data binding to a proper viewmodel, this
            // vestigal UI demo no longer functions.
            //MainBudgetSummaryPageViewModel.UpdateGoal( ViewModel.BudgetGoal_ForCurrentlyShownMonth_Decimal + 100);


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

        }

        private void AddExpenseButton_Top_Pressed(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddExpense());
        }

        private void FilterExpensesButton_Pressed(object sender, EventArgs e)
        {

        }

        private void EditBudgetGoalButton_Pressed(object sender, EventArgs e)
        {
            Navigation.PushAsync(new welcome_page3());
        }



        private void ExpensesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tappedExpense = (Expense)e.Item;

            Navigation.PushAsync(new EditExpense(tappedExpense.Id));
        }

        private void ExpensesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //Not needed
        }
        private void AddExpenseButton_Top_Clicked(object sender, EventArgs e)
        {
            //Not needed
        }

        private void editGoal_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new welcome_page3());
        }
    }
}
