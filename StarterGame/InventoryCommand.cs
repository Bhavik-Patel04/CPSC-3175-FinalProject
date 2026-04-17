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

            if (this.HasSecondWord())
            {
                    if (player.InventoryCommands.ContainsKey(this.SecondWord))
                    {
                        player.InventoryCommands[this.SecondWord].Execute(player,this.ThirdWord);
                    }
                    else
                    {
                        player.messenger.ReplyMessage("\nCant do that... ");
                    }
                
                return false;
            }
            else
            {
                player.messenger.ReplyMessage("\nWhat was I doing?...");
            }
            return false;
        }
    }
}
