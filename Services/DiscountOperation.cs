using KataCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KataCalculator.Services
{
    public class DiscountOperation : IDiscountOperation
    {
        public double DiscountAmount(double productPrice, double discountPercentage)
        {
            return productPrice * discountPercentage / 100;
        }

        public double UpcDiscountAmount(int productUPC, double productPrice, double upcDiscountPercentage)
        {
            if (productUPC == 1)
            {
                return productPrice * upcDiscountPercentage / 100;
            }
            else
            {
                return 0;
            }
        }
    }
}
