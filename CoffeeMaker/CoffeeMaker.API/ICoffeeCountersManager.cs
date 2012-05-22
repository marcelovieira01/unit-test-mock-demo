using System;

namespace CoffeeMaker.API
{
    public interface ICoffeeCountersManager
    {
        CoffeeCounters GetTotalCoffeeCounters();

        void IncrementTotalCoffeeCounter();

        void ResetMaintenanceCounter();
    }
}
