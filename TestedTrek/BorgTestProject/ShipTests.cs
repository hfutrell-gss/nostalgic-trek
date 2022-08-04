using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImplementationProject;
using System;

namespace BorgTestProject
{
    [TestClass]
    public class ShipTests
    {
        //20000


        [TestMethod]
        public void InitialRandomValue()
        {
            var ship = new Ship
            {
                SubsystemCount = 1
            };

            Assert.AreEqual(0, ship.GetRandomValue(ship.SubsystemCount));
        }


        [TestMethod]
        public void GetRandomSystem()
        {
            var ship = new Ship
            {
                SubsystemCount = 1
            };
            Assert.IsNotNull(ship.GetRandomSystem());
        }

        [TestMethod]
        public void TransfersEnergyToShields()
        {
            var ship = new Ship();

            ship.Shield = new Shield();

            ship.TransferEnergyToShield(100);

            Assert.AreEqual(8100, ship.Shield.Units);
        }

    }

}
