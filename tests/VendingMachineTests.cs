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

        [Test]
        public void DisplaysTotalAmountWhenCoinsInserted() {
            vm.InsertCoin(Coin.dime);
            Assert.AreEqual("10 Cents", vm.Display());
            vm.InsertCoin(Coin.dime);
            Assert.AreEqual("20 Cents", vm.Display());
            vm.InsertCoin(Coin.nickel);
            Assert.AreEqual("25 Cents", vm.Display());
            vm.InsertCoin(Coin.quarter);
            Assert.AreEqual("50 Cents", vm.Display());
            vm.InsertCoin(Coin.penny);
            Assert.AreEqual("50 Cents", vm.Display());
        }
        #endregion

        #region InsertCoin
        [Test]
        public void AddingValidCoinChangesAmount() {
            vm.InsertCoin(Coin.dime);
            Assert.AreEqual(10, vm.AmountInserted());
            vm.InsertCoin(Coin.dime);
            Assert.AreEqual(20, vm.AmountInserted());
            vm.InsertCoin(Coin.nickel);
            Assert.AreEqual(25, vm.AmountInserted());
            vm.InsertCoin(Coin.quarter);
            Assert.AreEqual(50, vm.AmountInserted());
            vm.InsertCoin(Coin.penny);
            Assert.AreEqual(50, vm.AmountInserted());
        }
        #endregion

        #region InsertCoin
        [Test]
        public void RejectedCoinsArePlacedInTheCoinReturn() {
            Assert.AreEqual(0, vm.CoinReturn().Count);
            vm.InsertCoin(Coin.dime);
            Assert.AreEqual(0, vm.CoinReturn().Count);
            vm.InsertCoin(Coin.penny);
            Assert.AreEqual(1, vm.CoinReturn().Count);
            Assert.AreEqual(Coin.penny.milligrams, vm.CoinReturn()[0].milligrams);
            Assert.AreEqual(Coin.penny.millimeters, vm.CoinReturn()[0].millimeters);
            vm.InsertCoin(new Coin(10, 100));
            Assert.AreEqual(2, vm.CoinReturn().Count);
            Assert.AreEqual(Coin.penny.milligrams, vm.CoinReturn()[0].milligrams);
            Assert.AreEqual(Coin.penny.millimeters, vm.CoinReturn()[0].millimeters);
            Assert.AreEqual(10, vm.CoinReturn()[1].milligrams);
            Assert.AreEqual(100, vm.CoinReturn()[1].millimeters);
        }
        #endregion
    }
}
