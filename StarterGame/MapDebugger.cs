using System;
using System.Collections.Generic;
using StarterGame;

public static class MapDebugger
{
    public static void PrintAll(Room start)
    {
        var visited = new HashSet<Room>();
        var queue = new Queue<Room>();

        queue.Enqueue(start);
        visited.Add(start);

        Console.WriteLine("=== MAP DEBUG ===");

        while (queue.Count > 0)
        {
            var room = queue.Dequeue();

            Console.WriteLine($"\n[{room.Tag}]");

            PrintExit(room, "north", visited, queue);
            PrintExit(room, "south", visited, queue);
            PrintExit(room, "east", visited, queue);
            PrintExit(room, "west", visited, queue);
        }

        Console.WriteLine("\n=== END MAP ===");
    }

    private static void PrintExit(Room room, string dir, HashSet<Room> visited, Queue<Room> queue)
    {
        Room next = room.GetExit(dir);

        if (next != null)
        {
            Console.WriteLine($"  {dir} -> {next.Tag}");

            if (!visited.Contains(next))
            {
                visited.Add(next);
                queue.Enqueue(next);
            }
        }
    }
}