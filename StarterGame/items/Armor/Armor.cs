using System;
using System.Collections.Generic;
using StarterGame;
public abstract class Armor : Item
{
    public int physical_protection { get; init; }
    public int magic_protection { get; init; }
    public int fire_protection { get; init; }
}