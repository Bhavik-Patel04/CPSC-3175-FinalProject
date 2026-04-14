using System;

public interface IInventory
{
    public bool AddItem(Item item);
    public void DropItem(string id, int numberOf);
    public void DelItem_id(string id, int ammount);
    // add descriptions and add get
    // display
}
