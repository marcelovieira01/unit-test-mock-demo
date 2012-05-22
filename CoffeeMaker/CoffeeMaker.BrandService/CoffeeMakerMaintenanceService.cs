using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeMaker.BrandService
{
    public class CoffeeMakerMaintenanceService : ICoffeeMakerMaintenanceService
    {
        public Guid NotifyCoffeeMakerNeedsMaintenance(int totalCoffees, int totalCoffeesSinceLastMaintenance)
        {
            var serviceToken = Guid.NewGuid();

            Console.WriteLine("Coffee maker needs assistance. Service process id = {0}", serviceToken.ToString());

            return serviceToken;
        }
    }
}
