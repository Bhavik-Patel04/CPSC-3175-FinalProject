using System.Collections;
using System.Collections.Generic;
using System;
using System.Diagnostics;

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

        public string type { get; private set; }


        public Dictionary<string, Action> Actions { get; private set; }

        public Room() : this("empty", "in","normal", new Dictionary<string, Action>()) {}
        public Room(string tag) : this(tag, "in","normal", new Dictionary<string, Action>()) {}

        // Designated Constructor
        public Room(string tag, string conjunction , string type , Dictionary<string,Action> actions_)
        {
            _exits          = new Dictionary<string, Room>();
            Tag             = tag;
            Conjunction     = conjunction;
            this.type       = type;

            this.Actions    = actions_; // actions 
        }


        public void Set_Actions( string key,  Action action_)
        {
            Actions.Add(key, action_);
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
            return "You are " + Conjunction + " " + Tag + " :: "+ type + ".\n *** " + this.GetExits();
        }
    }
}
