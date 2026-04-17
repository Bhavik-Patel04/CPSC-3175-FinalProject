using StarterGame;
using System;
using System.Security.Cryptography;

public class DialogHandler
{

	private readonly Player player_ref;
	private  Random rand = new Random();
    public DialogHandler(Player player)
	{
		player_ref = player;
    }


	public void DialogSelect( Speak cmd )
	{
		
		if (cmd.Dialog.ContainsKey("generic"))
		{
			int roll = rand.Next(0, cmd.Dialog["generic"].Count);
            player_ref.ReplyMessage($"Response: {cmd.Dialog["generic"][roll]}");
		}
	}




}
