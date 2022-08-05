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
            Assert.IsNotNull(ship.GetRandomSystem(ship.GetRandomValue));
        }

        [TestMethod]
        public void TransfersEnergyToShields()
        {
            var shield = new Shield();
            var ship = new Ship(shield);


            ship.TransferEnergyToShield(100);

            Assert.AreEqual(8100, shield.Units);
        }

        [TestMethod]
        public void TransferringEnergyToShieldsDepletesShields()
        {
            var shield = new Shield();

            var ship = new Ship(shield);

            ship.TransferEnergyToShield(100);

            Assert.AreEqual(9900, ship.Reserves);
        }

        [TestMethod]
        public void CannotTransferMoreEnergyThanAvailable()
        {
            var shield = new Shield();

            var ship = new Ship(shield);

            Assert.ThrowsException<Exception>(() => ship.TransferEnergyToShield(11000));
        }

        [TestMethod]
        public void IsFullyOperational_WhenNoDamageIsTaken()
        {
            var ship = new Ship(new Shield());

            Assert.IsTrue(ship.IsFullyOperational);
        }

        [TestMethod]
        public void IsNotFullyOperational_WhenSufficientDamageIsTaken()
        {
            var ship = new Ship(new Shield());

            ship.TakeDamage(100000000);

            Assert.IsFalse(ship.IsFullyOperational);
        }

        [TestMethod]
        public void CanRaiseShield()
        {
            var shield = new Shield();
            var ship = new Ship(shield);

            ship.RaiseShield();
            
            Assert.IsTrue(shield.IsRaised());
        }

        [TestMethod]
        public void GivenTheShieldIsUp_WhenTakesDamage_ThenShieldAbsorbsDamage()
        {
            var ship = new Ship(new Shield());
            ship.RaiseShield();
            ship.TakeDamage(8000);

            Assert.IsTrue(ship.IsFullyOperational);
        }

        [TestMethod]
        public void GivenTheShieldIsDown_WhenTakesDamage_ThenShipAbsorbsDamage()
        {
            var shield = new Shield();
            shield.Lower();
            
            var ship = new Ship(shield);
            
            ship.TakeDamage(1);

            Assert.IsFalse(ship.IsFullyOperational);
        }

        [TestMethod]
        public void GivenSystemTakesDamage()
        {
            var ship = new Ship();

            ship.TakeDamage(1, (i) => 1);

            Assert.IsFalse(ship.GetRandomSystem((i) => 1).IsOperational);
            
        }
    }

}
