using System;

public interface Item  // add description
{
	#nullable enable // context modifier 
    public string id { get; init; }
	public int numberOf { get; set; }
	public double mass { get; init; }
	public string type { get; init; }

	public double price { get; init; }

    public bool OnlyOneFlag { get; init; }

    public bool forSale { get; set; }

}
