using StarterGame;
using System;
using System.Collections.Generic;

public class MapGenerator
{
    private Dictionary<string, Room> rooms_cache;
    private Random rand = new Random();
    private string[] directions = { "north", "south", "east", "west" };

    public Room Generate(int roomCount = 10)
    {
        rooms_cache = new Dictionary<string, Room>();

        // 1. Create rooms
        for (int i = 0; i < roomCount; i++)
        {
            string key = "room" + i;
            rooms_cache[key] = new Room($"Room #{i}", "in");
        }

        // 2. Ensure connectivity (chain them first)
        for (int i = 0; i < roomCount - 1; i++)
        {
            Room a = rooms_cache["room" + i];
            Room b = rooms_cache["room" + (i + 1)];

            string dir = GetRandomDirection();
            string opposite = GetOpposite(dir);

            a.SetExit(dir, b);
            b.SetExit(opposite, a);
        }

        // 3. Add random extra connections
        int extraConnections = roomCount; // tweak density here

        for (int i = 0; i < extraConnections; i++)
        {
            Room a = GetRandomRoom();
            Room b = GetRandomRoom();

            if (a == b) continue;

            string dir = GetRandomDirection();
            string opposite = GetOpposite(dir);

            a.SetExit(dir, b);
            b.SetExit(opposite, a);
        }

        // 4. Return starting room
        return rooms_cache["room0"];
    }



    private Room GetRandomRoom()
    {
        int index = rand.Next(rooms_cache.Count);
        foreach (var room in rooms_cache.Values)
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



    public Room GetRoom(string key)
    {
        return rooms_cache.ContainsKey(key) ? rooms_cache[key] : null;
    }
}