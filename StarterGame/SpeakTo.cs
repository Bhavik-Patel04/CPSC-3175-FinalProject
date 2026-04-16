using StarterGame;
using System;
using System.Collections.Generic;

public class SpeakTo : Speak
{

	private Dictionary<string, List<string>> Dialog;
    public SpeakTo(Dictionary<string, List<string>> Dialog )
	{
		this.Dialog = Dialog;
	}

	public string keyword { get; } = "to"; // comand to initate this section

	public string Execute(Player p1,Player p2)
	{
		// has p1 = player 
		// has p2 = NPC
		Console.WriteLine($"You are talking to {p2.name}");
		return "yes";
	}
}
