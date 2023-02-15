using System;
using System.Collections.Generic;
using System.Text;
using KataCalculator.Models;
using KataCalculator.Services;
using KataCalculator.Interfaces;


namespace KataCalculator
{
    public class Calculate
    {

        Product product = new Product
        {
            Name = "Book1",
            Price = 20.25,
            UPC = 1
        };

        Tax tax = new Tax
        {
            TaxPercentage = 21.0
        };

        Discount discount = new Discount
        {
            DiscountPercentage = 15.0,
            UpcDiscountPercentage = 7.0,
            DiscountPrecedence = "After",
            UpcDiscountPrecedence = "After"
        };

        Combining combining = new Combining
        {
            CombiningType = "Additive"
        };

        CAP cap = new CAP
        {
            CapValue = 20,
            CapType = "Percentage"
        };
       
        PrintMethod print = new PrintMethod();

        public Calculate(ITaxOperation taxOperation, IDiscountOperation discountOperation, IExpensesOperation expensesOperation, ICapOperation capOperation)
        {
            Expenses[] expenses = new Expenses[2];
            expenses[0] = new Expenses();
            expenses[0].ExpenseDescription = "Packaging";
            expenses[0].ExpenseType = "Percentage";
            expenses[0].ExpenseAmount = 0;
            expenses[1] = new Expenses();
            expenses[1].ExpenseDescription = "Transporting";
            expenses[1].ExpenseType = "Value";
            expenses[1].ExpenseAmount = 0;
            
            double _taxAmount;
            double _discountAmount;
            double _upcDiscountAmount;
            double _expensesAmount = 0;

            if (discount.UpcDiscountPrecedence == "Before" && discount.DiscountPrecedence == "Before")
            {
                _discountAmount = discountOperation.DiscountAmount(product.Price, discount.DiscountPercentage);
                if (combining.CombiningType == "Additive")
                {
                    _upcDiscountAmount = discountOperation.UpcDiscountAmount(product.UPC, product.Price, discount.UpcDiscountPercentage);
                }
                else
                {
                    _upcDiscountAmount = discountOperation.UpcDiscountAmount(product.UPC, product.Price - _discountAmount, discount.UpcDiscountPercentage);
                }
                _taxAmount = taxOperation.TaxAmount(product.Price - _discountAmount - _upcDiscountAmount, tax.TaxPercentage);
            }           
            else if(discount.UpcDiscountPrecedence == "Before" && discount.DiscountPrecedence == "After")
            {
                _upcDiscountAmount = discountOperation.UpcDiscountAmount(product.UPC, product.Price, discount.UpcDiscountPercentage);
                _taxAmount = taxOperation.TaxAmount(product.Price - _upcDiscountAmount, tax.TaxPercentage);
                _discountAmount = discountOperation.DiscountAmount(product.Price - _upcDiscountAmount, discount.DiscountPercentage);
            }
            else if (discount.UpcDiscountPrecedence == "After" && discount.DiscountPrecedence == "Before")
            {
                _discountAmount = discountOperation.DiscountAmount(product.Price, discount.DiscountPercentage);
                _taxAmount = taxOperation.TaxAmount(product.Price - _discountAmount, tax.TaxPercentage);
                _upcDiscountAmount = discountOperation.UpcDiscountAmount(product.UPC, product.Price - _discountAmount, discount.UpcDiscountPercentage);
            }
            else
            {
                _taxAmount = taxOperation.TaxAmount(product.Price, tax.TaxPercentage);
                _discountAmount = discountOperation.DiscountAmount(product.Price, discount.DiscountPercentage);
                if (combining.CombiningType == "Additive")
                {
                    _upcDiscountAmount = discountOperation.UpcDiscountAmount(product.UPC, product.Price, discount.UpcDiscountPercentage);
                }
                else
                {
                    _upcDiscountAmount = discountOperation.UpcDiscountAmount(product.UPC, product.Price - _discountAmount, discount.UpcDiscountPercentage);
                }
            }

            foreach(Expenses expense in expenses)
            {
                _expensesAmount = _expensesAmount + expensesOperation.ExpenseAmount(product.Price, expense.ExpenseAmount, expense.ExpenseType);
                expense.ExpensePrice = _expensesAmount;
            }
            
            double totalDiscount = _discountAmount + _upcDiscountAmount;
            double FinalDiscount = capOperation.capProcess(product.Price, cap.CapValue, totalDiscount, cap.CapType);
            double FinalPrice = product.Price + _taxAmount - FinalDiscount + _expensesAmount;



            ///////////////////////////////////////////////////////////// Print Report
            print.Print(product.Price,_taxAmount, FinalDiscount);
            foreach(Expenses expense in expenses)
            {
                print.PrintExpenses(expense);
            }
            print.PrintPrice(FinalPrice);
        }
        
    }
}
