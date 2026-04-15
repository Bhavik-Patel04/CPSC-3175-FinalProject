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
            if (players_.Count > 0)
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
                // this would be the destination of the conversation < - then there needs to be a dialog option lol 
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
