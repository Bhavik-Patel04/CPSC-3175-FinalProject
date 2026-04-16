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
            
            
            List<string> players_ = player.CurrentRoom.OccupancyToList(); // defently a hack lol
            if (players_.Count < 2){
                player.InfoMessage("Talking to yourself is a sure sign of madness, these caverns are listening...");
            }

            

            if (this.HasSecondWord())
            {
                // push to exicute here and - push third word down 
                // this is the speak sub command ( trade, to, and fight ) 
                if (this.HasThirdWord())
                {
                    Player p2 = player.CurrentRoom.FindPlayerInRoom(this.ThirdWord);
                    if (p2 != null)
                    {
                        if (p2.SpeakCommands.ContainsKey(this.SecondWord))
                        {
                            string? response = p2.SpeakCommands[this.SecondWord].Execute(player);
                        }
                    }
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
