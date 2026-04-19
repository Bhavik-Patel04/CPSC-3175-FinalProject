using System;
using System.Xml.Serialization;
using StarterGame;
public class InventoryUse : ICs
{
    public string keyword { get; } = "use"; // comand to initate this section

    public void Execute(Player p1, string key = null)
    {
        int choice = 0;
        while (choice == 0)
        {
            p1.messenger.InfoMessage(p1.main_inventory.getItemInfo(key),ConsoleColor.White);
            p1.messenger.InfoMessage("Input an ammount to use:",ConsoleColor.White);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                if (result == 0)
                {
                    p1.messenger.InfoMessage("Canceled...", ConsoleColor.Red);
                    break;
                }
                else
                {
                    choice = result;
                }
            }
        }


        p1.main_inventory.useItem(key,choice);
    }
}
