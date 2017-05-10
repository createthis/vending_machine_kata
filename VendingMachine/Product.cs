using System;

namespace VendingMachine {
    public enum ProductType {
        cola, chips, candy
    }

    public struct ProductPrice {
        public int cents;
        public ProductType type;

        public ProductPrice(ProductType type, int cents) {
            this.type = type;
            this.cents = cents;
        }
    }

    public struct Product {
        public ProductType type;

        public Product(ProductType type) {
            this.type = type;
        }

        public static Product cola {
            get {
                return new Product(ProductType.cola);
            }
        }

        public static Product chips {
            get {
                return new Product(ProductType.chips);
            }
        }

        public static Product candy {
            get {
                return new Product(ProductType.candy);
            }
        }
    }
}
