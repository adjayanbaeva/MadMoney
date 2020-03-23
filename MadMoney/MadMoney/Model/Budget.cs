using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadMoney.Utility;

namespace MadMoney.Model
{
    // Budget is not static or singleton as it may make sense in the
    // (hypothetical) future to have more than one Budget
    // that is, multiple Budget instances
    // for example, a different Budget for each user, etc.
    public class Budget
    {
        private List<BudgetMonth> budgetMonths;
        public Budget()
        {
            budgetMonths = new List<BudgetMonth>();
        }


        public void CreateNewMonth(decimal goal, DateTime monthYear)
        {
            // If it is a duplicate month, throw
            if (budgetMonths.Exists(month =>
                DateTimeUtility.IsSameMonthYear(month.MonthYear, monthYear)))
            {
                throw new ArgumentException($"Budget already exists for {monthYear.ToString()}. Cannot add a duplicate budget month.");
            }


            // Idea:
            // Add the new month to the beginning of the list?
            // it is probably the month that is most likely to be accessed
            // Turns out that  we would need to switch data structures for
            // that to be a good idea:
            // https://stackoverflow.com/questions/705969/adding-object-to-the-beginning-of-generic-listt


            budgetMonths.Add(new BudgetMonth(goal, monthYear));

        }

        private BudgetMonth GetBudgetMonthByMonthYear(DateTime monthYear)
        {
            return budgetMonths.Find(month =>
                    DateTimeUtility.IsSameMonthYear(month.MonthYear, monthYear));
        }


        public IEnumerable<Expense> GetExpensesByMonthYear(DateTime monthYear)
        {
            return GetBudgetMonthByMonthYear(monthYear).Expenses;
        }

        public decimal GetBudgetGoalByMonthYear(DateTime monthYear)
        {
            return budgetMonths.Find(month =>
                DateTimeUtility.IsSameMonthYear(month.MonthYear, monthYear)).BudgetGoal;
        }

        public bool BudgetMonthExistByMonthYear(DateTime monthYear)
        {
            return budgetMonths.Exists(month =>
                DateTimeUtility.IsSameMonthYear(month.MonthYear, monthYear));
        }

        public void SetBudgetGoalByMonthYear(decimal goal, DateTime monthYear)
        {
            // If the month specified by the caller doesn't exist, throw
            if (false == BudgetMonthExistByMonthYear(monthYear))
            {
                throw new ArgumentException($"No budget exists for {monthYear.ToString()}. Cannot set goal.");
            }

            budgetMonths.Find(month =>
                DateTimeUtility.IsSameMonthYear(month.MonthYear, monthYear)).BudgetGoal = goal;
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
                // TODO: LOOK UP WHAT THE GOAL SHOULD BE FOR A NEW MONTH THAT
                // IS CREATED FROM ADD EXPENSE
                // REVIEW THE DESIGN TO SEE WHERE WE SHOULD GET THIS FROM.
                CreateNewMonth(999999M, expDate);

                budgetMonthOfExpense = budgetMonths.Find(month =>
                    DateTimeUtility.IsSameMonthYear(month.MonthYear, expDate));

                // TODO:
                // IT'S THE VIEW'S JOB TO SWITCH THE DISPLAYED MONTH IN THE UI
                // NOT APPROPRIATE FOR THE MODEL TO CHANGE WHICH MONTH
                // THE VIEW IS DISPLAYING
            }


            budgetMonthOfExpense.AddExpense(new Expense(expDescrip, expAmt, expDate, expCat));

        }

        // Returns null if no expense could be found with the specified Id
        public Expense GetCopyOfExpenseById(string id)
        {
            var foundExpense = FindExpenseById(id);

            // If we found a match
            if (null != foundExpense)
            {
                // Return a copy of it
                // Note that this copies the Id
                // (a new Id is NOT generated)
                return new Expense(foundExpense.Id,
                                   foundExpense.Description,
                                   foundExpense.Amount,
                                   foundExpense.Date,
                                   foundExpense.Category);
            }
            else
            {
                return null;
            }
        }

        private Expense FindExpenseById(string Id)
        {
            Expense foundExpense = null;

            foreach (var month in budgetMonths)
            {
                foundExpense = month.Expenses.ToList().Find(expense => expense.Id == Id);
                if (null != foundExpense)
                {
                    // If we find an expense that matches the parameter Id
                    // stop looking through the budget months
                    break;
                }
            }

            return (null != foundExpense) ? foundExpense : null;
        }



        // Returns true if expense was found and deleted
        // Returns false if expense was not found (no expense was deleted)
        public bool DeleteExpenseById(string id)
        {
            bool deletedExpense = false;

            foreach (var month in budgetMonths)
            {
                deletedExpense = month.DeleteExpense(id);

                if (true == deletedExpense)
                {
                    break;
                }
            }

            return deletedExpense ? true : false;
        }

        public bool SetDescriptionForExpenseById(string id, string expDescrip)
        {
            var expense = FindExpenseById(id);

            if (null != expense)
            {
                expense.Description = expDescrip;
                return true;
            }

            return false;
        }

        public bool SetAmountForExpenseById(string id, decimal expAmt)
        {
            var expense = FindExpenseById(id);

            if (null != expense)
            {
                expense.Amount = expAmt;
                return true;
            }

            return false;
        }

        public bool SetDateForExpenseById(string id, DateTime expDate)
        {
            var expense = FindExpenseById(id);

            if (null != expense)
            {
                expense.Date = expDate;
                return true;
            }

            return false;
        }

        public bool SetCategoryForExpenseById(string id, ExpenseCategory expCat)
        {
            var expense = FindExpenseById(id);

            if (null != expense)
            {
                expense.Category = expCat;
                return true;
            }

            return false;

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
