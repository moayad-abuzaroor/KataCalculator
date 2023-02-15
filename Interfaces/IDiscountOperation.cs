using System;
using System.Collections.Generic;
using System.Text;

namespace KataCalculator.Interfaces
{
    public interface IDiscountOperation
    {
        double DiscountAmount(double productPrice, double discountPercentage);
        double UpcDiscountAmount(int productUPC, double productPrice, double upcDiscountPercentage);
    }
}
