using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAPI.Models;

namespace WebAppAPI.TaxStrategies
{
    public class GreatBritainTax : ITax
    {
        public float CalculateNettoPrice(float bruttoPrice, CarItem car)
        {
            return bruttoPrice * 0.17f;
        }
    }
}
