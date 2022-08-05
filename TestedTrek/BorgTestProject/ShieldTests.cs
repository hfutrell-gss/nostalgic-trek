using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImplementationProject;

namespace BorgTestProject
{
    [TestClass]
    public class ShieldTests
    {
        [TestMethod]
        public void ShieldDownByDefault()
        {
            var shield = new Shield();

            Assert.IsFalse(shield.IsRaised());
        }

        [TestMethod]
        public void ShieldCanBeRaise()
        {
            var shield = new Shield();

            shield.Raise();

            Assert.IsTrue(shield.IsRaised());
        }

        [TestMethod]
        public void ShieldCanBeLowered()
        {
            var shield = new Shield();

            shield.Raise();

            shield.Lower();

            Assert.IsFalse(shield.IsRaised());
        }

        [TestMethod]
        public void ShieldHasUnitsByDefault()
        {
            var shield = new Shield();

            Assert.AreEqual(8000, shield.Units);
        }

        [TestMethod]
        public void ShieldAcceptsPower()
        {
            var shield = new Shield();

            shield.AcceptPower(100);

            Assert.AreEqual(8100, shield.Units);
        }

        [TestMethod]
        public void ShieldAcceptsDamage()
        {
            var shield = new Shield();

            shield.AcceptDamage(100);

            Assert.AreEqual(7900, shield.Units);
        }

        [TestMethod]
        public void  WhenShieldReceivesDamageBeyondThreshold_ThenShieldDrops()
        {
            var shield = new Shield();

            shield.Raise();

            shield.AcceptDamage(8001);

            Assert.IsFalse(shield.IsRaised());
        }

        [TestMethod]
        public void WhenShieldDoesNotReceiveDamageBeyondThreshold_ThenItDoesNotDrop()
        {
            var shield = new Shield();

            shield.Raise();

            shield.AcceptDamage(1);

            Assert.IsTrue(shield.IsRaised());
        }

        [TestMethod]
        public void OverPoweringShieldsDoesNotFillPastDischarge()
        {
            var shield = new Shield();

            shield.AcceptPower(10000);

            Assert.AreEqual(10000, shield.Units);
        }

        [TestMethod]
        public void DoesNotReturnOverloadValue_WhenNotOverloaded()
        {
            var shield = new Shield();

            Assert.AreEqual(0, shield.AcceptPower(1000));
        }

        [TestMethod]
        public void ReturnsOverloadAmount_WhenOverloaded()
        {
            var shield = new Shield();

            Assert.AreEqual(1000, shield.AcceptPower(3000));
        }
    }
}
