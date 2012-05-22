#if UNIT_TESTS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoffeeMaker.API;
using CoffeeMaker.BrandService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace CoffeeMaker.Maintenance
{
    [TestClass]
    public class MaintenanceManagerMockedTests
    {
        Rhino.Mocks.MockRepository mocks;

        private ICoffeeCountersManager countersManagerMock;
        private ICoffeeMakerMaintenanceService serviceMock;

        public MaintenanceManagerMockedTests()
        {
            mocks = new MockRepository();

            countersManagerMock = mocks.StrictMock<ICoffeeCountersManager>();
            serviceMock = mocks.StrictMock<ICoffeeMakerMaintenanceService>();
        }

        private MaintenanceManager GetManager()
        {
            return new MaintenanceManager(countersManagerMock, serviceMock);
        }

        [TestMethod]
        public void CheckMaintenanceNoNeedTest()
        {
            var manager = GetManager();

            Expect.Call(countersManagerMock.GetTotalCoffeeCounters())
                .Return(new CoffeeCounters(1, 1));

            mocks.ReplayAll();

            Assert.AreEqual(MaintenanceState.OK, manager.CheckForMaintenance());

            mocks.VerifyAll();
        }

        [TestMethod]
        public void CheckMaintenanceRequiredTest()
        {
            var manager = GetManager();

            Expect.Call(countersManagerMock.GetTotalCoffeeCounters())
                .Return(new CoffeeCounters(10, 1));

            Expect.Call(serviceMock.NotifyCoffeeMakerNeedsMaintenance(10, 1))
                .Return(Guid.NewGuid());

            mocks.ReplayAll();

            Assert.AreEqual(MaintenanceState.NeedsMaintenance, manager.CheckForMaintenance());

            mocks.VerifyAll();
        }

        [TestMethod]
        public void CheckMaintenanceExpiredTest()
        {
            var manager = GetManager();

            Expect.Call(countersManagerMock.GetTotalCoffeeCounters())
                .Return(new CoffeeCounters(10, 1));

            Expect.Call(serviceMock.NotifyCoffeeMakerNeedsMaintenance(10, 1))
                .Throw(new ExpiredMaintenanceContractException());

            mocks.ReplayAll();

            Assert.AreEqual(MaintenanceState.ContractExpired, manager.CheckForMaintenance());

            mocks.VerifyAll();
        }
    }
}
#endif