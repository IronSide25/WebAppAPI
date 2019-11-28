using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAPI.Models;

namespace WebAppAPI.TaxStrategies
{
    interface ITax
    {
        float CalculateNettoPrice(float bruttoPrice, CarItem car);
    }
}
