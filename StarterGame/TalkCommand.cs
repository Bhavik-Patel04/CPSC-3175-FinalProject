using System;
using System.Collections;
using System.Collections.Generic;

namespace StarterGame
{

    public class TalkCommand : Command
    {

        public TalkCommand() : base()
        {
            this.Name = "speak";
        }

        override
        public bool Execute(Player player)
        {
            
            // this shouldnt be here but it works 
            List<string> players_ = player.CurrentRoom.OccupancyToList(player);
            if (players_.Count > 1)
            {
                player.InfoMessage("players in room:");
                for (int i = 0; i < players_.Count; i++)
                {
                    if (player.name != players_[i])
                    {
                        player.InfoMessage(players_[i]);
                    }
                }
            }
            else
            {
                player.InfoMessage("Talking to yourself is a sure sign of madness, these caverns are listening...");
            }

            if (this.HasSecondWord())
            {

                // push to exicute here and - push third word down 



                // this is the speak sub command ( trade, to, and fight ) 
                if (this.HasThirdWord())
                {
                    player.InfoMessage("working... has third word");
                    
                }
               

                return false;
            }
            else
            {
                player.WarningMessage("\nSpeek to whom? Youself perhaps? ");
            }
            return false;
        }
    }
}
