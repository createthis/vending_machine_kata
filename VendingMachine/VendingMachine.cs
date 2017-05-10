using System;
using System.Collections.Generic;

namespace VendingMachine {
    public class VendingMachine {
        private int cents;
        private List<Coin> returnedCoins;

        public VendingMachine() {
            cents = 0;
            returnedCoins = new List<Coin>();
        }

        public string Display() {
            if (cents == 0) {
                return "INSERT COIN";
            }
            return cents + " Cents";
        }

        private int CoinToCents(Coin coin) {
            switch (coin.milligrams) {
                case 2500:
                case 3110:
                    return 1;
                case 5000:
                    return 5;
                case 2268:
                    return 10;
                case 5670:
                    return 25;
                default:
                    return -1; 
            }
        }

        private void ReturnCoin(Coin coin) {
            returnedCoins.Add(coin);
        }

        public void InsertCoin(Coin coin) {
            int valueInCents = CoinToCents(coin);
            switch (valueInCents) {
                case -1:
                case 1:
                default:
                    ReturnCoin(coin);
                    break;
                case 5:
                case 10:
                case 25:
                    cents += valueInCents;
                    break;
            }
        }

        public int AmountInserted() {
            return cents;
        }
    }
}
