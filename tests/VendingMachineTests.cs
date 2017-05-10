using System;
using NUnit.Framework;
using VendingMachine;

namespace VendingMachine_Tests {
    [TestFixture]
    public class VendingMachineTests {
        private VendingMachine.VendingMachine vm;

        [SetUp]
        public void SetUp() {
            vm = new VendingMachine.VendingMachine();
        }

        #region Display
        [Test]
        public void DisplaysInsertCoinWhenNoCoinsInserted() {
            Assert.AreEqual("INSERT COIN", vm.Display());
        }
        #endregion

        #region InsertCoin
        [Test]
        public void AddingValidCoinChangesAmount() {
            vm.InsertCoin(Coin.dime);
            Assert.AreEqual(10, vm.AmountInserted());
        }
        #endregion
    }
}
