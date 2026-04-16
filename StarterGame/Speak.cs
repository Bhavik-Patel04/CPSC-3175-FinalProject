using StarterGame;
using System;

public interface Speak
{
    public string keyword {get;}
    public string Execute(Player p1, Player p2);
}
