using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class HealingPotion : Potion
{

    public int stat { get; init; } = 25;


    public HealingPotion(string id, int numberOf, double mass, double price, int healing)
    {
        base.id         = id;
        base.price      = price;
        base.mass       = mass;
        base.numberOf   = numberOf;
        base.healing    = healing;
        base.forSale    = false;
    }
}
