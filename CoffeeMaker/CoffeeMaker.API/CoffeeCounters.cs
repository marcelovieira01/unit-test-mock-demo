using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeMaker.API
{
    public class CoffeeCounters
    {
        public CoffeeCounters(int totalCoffees, int totalCoffeesSinceLastMaintenance)
        {
            TotalCoffees = totalCoffees;
            TotalCoffeesSinceLastMaintenance = totalCoffeesSinceLastMaintenance;
        }

        public int TotalCoffees { get; private set; }

        public int TotalCoffeesSinceLastMaintenance { get; private set; }
    }
}
