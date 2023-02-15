using System;
using System.Collections.Generic;
using System.Text;

namespace KataCalculator.Interfaces
{
    public interface ITaxOperation
    {
        double TaxAmount(double productPrice, double taxPercentage);
    }
}
