using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeMaker.API
{
    public class CoffeeCountersManager : ICoffeeCountersManager
    {
        private static int totalCoffeesCounter = 0;
        private static int totalCoffeesSinceLastMaintenance = 0;

        public CoffeeCounters GetTotalCoffeeCounters()
        {
            return new CoffeeCounters(totalCoffeesCounter, totalCoffeesSinceLastMaintenance);
        }

        public void IncrementTotalCoffeeCounter()
        {
            totalCoffeesCounter++;
            totalCoffeesSinceLastMaintenance++;
        }

        public void ResetMaintenanceCounter()
        {
            totalCoffeesSinceLastMaintenance = 0;
        }
    }
}
