using System;
using System.Collections.Generic;
using StarterGame;
public abstract class Weapon : Item
{
    public int damage { get; init; }

    public int chance { get; init; }
    public int fire_damage { get; init; }
    public int magic_damage { get; init; }
    public int physical_damage { get; init; }


}