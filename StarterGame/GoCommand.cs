using System.Collections;
using System.Collections.Generic;

namespace StarterGame
{
    /*
     * Fall 2025
     */
    public class GoCommand : Command
    {

        public GoCommand() : base()
        {
            this.Name = "go";
        }

        override
        public bool Execute(Player player)
        {
            if (this.HasSecondWord())
            {
                player.goTo(this.SecondWord);
            }
            else
            {
                player.WarningMessage("\nGo Where?");
            }
            return false;
        }
    }
}
