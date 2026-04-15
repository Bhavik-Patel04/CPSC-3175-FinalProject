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
            player.InfoMessage("players in room:");

            List<string> players_ = player.CurrentRoom.OccupancyToList(player);
            for (int i = 0;i< players_.Count; i++)
            {
                if (player.name != players_[i])
                {
                    player.InfoMessage(players_[i]);
                }
            }

            if (this.HasSecondWord())
            {
                return false;
            }
            else
            {
                player.WarningMessage("\nDo what?");
            }
            return false;
        }
    }
}
