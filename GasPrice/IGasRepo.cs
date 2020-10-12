using GasPrice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasPrice
{
    public interface IGasRepo
    {
        public State PricesForState(string state);
    }
}
