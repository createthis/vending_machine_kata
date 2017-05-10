using System;
using NUnit.Framework;

namespace VendingMachine_Tests {
    [TestFixture]
    public class VendingMachineTests {
        private VendingMachine vm;

        [SetUp]
        public void SetUp() {
            vm = new VendingMachine();
        }

        #region Display
        [Test]
        public void displaysInsertCoinWhenNoCoinsInserted() {
            Assert.AreEqual("INSERT COIN", vm.Display());
        }
        #endregion

        #region InsertCoin
        [Test]
        public void addingValidCoinChangesAmount() {
            vm.InsertCoin(Coin.dime);
            Assert.AreEqual(10, vm.AmountInserted());
        }
        #endregion
    }
}
