using StarterGame;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

public class CharacterCreator
{
    
    List<string> maleMinerNames = new List<string>
{
    "Thorin", "Doran", "Thrain", "Oin", "Bofur", "Dain", "Koth", "Sindri", "Fafnir", "Mimir",
    "Nordri", "Grendel", "Sigurd", "Odin", "Forseti", "Fenris", "Magne", "Moin", "Skuld", "Urd",
    "Bael", "Hagen", "Balin", "Ori", "Bombur", "Nain", "Magni", "Alvis", "Otur", "Galar",
    "Sudri", "Beowulf", "Hagred", "Vidar", "Njord", "Surtr", "Svafnir", "Graf", "Verd", "Mani",
    "Krag", "Vorn", "Gloin", "Dori", "Fili", "Modi", "Onar", "Hreid", "Fjalar", "Gandalf",
    "Vali", "Freyr", "Ofnir", "Grabak", "Vid", "Ur", "Ver", "Mani", "Gorm", "Durin",
    "Nori", "Kili", "Ryser", "Brokk", "Ivaldi", "Austri", "Gram", "Unferth", "Hermod", "Ymir",
    "Ulf", "Bram", "Fundin", "Bifur", "Dwalin", "Dax", "Eitri", "Regin", "Alberic", "Vestri",
    "Thror", "Hrothgar", "Tyr", "Hodur", "Baldur", "Thrud", "Goin", "Sol", "Kael", "Regin","Hagard"
};

    List<string> femaleMinerNames = new List<string>
{
    "Thora", "Lyra", "Freya", "Gerda", "Fulla", "Lofn", "Beyla", "Day", "Bestla", "Signy",
    "Hild", "Rota", "Skogul", "Mist", "Atla", "Jarn", "Fenja", "Heid", "Laufey", "Nal",
    "Sigrid", "Petra", "Idunn", "Ran", "Saga", "Var", "Bil", "Earth", "Borghild", "Sigrun",
    "Gondul", "Radgrid", "Herja", "Angeyja", "Greip", "Menja", "Rind", "Farbauti", "Vesper", "Etta",
    "Sif", "Hel", "Eir", "Vor", "Sol", "Jord", "Brynhild", "Svava", "Skogul", "Goll",
    "Eistla", "Gjalp", "Hyndla", "Skadi", "Baugi", "Helga", "Juno", "Frigg", "Nanna", "Hlin",
    "Syn", "Mani", "Rind", "Gudrun", "Olrun", "Hlokk", "Urd", "Alvitr", "Eyrgjafa", "Gerd",
    "Mara", "Zora", "Skadi", "Gefjun", "Gna", "Snotra", "Night", "Gunnlod", "Kriemhild", "Hervor",
    "Mist", "Verdandi", "Kara", "Grimhild", "Imd", "Bestla", "Gullveig", "Grid", "Hrim", "Suttung"

};

    List<string> minerLastNames = new List<string>
{
    "Aethros", "Vornhal", "Draeven", "Kaelith", "Morvain", "Tharros", "Velkyn", "Zereth", "Orvane", "Nyxar",
    "Helior", "Vaelun", "Rathen", "Solvyr", "Mythren", "Auron", "Valeth", "Dravyn", "Karneth", "Zorvain",
    "Eldros", "Thyrian", "Varkul", "Orren", "Maleth", "Caedryn", "Vorun", "Nerath", "Zareth", "Ulthar",
    "Baelros", "Virel", "Thalor", "Morren", "Avarn", "Kelvyr", "Dorneth", "Yorath", "Vaelor", "Orthex",
    "Zevran", "Karthos", "Velor", "Nyreth", "Arveth", "Droven", "Malrith", "Thorne", "Voss", "Graven",
    "Harrow", "Duskryn", "Veylor", "Ashryn", "Morveth", "Krevos", "Zalthor", "Orvain", "Velmorn", "Threx",
    "Drathen", "Vaul", "Korveth", "Nyros", "Zerath", "Aldren", "Vorath", "Kelros", "Thyros", "Moros",
    "Varn", "Eryndor", "Ulric", "Draeth", "Kaelor", "Vireth", "Zorin", "Malvor", "Ordrin", "Thalryn",
    "Vaelros", "Krynn", "Zerros", "Morvain", "Aethryn", "Velros", "Draemor", "Nyvar", "Korren", "Zalthyn"

};




    



    private int idcount = 0;
    private Dictionary<string, Player> players = new Dictionary<string, Player>();
    private Random rand = new Random();
    public CharacterCreator()
    {


    }

    // on each revolution of the parser, this updates all players/NPCs in the game 
    public void update()
    {
        foreach(var kv in players)
        {
            kv.Value.update();
        }
    }


    public Player createRandomPerson(string? name = null) // this is about 9,801(x2) per gender /  19,602 total combinations  99x99
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

            if (gender == 0)
            {
                selected_gender = maleMinerNames;
                name_roll = rand.Next(0, maleMinerNames.Count);
            }
            else
            {
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

        Inventory main_inventory        = new Inventory();
        Wallet wallet                   = new Wallet(0, 1000);
        HealthSystem health             = new HealthSystem();
        Player character                = new Player(name, main_inventory, wallet, health, null);
        players.Add(name, character); // spawn after creation 
        return character;
    }


}
