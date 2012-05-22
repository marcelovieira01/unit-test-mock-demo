using System;

namespace CoffeeMaker.BrandService
{
    public interface ICoffeeMakerMaintenanceService
    {
        Guid NotifyCoffeeMakerNeedsMaintenance(int totalCoffees, int totalCoffeesSinceLastMaintenance);
    }
}
