using System;
using System.Collections.Generic;
using System.Text;
using MadMoney.Utility;

namespace MadMoney.Model
{
    // Not static or singleton as it may make sense in the (hypothetical) future
    // to have more than one Budget (that is, set of BudgetMonths)
    public class Budget
    {
        private List<BudgetMonth> budgetMonths;
        public Budget()
        {
            budgetMonths = new List<BudgetMonth>();
        }

        // TODO:
        //BudgetMonth class type is best as an implementation detail of the Model
        public IEnumerable<BudgetMonth> BudgetMonths
        { get { return budgetMonths; } }
        // may need to provide additional ways to access/modify BudgetMonths collection

        public void CreateNewMonth(decimal goal, DateTime monthYear)
        {
            // If it is a duplicate month, throw
            if (budgetMonths.Exists(month =>
                DateTimeUtility.IsSameMonthYear(month.MonthYear, monthYear)))
            {
                throw new ArgumentException($"Budget already exists for {monthYear.ToString()}. Cannot add a duplicate budget month.");
            }


            // Idea: Add the new month to the beginning of the list?
            // it is probably the month that is most likely to be accessed
            // We'd need to switch data structure for that to be a good idea:
            // https://stackoverflow.com/questions/705969/adding-object-to-the-beginning-of-generic-listt


            budgetMonths.Add(new BudgetMonth(goal, monthYear));
            // Ideally Budget would not expose the BudgetMonth type at all
            // BudgetMonth is a class type that is internal to the implementation
            // of the model, but for now it is exposed
        }


        public BudgetMonth GetBudgetMonthByMonthYear(DateTime monthYear)
        {
            return budgetMonths.Find(month =>
                    DateTimeUtility.IsSameMonthYear(month.MonthYear, monthYear));
        }

        public decimal GetBudgetGoalByMonthYear(DateTime monthYear)
        {
            return budgetMonths.Find(month =>
                DateTimeUtility.IsSameMonthYear(month.MonthYear, monthYear)).BudgetGoal;
        }

        public void AddExpense(string expDescrip,
                               decimal expAmt,
                               DateTime expDate,
                               ExpenseCategory expCat)
        {

            // Step through the list of months
            // Find the month for which to add the expense
            var budgetMonthOfExpense = budgetMonths.Find(month =>
                DateTimeUtility.IsSameMonthYear(month.MonthYear, expDate));


            // If the month is not found, create the new month
            if (budgetMonthOfExpense == null)
            {
                // TODO: LOOK UP WHAT THE GOAL SHOULD BE FOR A NEW MONTH THAT IS CREATED FROM ADD EXPENSE
                budgetMonths.Add(new BudgetMonth(
                        999999M, DateTimeUtility.TruncateToMonthYear(expDate)));

                budgetMonthOfExpense = budgetMonths.Find(month =>
                    DateTimeUtility.IsSameMonthYear(month.MonthYear, expDate));
            }


            budgetMonthOfExpense.AddExpense(new Expense(expDescrip, expAmt, expDate, expCat));

        }

        // The design doesn't provide for deleting a budget month
        // public void DeleteBudget(DateTime month) { }


        // ask budget, here, give me all of the expenses for this budget month

        // ask the model, hey, give me the budget for this month
        // hey, give me the expenses for this month
        // things that are calculated (instead of stored) should be handled in
        // the viewmodel rather than in the model
        // viewmodels will likely implement thier own  (or possibly utility classes
        // shared between viewmodels) 
    }
}
