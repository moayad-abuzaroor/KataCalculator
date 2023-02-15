using KataCalculator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace KataCalculator.Services
{
    public class PrintMethod
    {
        public void Print(double productPrice, double taxAmount, double discountAmount)
        {
            if (discountAmount > 0)
            {
                Console.WriteLine($"Cost = {productPrice:c}, Tax = {taxAmount:c}, Discount = {discountAmount:c}");
            }
            else
            {
                Console.WriteLine($"Cost = {productPrice:c}, Tax = {taxAmount:c}");
            }
        }
        public void PrintExpenses(Expenses expenses)
        {
            if (expenses.ExpensePrice > 0)
            {
                Console.Write($"{expenses.ExpenseDescription:c} = {expenses.ExpensePrice:c} ");
            }
        }
        public void PrintPrice(double price)
        {
            Console.WriteLine($"\nTotal Price = {price:c}");
        }
    }
}
