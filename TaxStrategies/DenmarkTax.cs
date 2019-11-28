using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAPI.Models;

namespace WebAppAPI.TaxStrategies
{
    public class DenmarkTax : ITax
    {
        public float CalculateNettoPrice(float bruttoPrice, CarItem car)
        {
            if (car.EnginePower > 100)
                return bruttoPrice * 0.21f;
            else
                return bruttoPrice * 0.15f;
        }
    }
}
