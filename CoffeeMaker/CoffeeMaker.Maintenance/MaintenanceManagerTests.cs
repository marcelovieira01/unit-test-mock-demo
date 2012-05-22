#if UNIT_TESTS
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoffeeMaker.Maintenance
{
    [TestClass]
    public class MaintenanceManagerTests
    {
        private MaintenanceManager GetManager()
        {
            return new MaintenanceManager();
        }

        [TestMethod]
        public void CheckMaintenanceTest()
        {
            var manager = GetManager();

            Assert.AreEqual(MaintenanceState.OK, manager.CheckForMaintenance());
        }
    }
}
#endif