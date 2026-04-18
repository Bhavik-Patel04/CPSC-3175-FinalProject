using System;
using System.Collections;
using System.Collections.Generic;

namespace StarterGame
{

    public class ActionCommand : Command
    {

        public ActionCommand() : base()
        {
            this.Name = "do";
        }

        override
        public bool Execute(Player player)
        {
            if (this.HasSecondWord())
            { 
                if (player.CurrentRoom != null) // guard
                {
                    if (player.CurrentRoom.Actions.ContainsKey(this.SecondWord))
                    {
                        // do the thing man 
                        player.CurrentRoom.Actions[this.SecondWord].Execute();
                        return false;
                    }
                    player.messenger.WarningMessage($"\nYou shall not do '{this.SecondWord}' in this location... ");
                }
            }
            else
            {
                player.messenger.WarningMessage("\nDo what?");
            }
            return false;
        }
    }
}
