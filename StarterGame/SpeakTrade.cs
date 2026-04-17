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
        p1.messenger.WarningMessage($"Trading with : [ {p2.name} : {p2.type} ] ");
        // needs to hook into p2's interactions menu
        

        
        // menu
        
        List <Item> forsale  = p2.main_inventory.getAllItemsMarkedForSale();

        if (forsale.Count > 0)
        {
            p2.dialogHandler.TradeSpeach(this);
            p1.messenger.WarningMessage("-----------------[Trade Menu]------------------");
            for (int i = 0; i < forsale.Count; i++)
            {
                p2.messenger.ReplyMessage($"{i} : {forsale[i].price}");
            }

            bool choice = false;
            int option_select = 0;
            while (!choice)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    if (result > 0 && result < forsale.Count)
                    {
                        option_select = result;
                        choice = true;
                    }
                    p1.messenger.WarningMessage($"Selected:  {result}");
                }
                else
                {
                    p1.messenger.WarningMessage("That's not a valid number!");
                }
            }

            Item purchase = p2.main_inventory.getItem(forsale[option_select].id);

            // handle money transaction 
            if (p1.wallet.gold < purchase.price)
            {
                p2.dialogHandler.NotEnoughToTrade(this);
                p1.messenger.WarningMessage("----------------------------------------------");
                return;
            }
            else
            {
                p1.wallet.GiveGold(purchase.price);
                p2.wallet.AddGold(purchase.price);
            }


            // transfer item 
            p2.main_inventory.DelItem(purchase.id, 1);
            p1.main_inventory.AddItem(purchase);

            p1.messenger.WarningMessage("----------------------------------------------");
        }
        else
        {
            p2.dialogHandler.NothingToTradeSpeach(this);
            return;
        }


        p2.dialogHandler.ThankYouSpeach(this);
        
    }
}
