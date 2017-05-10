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

        public void AddProducts(List<Product> products) {
            foreach (Product product in products) {
                AddProduct(product);
            }
        }

        public void AddProduct(Product product) {
            List<Product> products = inventory[product.type];
            products.Add(product);
        }

        public int Count(ProductType productType) {
            return inventory[productType].Count;
        }
    }
}
