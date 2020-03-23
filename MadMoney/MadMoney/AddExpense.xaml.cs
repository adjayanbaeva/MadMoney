using MadMoney.Model;
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
    public partial class AddExpense : ContentPage
    {
        public AddExpense()
        {
            BindingContext = new AddExpenseViewModel();
            InitializeComponent();
            //Binding context should be set at the initial constructor to ensure that the binding elements are bound once the Add Expense page is initialized
            //Otherwise, the binding won't happen until the event is triggered; it won't look for the binding objects until the save button is clicked

        }


        public decimal expAmount
        {
            get
            {
                return Convert.ToDecimal(ExpenseAmount.Text);
            }
        }

        

        async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            AddExpenseViewModel.Add(ExpenseDescription.Text, expAmount, AddExpDate.Date, (ExpenseCategory)SelectCategory.SelectedItem);
            await Navigation.PopAsync();   
        }

        private void OnCancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void ExpenseAmount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}