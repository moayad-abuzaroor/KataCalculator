using KataCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KataCalculator.Services
{
    public class ExpensesOperation : IExpensesOperation
    {
        public double ExpenseAmount(double productPrice, double expenseAmount, string expenseType)
        {
            if (expenseType == "Percentage")
            {
                return productPrice * expenseAmount / 100;
            }
            else
            {
                return expenseAmount;
            }
        }
    }
}
