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

        [TestMethod]
        public void TransferringEnergyToShieldsDepletesShields()
        {
            var ship = new Ship();

            ship.Shield = new Shield();

            ship.TransferEnergyToShield(100);

            Assert.AreEqual(9900, ship.Reserves);
        }

        [TestMethod]
        public void CannotTransferMoreEnergyThanAvailable()
        {
            var ship = new Ship();
            ship.Shield = new Shield();

            Assert.ThrowsException<Exception>(() => ship.TransferEnergyToShield(11000));
        }

        [TestMethod]
        public void AllOperationalTrue()
        {
            var ship = new Ship();

            Assert.IsTrue(ship.IsFullyOperational);
        }

        [TestMethod]
        public void AllOperationalFalse()
        {
            var ship = new Ship();

            ship.TakeDamage(100000000);

            Assert.IsFalse(ship.IsFullyOperational);
        }
        public void CanRaiseShield()
        {
            var ship = new Ship();

            ship.RaiseShield();
            
            Assert.IsTrue(ship.Shield.IsRaised());
        }
    }

}
