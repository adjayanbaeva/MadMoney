using MadMoney.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MadMoney.ViewModel
{
    class EditExpenseViewModel
    {
        public string ExpDescrip { get; set; }
        public int ExpAmt { get; set; }
        public DateTime ExpDate { get; set; }
        public ExpenseCategory ExpCate { get; set; }


    }
}
