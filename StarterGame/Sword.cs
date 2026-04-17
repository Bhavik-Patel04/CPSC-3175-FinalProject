using System;
using System.Collections.Generic;

public class Sword:Item
{


#nullable enable // context modifier 
    public string id { get; init; } = "sword";
    public int numberOf { get; set; } = 1;
    public double mass { get; init; } = 10;
    public string type { get; init; } = string.Empty;
    public bool OnlyOneFlag { get; init; } = true;
    public double price { get; init; } = 100;
    public bool Equippable { get; init; } = true;
    public bool forSale { get; set; }
}
