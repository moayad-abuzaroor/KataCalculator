using KataCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KataCalculator.Services
{
    public class CapOperation : ICapOperation
    {
        public double capProcess(double productPrice, double capValue, double discountValue, string capType)
        {
            if (capType == "Percentage")
            {
                capValue = productPrice * capValue / 100;
            }

            if (discountValue > capValue)
            {
                return capValue;
            }
            else
            {
                return discountValue;
            }
        }
    }
}
