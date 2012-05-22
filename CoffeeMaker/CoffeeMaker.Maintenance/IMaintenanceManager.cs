using System;

namespace CoffeeMaker.Maintenance
{
    public interface IMaintenanceManager
    {
        MaintenanceState CheckForMaintenance();
    }
}
