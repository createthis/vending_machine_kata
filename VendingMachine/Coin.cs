using System;

namespace VendingMachine {
    public struct Coin {
        public int milligrams;
        public int millimeters;

        public Coin(int milligrams, int millimeters) {
            this.milligrams = milligrams;
            this.millimeters = millimeters;
        }

        public static Coin penny {
            get {
                return new Coin(2500, 19);
            }
        }

        public static Coin penny_1982_or_older {
            get {
                return new Coin(3110, 19);
            }
        }

        public static Coin nickel {
            get {
                return new Coin(5000, 21); // since 1866
            }
        }

        public static Coin dime {
            get {
                return new Coin(2268, 18); // since 1965
            }
        }

        public static Coin quarter {
            get {
                return new Coin(5670, 24); // since 1965
            }
        }
    }
}
