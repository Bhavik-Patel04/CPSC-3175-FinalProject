using StarterGame;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
public class Person : Player
{
    public Person(
        string name,
        List<Speak> dialog,
        Inventory I_,
        List<ICs> InventoryCommands,
        Wallet W_,
        HealthSystem H_,
        Room room)
        : base(name, dialog, I_, InventoryCommands, W_, H_, room)
    {
    }
}
