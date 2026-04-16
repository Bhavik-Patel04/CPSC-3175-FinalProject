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

        private Room             _currentRoom = null;
        public Room              CurrentRoom { get { return _currentRoom; } set { _currentRoom = value; } }

        private string Type { get; init; }

        public Inventory         main_inventory; // move this to a maker 
        public Wallet            wallet;
        public HealthSystem      health ;


        public Dictionary<string,Speak> SpeakCommands = new Dictionary<string,Speak>();


        public string name {  get; init; }
        public Player(string name, string Type, Inventory I_,Wallet W_, HealthSystem H_, Room room )
        {
            this.main_inventory = I_;
            this.wallet         = W_;
            this.health         = H_; 
            this._currentRoom   = room;
            this.name           = name;
        }


        // internal updater 
        public void update()
        {
            // things that need to update in the background go here 
            // ai can go here 

            // if active player - is in a room - NPCs wont move
            // only move if not in room on update

            // think aboiut bleed effects, money loss spwll, etc
            health.update();
            wallet.update();
        }






        public void SpawnWarp(Room room) // push to room 
        {
            if (CurrentRoom != null)
            {
                CurrentRoom.PlayerHasLeftRoom(this); // leave old room
            }
            if (room != null)
            {
                room.PlayerHasEnteredRoom(this); // enter next 
                this._currentRoom = room;        // set the ref 
            }
            else
            {
                Console.WriteLine($"spawn broken yo { this.name}");
            }
        }



        public void goTo(string direction)
        {
            Room nextRoom = CurrentRoom.GetExit(direction);
            if (nextRoom != null)
            {

                
                CurrentRoom.PlayerHasLeftRoom(this); // leave old room 
                nextRoom.PlayerHasEnteredRoom(this); // enter next 
                CurrentRoom = nextRoom;              // set ref inside player
                
            }
            else
            {
                ErrorMessage("\nThere is no path " + direction);
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
