using System;
using StarterGame;
public interface ICs
{
    public string keyword { get; }
    public void Execute(Player p1, string key = null);
}
