using StarterGame;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

public class CharacterCreator
{
    List<string> maleMinerNames = new List<string>
{
    "Bram",
    "Garrick",
    "Flint",
    "Oswin",
    "Reeve",
    "Thatcher",
    "Wick",
    "Alden",
    "Miller",
    "Vance",
    "Kael",
    "Beck",
    "Ryser",
    "Grier",
    "Dax",
    "Rusty",
    "Decker",
    "Sully",
    "Ridge",
};

    List<string> femaleMinerNames = new List<string>
{
    "Maren",
    "Sola",
    "Petra",
    "Hester",
    "Vesper",
    "Gwen",
    "Lilla",
    "Etta",
    "Sloane",
    "Kaya",
    "Mara",
    "Juno",
    "Tilda",
    "Fern",
    "Zora",
    "Penny",
    "Tess",
    "Mae",
    "Lyra",
};

    List<string> minerLastNames = new List<string>
{
    
    "Oakhaven",
    "Grimm",
    "Blackwood",
    "Ironfoot",
    "Hillman",
    "Clay",
    "Burrow",
    "Stonecutter",
    "Root",
    "Thorn",

    "Steel",
    "Hardy",
    "Walker",
    "Geary",
    "Vance",
    "Sledge",
    "Weld",
    "Cross",
    "Stark",
    "Miller",

    "Duke",
    "Shaft",
    "Gravel",
    "Vein",
    "Dustman",
    "Coal",
    "Quarry",
    "Pickman",
    "Low",
    "Shale",

    "Hawk",
    "Bend",
    "Carpenter",
    "Allen",
    "Andrews",
};


    private int idcount = 0;
	private Dictionary<string,Player> players = new Dictionary<string,Player>();
    private Random rand                       = new Random();
    public CharacterCreator()
	{


    }



	public Player createRandomPerson(string? name = null) // default to true / shuld handle like several hundred players no problem - is overkill 
	{

        // name generator - loops until met
        int counter = 0;
        while (name == null)
        {
            counter++; // timeout counter
            idcount++; // index of all players 
            List<string> selected_gender;
            int gender = rand.Next(0, 1);
            int name_roll;
            int lastName_roll;

            if (gender == 0) {
                selected_gender = maleMinerNames;
                name_roll = rand.Next(0, maleMinerNames.Count);
            } else {
                selected_gender = femaleMinerNames;
                name_roll = rand.Next(0, femaleMinerNames.Count);
            }
            lastName_roll = rand.Next(0, minerLastNames.Count);
            string temp_name = $"{selected_gender[name_roll]}_{minerLastNames[lastName_roll]}";
            if (!players.ContainsKey(temp_name))
            {
                name = temp_name;
                continue;
            }
            else
            {
                if (counter > 5) // time out for generator
                {
                    name = $"{temp_name}_{idcount}";
                    break;
                }
            }
        }
		

        // DI inject health system,and other systems here 

        Inventory main_inventory = new Inventory(); 
		Wallet wallet			 = new Wallet(0,1000);
		HealthSystem health		 = new HealthSystem();
        Player character         = new Player(name, main_inventory, wallet, health, null);
        players.Add(name,character); // spawn after creation 
        return character;
    }


}
