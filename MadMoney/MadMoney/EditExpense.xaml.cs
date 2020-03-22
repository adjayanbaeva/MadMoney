using MadMoney.Model;
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
    public partial class EditExpense : ContentPage
    {
        private string idOfExpenseToEdit;

        public EditExpense(string expenseId)
        {
            idOfExpenseToEdit = expenseId;

            // Looking up the expense here to prove that looking it up works
            // View should pass the id to a method on the viewmodel,
            // then the viewmodel should look up the expense and implement
            // the properties that the view will bind to
            var copyOfExpenseToEdit =
                App.GlobalBudget.GetCopyOfExpenseById(idOfExpenseToEdit);

            InitializeComponent();
        }



        private void OnCancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OnSaveButton_Clicked(object sender, EventArgs e)
        {



        }

        private void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            // Migrate all of this method (except for the Navigation call)
            // to the corresponding method on the EditExpense viewmodel class
            bool expenseDeleted = App.GlobalBudget.DeleteExpenseById(idOfExpenseToEdit);
            if (false == expenseDeleted)
            {
                throw new ArgumentException(
                    $"Could not delete expense with Id {idOfExpenseToEdit}.");
            }

            Navigation.PopAsync();
        }
    }
}