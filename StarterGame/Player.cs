using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using System.Data;

namespace StarterGame
{
    /*
     * Spring 2026
     * The is your *actor* in the Command Design
     * pattern. The instance of this class should
     * execute all the commands.
     */
    public class Player
    {
        private Room _currentRoom = null;
        public Room CurrentRoom { get { return _currentRoom; } set { _currentRoom = value; } }

        private Double health = 100.00;
        private bool combat_state = false;


        public Player(Room room)
        {
            _currentRoom = room;
        }


        // combat hit register
        public void hit(double points)
        {
            if (health > points)
            {
                health -= points;
            }
            else 
            {
                health = 0;
            }
        }


        public void WaltTo(string direction)
        {
            Room nextRoom = CurrentRoom.GetExit(direction);
            if (nextRoom != null)
            {
                CurrentRoom = nextRoom;
                NormalMessage("\n" + this.CurrentRoom.Description());
            }
            else
            {
                ErrorMessage("\nThere is no door on " + direction);
            }
        }

        public void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ColoredMessage(string message, ConsoleColor newColor)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = newColor;
            OutputMessage(message);
            Console.ForegroundColor = oldColor;
        }

        public void NormalMessage(string message)
        {
            ColoredMessage(message, ConsoleColor.White);
        }

        public void InfoMessage(string message)
        {
            ColoredMessage(message, ConsoleColor.Blue);
        }

        public void WarningMessage(string message)
        {
            ColoredMessage(message, ConsoleColor.DarkYellow);
        }

        public void ErrorMessage(string message)
        {
            ColoredMessage(message, ConsoleColor.Red);
        }
    }

}
