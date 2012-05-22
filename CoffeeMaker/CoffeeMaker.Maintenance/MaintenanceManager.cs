using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoffeeMaker.API;
using CoffeeMaker.BrandService;

namespace CoffeeMaker.Maintenance
{
    public class MaintenanceManager : IMaintenanceManager
    {
        private ICoffeeCountersManager coffeeMakerCountersManager;
        private ICoffeeMakerMaintenanceService coffeeMakerMaintenanceService;

        public MaintenanceManager()
        {
            coffeeMakerCountersManager = new CoffeeCountersManager();
            coffeeMakerMaintenanceService = new CoffeeMakerMaintenanceService();
        }

        // FOR UNIT TESTS ONLY
        internal MaintenanceManager(ICoffeeCountersManager coffeeMakerCountersManager,
            ICoffeeMakerMaintenanceService coffeeMakerMaintenanceService)
        {
            this.coffeeMakerCountersManager = coffeeMakerCountersManager;
            this.coffeeMakerMaintenanceService = coffeeMakerMaintenanceService;
        }

        public MaintenanceState CheckForMaintenance()
        {
            var counters = coffeeMakerCountersManager.GetTotalCoffeeCounters();

            if ((counters.TotalCoffees > 0 && counters.TotalCoffees % 10 == 0)
                || counters.TotalCoffeesSinceLastMaintenance > 20)
            {
                try
                {
                    var serviceToken = coffeeMakerMaintenanceService.NotifyCoffeeMakerNeedsMaintenance(
                        counters.TotalCoffees,
                        counters.TotalCoffeesSinceLastMaintenance);

                    Console.WriteLine(
                        "Your coffee maker needs maintenance. A request was placed with service id = {0}",
                        serviceToken);

                    return MaintenanceState.NeedsMaintenance;
                }
                catch (ExpiredMaintenanceContractException e)
                {
                    return MaintenanceState.ContractExpired;
                }
            }

            return MaintenanceState.OK;
        }
    }
}
