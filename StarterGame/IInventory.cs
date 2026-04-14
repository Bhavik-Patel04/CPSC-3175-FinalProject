using System;

public interface IInventory
{
    public void AddItem(Item item);
    public void DropItem(string id, int numberOf);
    public bool DelItem_id(string id);
    // add descriptions and add get
    // display
}
