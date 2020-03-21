using MadMoney.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MadMoney
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class welcome_page2 : ContentPage
    {
        //string filename = Path.Combine(Environment.GetFolderPath
           // (Environment.SpecialFolder.LocalApplicationData), "goal.txt");
       
        public welcome_page2()
        {

            InitializeComponent();
         /*   if(File.Exists(filename))
            {
                currentGoal.Text=File.ReadAllText(filename);
            } */
           
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            App.GlobalBudget.AddGoal(????, currentGoal.Text);

            // File.WriteAllText(filename, currentGoal.Text);

            Navigation.PushAsync(new MainBudgetSummaryPage());

        }

       
    }
}