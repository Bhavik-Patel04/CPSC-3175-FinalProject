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
                //player.WaltTo(this.SecondWord);
                Console.WriteLine(this.SecondWord);
            }
            else
            {
                player.WarningMessage("\nDo what?");
            }
            return false;
        }
    }
}
