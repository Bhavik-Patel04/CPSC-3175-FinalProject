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


	public void GenericSpeach( Speak cmd )
	{
		if (cmd.Dialog.ContainsKey("generic"))
		{
			int roll = rand.Next(0, cmd.Dialog["generic"].Count);
            player_ref.messenger.ReplyMessage($"{cmd.Dialog["generic"][roll]}");
		}
	}


    public void TradeSpeach(Speak cmd)
    {
        if (cmd.Dialog.ContainsKey("trade"))
        {
            int roll = rand.Next(0, cmd.Dialog["trade"].Count);
            player_ref.messenger.ReplyMessage($"{cmd.Dialog["trade"][roll]}");
        }
    }


    public void ThankYouSpeach(Speak cmd)
    {
        if (cmd.Dialog.ContainsKey("thanks"))
        {
            int roll = rand.Next(0, cmd.Dialog["thanks"].Count);
            player_ref.messenger.ReplyMessage($"{cmd.Dialog["thanks"][roll]}");
        }
    }

    public void NothingToTradeSpeach(Speak cmd)
    {
        if (cmd.Dialog.ContainsKey("notrade"))
        {
            int roll = rand.Next(0, cmd.Dialog["notrade"].Count);
            player_ref.messenger.ReplyMessage($"{cmd.Dialog["notrade"][roll]}");
        }
    }


    public void NotEnoughToTrade(Speak cmd)
    {
        if (cmd.Dialog.ContainsKey("notenough"))
        {
            int roll = rand.Next(0, cmd.Dialog["notenough"].Count);
            player_ref.messenger.ReplyMessage($"{cmd.Dialog["notenough"][roll]}");
        }
    }


    public void QuitTrade(Speak cmd)
    {
        if (cmd.Dialog.ContainsKey("quittrade"))
        {
            int roll = rand.Next(0, cmd.Dialog["quittrade"].Count);
            player_ref.messenger.ReplyMessage($"{cmd.Dialog["quittrade"][roll]}");
        }
    }



}
