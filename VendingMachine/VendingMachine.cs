using System;
using System.Collections.Generic;

namespace VendingMachine {
    public class VendingMachine {
        private int cents;
        private List<Coin> returnedCoins;
        private Inventory inventory;
        private Dictionary<ProductType, int> productPrices;
        private List<Product> productsToDispense;
        private bool thankYou;

        public VendingMachine() {
            cents = 0;
            returnedCoins = new List<Coin>();
            inventory = new Inventory();
            productPrices = new Dictionary<ProductType, int>();
            productsToDispense = new List<Product>();
            thankYou = false;
        }

        public void SetPrices(List<ProductPrice> productPrices) {
            foreach (ProductPrice productPrice in productPrices) {
                this.productPrices.Add(productPrice.type, productPrice.cents);
            }
        }

        public void Stock(List<Product> products) {
            inventory.Add(products);
        }

        private bool SufficientFunds(ProductType productType) {
            return productPrices[productType] >= cents;
        }

        private bool HasStockRemaining(ProductType productType) {
            return inventory.Count(productType) > 0;
        }

        private bool Selectable(ProductType productType) {
            return SufficientFunds(productType) && HasStockRemaining(productType);
        }

        private void DispenseProduct(ProductType productType) {
            productsToDispense.Add(inventory.Shift(productType));
            cents -= productPrices[productType];
            thankYou = true;
        }

        public void SelectProduct(ProductType productType) {
            if (Selectable(productType)) {
                DispenseProduct(productType);
            }
        }

        public List<Product> DispenseProducts() {
            List<Product> products = new List<Product>();
            foreach (Product product in productsToDispense) {
                products.Add(product);
            }
            productsToDispense.Clear();
            return products;
        }

        public string Display() {
            if (thankYou) {
                thankYou = false;
                return "THANK YOU";
            }
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

        public List<Coin> CoinReturn() {
            return returnedCoins;
        }
    }
}
