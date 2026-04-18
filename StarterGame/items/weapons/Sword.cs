using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Sword:Weapon
{

    public int stat { get; init; } = 25;

    
    public Sword( string id, int numberOf, double mass,double price, int damage )
    {
        base.id         = id;
        base.price      = price;
        base.damage     = damage;
        base.mass       = mass;
        base.forSale    = false;
        base.numberOf   = numberOf;
        base.damage     = damage;
    }
}
