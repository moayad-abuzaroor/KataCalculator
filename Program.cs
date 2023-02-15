using System;
using KataCalculator.Services;

namespace KataCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaxOperation taxOperation = new TaxOperation();
            DiscountOperation discountOperation = new DiscountOperation();
            ExpensesOperation expensesOperation = new ExpensesOperation();
            CapOperation capOperation = new CapOperation();
            Calculate calculate = new Calculate(taxOperation, discountOperation, expensesOperation, capOperation);
            Console.Write("hi");
        }
        
    }
}
