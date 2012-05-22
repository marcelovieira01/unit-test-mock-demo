using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeMaker.BrandService
{
    public class ExpiredMaintenanceContractException : Exception
    {
        public ExpiredMaintenanceContractException()
            : base("The maintenance contract has expired")
        {
        }
    }
}
