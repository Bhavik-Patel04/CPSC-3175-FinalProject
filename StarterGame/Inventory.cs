using System;
using System.Collections.Generic;
using System.ComponentModel;
public class Inventory : IInventory
{

    private Dictionary<string, Item> pocket = new Dictionary<string, Item>(); // make that 
    private int Capacity            = 100;
    private double Weight_onboard   = 0.00
    private double Weight_cap       = 75.00; 

    public void AddItem(Item item)
    {
        if (pocket.ContainsKey(item.id))
        {
            pocket[item.id].numberOf += item.numberOf;
            return;
        }
        pocket.Add(item.id,item);
    } 


    public void DropItem(string id,int numberOf)
    {
        
    }

    public bool DelItem_id(string id)
    {
        return pocket.Remove(id);
    }




}
