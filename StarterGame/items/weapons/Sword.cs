using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Sword:Weapon
{

    public int stat { get; init; } = 25;

    
    public Sword( string id, int numberOf, double mass,double price, int physical, int fire, int magic )
    {
        base.id                  = id;
        base.price               = price;
        base.mass                = mass;
        base.forSale             = false;
        base.numberOf            = numberOf;

        base.physical_damage    = physical;
        base.fire_damage        = fire;
        base.magic_damage       = magic;

    }
}
