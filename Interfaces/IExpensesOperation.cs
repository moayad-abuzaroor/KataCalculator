using System;
using System.Collections.Generic;
using System.Text;

namespace KataCalculator.Interfaces
{
    public interface IExpensesOperation
    {
        double ExpenseAmount(double productPrice, double expenseAmount, string expenseType);
    }
}
