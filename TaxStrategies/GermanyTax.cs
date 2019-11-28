using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAPI.Models;

namespace WebAppAPI.TaxStrategies
{
    public class GermanyTax : ITax
    {
        public float CalculateNettoPrice(float bruttoPrice, CarItem car)
        {
            if (car.ProductionYear > 2010)
                return bruttoPrice * 0.12f;
            else
                return bruttoPrice * 0.18f;
        }
    }
}
