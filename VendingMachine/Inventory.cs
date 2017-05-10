using System;
using System.Collections.Generic;

namespace VendingMachine {
    public class Inventory {
        private Dictionary<ProductType, List<Product>> inventory;

        public Inventory() {
            inventory = new Dictionary<ProductType, List<Product>>();
            foreach (ProductType productType in Enum.GetValues(typeof(ProductType))) {
                inventory.Add(productType, new List<Product>());
            }
        }

        public void Add(List<Product> products) {
            foreach (Product product in products) {
                Add(product);
            }
        }

        public void Add(Product product) {
            List<Product> products = inventory[product.type];
            products.Add(product);
        }

        public Product Shift(ProductType productType) {
            List<Product> products = inventory[productType];
            Product product = products[0];
            products.Remove(product);
            return product;
        }

        public int Count(ProductType productType) {
            return inventory[productType].Count;
        }
    }
}
