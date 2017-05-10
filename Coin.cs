using System;

public struct Coin {
    public float weight; // grams
    public float size; // mm

    public Coin(float weight, float size) {
        this.weight = weight;
        this.size = size;
    }

    public static Coin penny {
        get {
            return new Coin(2.5f, 19);
        }
    }

    public static Coin penny_1982_or_older {
        get {
            return new Coin(3.11f, 19);
        }
    }

    public static Coin nickel {
        get {
            return new Coin(5, 21); // since 1866
        }
    }

    public static Coin dime {
        get {
            return new Coin(2.268f, 18); // since 1965
        }
    }

    public static Coin quarter {
        get {
            return new Coin(5.670f, 24); // since 1965
        }
    }
}
