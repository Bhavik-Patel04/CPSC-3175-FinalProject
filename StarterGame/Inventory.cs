using StarterGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
public class Inventory : IInventory
{

    private Dictionary<string, Item> pocket = new Dictionary<string, Item>();   
    private Dictionary<string, Item> equpment = new Dictionary<string, Item>();
    private int Capacity                = 100;      // capacity cap
    private double Weight_onboard       = 0.00;
    private double Weight_cap           = 75.00;    // pocket weight limit
    private int Capacity_onboard        = 0;
    private double Equipment_onboard    = 0;
    private int Equipment_cap           = 25;       // 100 pound carry limit

   // ABSOLUTE LIMITS
   private double MAX_WEIGHT = 150;
   private double MAX_EQIPMENT_WEIGHT = 50;


    //-------------------------------------------------------------------------------------------------------
    // Settings for weight
    //-------------------------------------------------------------------------------------------------------


    private bool RaiseInventoryWeightCap(int ammount)
    {
        if (Weight_cap + ammount <= MAX_WEIGHT)
        {
            Weight_cap += ammount;
            return true;
        }
        return false;

    }

    private bool RaiseEquipmentWeightCap(int ammount)
    {
        if (Equipment_cap + ammount <= MAX_EQIPMENT_WEIGHT)
        {
            Equipment_cap += ammount;
            return true;
        }
        return false;

    }


    //-------------------------------------------------------------------------------------------------------
    // Equipment attachment
    //-------------------------------------------------------------------------------------------------------

    public bool Equip(Item item)
    {
        string tmp = item.id;
        if (item.Equippable && item.OnlyOneFlag)
        {
            if (!equpment.ContainsKey(item.id))
            {
                if (Equipment_onboard + item.mass <= Equipment_onboard)
                {
                    Equipment_onboard += item.mass;
                    DelItem(tmp, 1);
                    equpment.Add(tmp, item);
                    return true;
                }
            }
        }
        return false;
    }

    public bool Unequip(string id)
    {
        if (equpment.ContainsKey(id))
        {
            Item tmp = equpment[id];
            equpment.Remove(id);
            AddItem(tmp);
            return true;

        }
        return false;
    }


    //-------------------------------------------------------------------------------------------------------
    // Sell, trade, use items 
    //-------------------------------------------------------------------------------------------------------



    public List<Item> getAllItemsMarkedForSale()
    {
        List<Item> __ = new List<Item>();
        foreach (var (k, v) in pocket)
        {
            if (v.forSale == true)
            {
                __.Add(v);
            }
        }
       return __;
    }



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

                int amt_used = DelItem(id,ammount);
                
            }
        }
    }


    //-------------------------------------------------------------------------------------------------------
    // Inventory managment
    //-------------------------------------------------------------------------------------------------------


    public bool AddItem(Item item)
    {
        // exists in dictionary
        if (pocket.ContainsKey(item.id))
        {
            double item_mass = (item.numberOf * item.mass);
            // check if adding it makes us over weight...

            if (!item.OnlyOneFlag)
            {
                if ((item_mass + Weight_onboard) <= Weight_cap)
                {
                    if (Capacity_onboard + item.numberOf <= Capacity)
                    {
                        Capacity_onboard += item.numberOf;  // capacity
                        Weight_onboard += item_mass;     // add up mass
                        pocket[item.id].numberOf += item.numberOf; // add

                        return true;
                    }
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



    public int DelItem(string id, int ammount)
    {
        if (pocket.ContainsKey(id))
        {
            return 0;
        }
        if (ammount < pocket[id].numberOf) // clamp
        {
            Capacity_onboard    -= ammount;
            Weight_onboard      -= (ammount * pocket[id].mass);
            pocket[id].numberOf       -= ammount;
            return ammount;
        }
        else
        {
            // create persitant tracking
            
            int temp_actualAmmount  = 0;
            temp_actualAmmount   = pocket[id].numberOf;
            Capacity_onboard    -= pocket[id].numberOf;
            Weight_onboard      -= (pocket[id].numberOf) * pocket[id].mass;
            pocket.Remove(id);
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
