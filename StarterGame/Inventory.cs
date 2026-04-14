using System;
using System.Collections.Generic;
using System.ComponentModel;
public class Inventory : IInventory
{

    private Dictionary<string, Item> pocket = new Dictionary<string, Item>(); // make that 
    private int Capacity            = 100;
    private double Weight_onboard   = 0.00;
    private double Weight_cap       = 75.00;
    private int Capacity_onboard    = 0;




    public bool AddItem(Item item)
    {
        // exists in dictionary
        if (pocket.ContainsKey(item.id))
        {
            double item_mass = (item.numberOf * item.mass);
            // check if adding it makes us over weight...
            if ((item_mass + Weight_onboard) <= Weight_cap)
            {
                if (Capacity_onboard + item.numberOf <= Capacity)
                { 
                    Capacity_onboard += item.numberOf
                    Weight_onboard += item_mass;     // add up mass
                    pocket[item.id].numberOf += item.numberOf; // add
                    
                    return true;
                }
            }
        }
        // doesnt exist in dictionary
        else
        {
            double item_mass = (item.numberOf * item.mass);
            if (Capacity_onboard + item.numberOf <= Capacity)
            {
                if ((item_mass + Weight_onboard) <= Weight_cap)
                {
                    Weight_onboard += item_mass;     // add up mass
                    pocket.Add(item.id, item);
                    return true;
                }
            }
        }

        return false;
    }

    public void DropItem(string id,int numberOf)
    {
        
    }

    public void DelItem_id(string id,int ammount)
    {
        if (pocket.ContainsKey(id))
        {
            if (ammount >= pocket[id].numberOf) // clamp
            {
                Capacity_onboard    -= pocket[id].numberOf;
                Weight_onboard      -= (pocket[id].numberOf) * pocket[id].mass;
                pocket.Remove(id);
            }
            else
            {
                Capacity_onboard    -= ammount;
                Weight_onboard      -= (ammount * pocket[id].mass);
                pocket[id].numberOf -= ammount;
            }
        }           
    }




}
