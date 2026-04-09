using StarterGame;
using System;

public class MineAction : Action 
{
	public int durration	= 1000;         // time ( in ms ) per tick 
    public int diceroll		= 0;            // lucky 	
    public int cost			= 5;            // energy per tick 
	private Random dice = new Random();


    public MineAction()
	{ 
	}

	public void Execute(Player player)
	{
		Console.WriteLine("[mine action] We are mining right now....");
        double s		= dice.NextDouble();
		
    }
}
