using System;

public interface IInventory
{
    public bool AddItem(Item item);
    public int DelItem(string id, int ammount);
    public void useItem(string id, int ammount);
    public Item? getItem(string id);
    public string ReadInventory();
}
