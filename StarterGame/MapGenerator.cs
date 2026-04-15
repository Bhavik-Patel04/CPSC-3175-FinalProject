using StarterGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.AccessControl;
using System.Transactions;

public class MapGenerator
{
    private Dictionary<int, Dictionary<int,Room>> rooms_cache;
    private Random rand = new Random();
    private string[] directions = { "north", "south", "east", "west" };

    // Huge random underground maze geberator - very hard to find the way out 
    // randomly links rooms, some rooms fold back in ways that can not be described on a flat map 
    // could add a Z component to track you height in the dungon


    public Room Generate(int levels = 10, int sprawl = 30)
    {
        rooms_cache = new Dictionary<int, Dictionary<int,Room>>();
        Random uplink_room = new Random();
        for (int levels_ = 0; levels_ < levels; levels_++)
        {
            rooms_cache[levels_] = new Dictionary<int, Room>();
            for (int sprawl_ = 0; sprawl_ < sprawl; sprawl_++)
            {
                string key = $"level{levels_}room{sprawl_}";
                string type = TypeDiceRoll(); // roll for a type 

                Dictionary<string, Action> actions_ = BindActions(type);
                rooms_cache[levels_][sprawl_] = new Room(
                                            key,
                                            "in",
                                            type,           // rolled by dice roll 
                                            actions_        // pass activities here
                                            );
            }

            // chain link rooms
            for (int sprawl_ = 0; sprawl_ < sprawl-1; sprawl_++)
            {
                Room a = rooms_cache[levels_][sprawl_];
                Room b = rooms_cache[levels_][sprawl_+1];

                string dir          = GetRandomDirection();
                string opposite     = GetOpposite(dir);

                a.SetExit(dir, b);
                b.SetExit(opposite, a);
            }

    
            // add random connections 
            for (int i = 0; i < sprawl; i++)
            {
                Room a = GetRandomRoomByLevel(levels_);
                Room b = GetRandomRoomByLevel(levels_);

                if (a == b) continue;

                string dir      = GetRandomDirection();
                string opposite = GetOpposite(dir);

                a.SetExit(dir, b);
                b.SetExit(opposite, a);
            }

            // set up rooms // path to next level hiden 
            if (levels_ >= 1)
            {
                Room a = GetRandomRoomByLevel(levels_ - 1);     // lower room 
                Room b = GetRandomRoomByLevel(levels_);         // upper room

                a.SetExit("up", b);
                b.SetExit("down", a);
            }


        }
        return rooms_cache[0][0];
    }



    private Dictionary<string,Action> BindActions(string type)
    {

        Dictionary<string, Action>  actions_  = new Dictionary<string, Action>(); 

        if (type == "mine")
        {
            actions_.Add("mining",new MineAction());
        }
        return actions_;
    }

  
    private string TypeDiceRoll()
    {
        Random dice = new Random();
        double roll = 0;
        int count = 0;
        
        // roll a few times and get average 
        for (; count < 5; count++)
        {
            roll  += dice.NextDouble(); 
        }
        roll = roll / count;              // average roll 


        string type = "mine";           // defualt 
        if (roll >= .4 && roll < .5)    // 10% roll     // make this set actions to rooms
        {
            type = "town";
        }

        if (roll >= .5 && roll < .55)   // 5% roll
        {
            type = "shop";           
        }

        if (roll >= .55 && roll < .56)  // 1% roll 
        {
            type = "trap";
        }

        if (roll >= .56 && roll < .57)  // 1% roll 
        {
            type = "artifact";
        }

        if (roll >= .57 && roll < .59)  // 2% roll 
        {
            type = "boss";
        }


        return type;
    }


    public Room GetRandomRoomByLevel(int level)
    {
        int index = rand.Next(rooms_cache[level].Count);
        foreach (var room in rooms_cache[level].Values)
        {
            if (index-- == 0)
                return room;
        }
        return null;
    }




    private string GetRandomDirection()
    {
        return directions[rand.Next(directions.Length)];
    }



    private string GetOpposite(string dir)
    {
        switch (dir)
        {
            case "north": return "south";
            case "south": return "north";
            case "east": return "west";
            case "west": return "east";
            default: return "north";
        }
    }



    public Room GetRoom(int level, int room)
    {
        if (rooms_cache.ContainsKey(level) && rooms_cache[level].ContainsKey(room))
        {
            return rooms_cache[level][room];
        }
        return null;
    }
}