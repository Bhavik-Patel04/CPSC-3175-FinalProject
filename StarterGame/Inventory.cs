using StarterGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
public class Inventory : IInventory
{

    private Dictionary<string, Item> pocket = new Dictionary<string, Item>(); // make that 
    private int Capacity                = 100;
    private double Weight_onboard       = 0.00;
    private double Weight_cap           = 75.00;
    private int Capacity_onboard        = 0;




    public Item? getItem(string id)
    {
        if (pocket.ContainsKey(id))
        {
            return pocket[id];
        }
        return null;
    }



    public void useItem( string id , int ammount)
    {
        Item item = getItem(id);
        if (item != null)
        {
            if (item.type == "consumable")
            {
                // really need to send this to a processor or something here 
                // get properties 
                // send them to a thing to use it 

                int amt_used = DelItem(item,ammount);
                
            }
        }
    }



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
                    Capacity_onboard         += item.numberOf;  // capacity
                    Weight_onboard           += item_mass;     // add up mass
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



    public int DelItem(Item item, int ammount)
    {
        if (ammount < item.numberOf) // clamp
        {
            Capacity_onboard    -= ammount;
            Weight_onboard      -= (ammount * item.mass);
            item.numberOf       -= ammount;
            return ammount;
        }
        else
        {
            // create persitant tracking
            string temp_id          = item.id;
            int temp_actualAmmount  = 0;

            temp_actualAmmount   = item.numberOf;
            Capacity_onboard    -= item.numberOf;
            Weight_onboard      -= (item.numberOf) * item.mass;
            pocket.Remove(temp_id);
            return temp_actualAmmount;

        }
    }



    public string ReadInventory()
    {
        if (pocket.Count != 0)
        {
            foreach (var item in pocket.Values)
            {
                return $"{item.id} >>> {item.numberOf} (Mass: {item.mass * item.numberOf}";
            }
        }
        return "Your inventory is empty...";
    }


}
