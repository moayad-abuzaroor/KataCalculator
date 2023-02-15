using System;
using System.Collections.Generic;
using System.Text;
using KataCalculator.Interfaces;


namespace KataCalculator.Services
{
    public class TaxOperation : ITaxOperation
    {
        public double TaxAmount(double productPrice, double taxPercentage)
        {
            return productPrice * taxPercentage / 100;
        }

    }
}
