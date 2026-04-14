using System;
using StarterGame;
public class Wallet
{

    public int gold { get; private set; }
    private int capacity { get; set; }
    private string name { get; set; }

    public int Capacity { get; private set; }

    public Wallet(int capacity)
    {
        this.Capacity = capacity;
        gold = 0;

    }

    public bool AddGold(int amount)
    {
        if (gold + amount > Capacity)
        {
            Console.WriteLine("Cannot add gold. Wallet capacity exceeded.");
            return false;
        }
        else
        {
            gold += amount;
            Console.WriteLine($"{amount} gold added. Current gold: {gold}");
            return true;
        }
    }

    public bool GiveGold(int amount, Player player)
    {
        if (gold - amount < 0)
        {
            Console.WriteLine("Cannot give gold. Not enough gold in wallet.");
            return false;
        }
        else
        {
            if (player.AddGold(amount))
            {
                gold -= amount;
                Console.WriteLine($"{amount} gold given. Current gold: {gold}");
                return true;
            }
        }
        return false;
    }

    public bool DropGold(int amount)
    {
        if (gold - amount < 0)
        {
            Console.WriteLine("Cannot drop gold. Not enough gold in wallet.");
            return false;
        }
        else
        {
            gold -= amount;
            Console.WriteLine($"{amount} gold dropped. Current gold: {gold}");
            return true;
        }
    }


}
