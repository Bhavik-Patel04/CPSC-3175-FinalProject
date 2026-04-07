using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    /*
     * Spring 2026
     * This is the *node* in the graph
     * that is to become the game world.
     * The game world is a set of rooms
     * connected to each other.
     */
    public class Room
    {
        private Dictionary<string, Room> _exits;
        private string _tag;
        private string _conjunction;
        public string Tag { get { return _tag; } set { _tag = value; } }
        public string Conjunction { get { return _conjunction; } set { _conjunction = value; } }

        public Room() : this("empty", "in"){}
        public Room(string tag) : this(tag, "in"){}

        // Designated Constructor
        public Room(string tag, string conjunction)
        {
            _exits = new Dictionary<string, Room>();
            Tag = tag;
            Conjunction = conjunction;
        }

        public void SetExit(string exitName, Room room)
        {
            _exits[exitName] = room;
        }

        public Room GetExit(string exitName)
        {
            Room room = null;
            _exits.TryGetValue(exitName, out room);
            return room;
        }

        public string GetExits()
        {
            string exitNames = "Exits: ";
            Dictionary<string, Room>.KeyCollection keys = _exits.Keys;
            foreach (string exitName in keys)
            {
                exitNames += " " + exitName;
            }

            return exitNames;
        }

        public string Description()
        {
            return "You are " + Conjunction + " " + Tag + ".\n *** " + this.GetExits();
        }
    }
}
