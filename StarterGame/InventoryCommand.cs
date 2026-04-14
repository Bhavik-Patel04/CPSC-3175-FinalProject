using System;
using System.Collections;
using System.Collections.Generic;

namespace StarterGame
{

    public class InventoryCommand : Command
    {

        public InventoryCommand() : base()
        {
            this.Name = "inventory"; // this is a toggle for commands
        }

        override
        public bool Execute(Player player)
        {

            // i see a mojor problem here 
            // normally actions in rooms like ( pick up items, scan, talk to people )  hook into inventory ( pick up itmes ) 
            // what does " inventory "second word" do - the only thing you can do with no action is look at it ? so thi just brings it up ? 
            if (this.HasSecondWord())
            {
              

            }
            else
            {
                player.WarningMessage("\nInventory? What did you want to do?");

            }
            return false;
        }
    }
}
