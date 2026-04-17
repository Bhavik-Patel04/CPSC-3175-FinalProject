using StarterGame;
using System;
using System.Collections.Generic;

public class SpeakTrade : Speak
{

    public Dictionary<string, List<string>> Dialog { get; init; }
    public SpeakTrade(Dictionary<string, List<string>> Dialog)
    {
        this.Dialog = Dialog;
    }

    public string keyword { get; } = "trade"; // comand to initate this section


    public void Execute(Player p1, Player p2)
    {
        //  p1 = player 
        //  p2 = NPC
        p1.WarningMessage($"Trading with : [ {p2.name} : {p2.type} ] ");
        // needs to hook into p2's interactions menu
        //p2.dialogHandler.DialogSelect(this);
    }
}
