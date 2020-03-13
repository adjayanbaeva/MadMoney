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
        public EditExpense()
        {
            InitializeComponent();
        }

        private void OnCancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OnSaveButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}