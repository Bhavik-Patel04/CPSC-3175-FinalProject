using StarterGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
public class Inventory : IInventory
{

    private Dictionary<string, Item> pocket = new Dictionary<string, Item>();   
    private Dictionary<string, Item> equipment = new Dictionary<string, Item>();
    private Dictionary<string, Item> armor = new Dictionary<string, Item>();

    private int Capacity                = 100;      // capacity cap
    private int Capacity_onboard        = 0;


    private double Weight_onboard       = 0.00;
    private double Weight_cap           = 75.00;    // pocket weight limit

 
    private double Equipment_onboard    = 0;
    private int Equipment_cap           = 25;       // 100 pound carry limit

    private double Armor_onboard        = 0;
    private int Armor_cap               = 25;        

    // ABSOLUTE LIMITS
    private double MAX_WEIGHT           = 150;
   private double MAX_EQIPMENT_WEIGHT   = 50;


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


    public bool Equip(string id)
    {
        if (pocket.ContainsKey(id))
        {
            if (pocket[id] is Weapon )
            {
                if (!equipment.ContainsKey(pocket[id].id))
                { 
                    if (Equipment_onboard + pocket[id].mass <= Equipment_cap)
                    {
                        Equipment_onboard += pocket[id].mass;
                        equipment.Add(id, pocket[id]);
                        DelItem(id, 1);
                        return true;
                    }
                }
            }

            if (pocket[id] is Armor)
            {
                if (!armor.ContainsKey(pocket[id].id))
                {
                    if (Armor_onboard + pocket[id].mass <= Armor_cap)
                    {
                        Armor_onboard += pocket[id].mass;
                        armor.Add(id, pocket[id]);
                        DelItem(id, 1);
                        return true;
                    }
                }
            }

        }
        return false;
    }


    public bool Unequip(string id)
    {
        if (equipment.ContainsKey(id))
        {
            Equipment_onboard -= equipment[id].mass;
            Item tmp = equipment[id];
            equipment.Remove(id);
            AddItem(tmp);
            return true;

        }
        if (armor.ContainsKey(id))
        {
            Armor_onboard -= armor[id].mass;
            Item tmp = armor[id];
            armor.Remove(id);
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
           if (item is Potion)
            {

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
        if (!pocket.ContainsKey(id))
        {
            return 0;
        }
        if (ammount < pocket[id].numberOf) // clamp
        {
            Capacity_onboard            -= ammount;
            Weight_onboard              -= (ammount * pocket[id].mass);
            pocket[id].numberOf         -= ammount;
            return ammount;
        }
        else
        {
            // create persitant tracking
            int temp_actualAmmount      = 0;
            temp_actualAmmount          = pocket[id].numberOf;
            Capacity_onboard           -= pocket[id].numberOf;
            Weight_onboard             -= (pocket[id].numberOf) * pocket[id].mass;
            pocket.Remove(id);
            return temp_actualAmmount;

        }
    }


    public string getInfo()
    {
        return $"Inventory weight : [{Weight_onboard}]lbs ||  Equipment : [{Equipment_onboard}]lbs || Armor : [{Armor_onboard}]lbs";
    }

    public string ReadInventory()
    {
        if (pocket.Count != 0)
        {
            string tmp = "";
            if (armor.Count > 0)
            {
                tmp += "[ Armor ]---------------------------------------------------------------------\n";
                foreach (var item in armor.Values)
                {
                    tmp += $"{item.id} >>> #: {item.numberOf} [Mass: {item.mass * item.numberOf}]\n";
                }
            }
            if (equipment.Count > 0)
            {
                tmp += "[ Equioment ]------------------------------------------------------------------\n";
                foreach (var item in equipment.Values)
                {
                    tmp += $"{item.id} >>> #: {item.numberOf} [Mass: {item.mass * item.numberOf}]\n";
                }
            }
            if (pocket.Count > 0)
            {
                tmp += "[ Inventory ]------------------------------------------------------------------\n";

                foreach (var item in pocket.Values)
                {
                    tmp += $"{item.id} >>> #: {item.numberOf} [Mass: {item.mass * item.numberOf}]\n";
                }
            }
            return tmp;
        }
        return "Your inventory is empty...";
    }


}
