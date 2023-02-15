using System;
using System.Collections.Generic;
using System.Text;

namespace KataCalculator.Interfaces
{
    public interface ICapOperation
    {
        double capProcess(double productPrice, double capValue, double discountValue, string capType);
    }
}
