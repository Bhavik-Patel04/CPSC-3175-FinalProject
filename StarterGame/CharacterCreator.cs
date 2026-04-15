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
    "Sudri", "Beowulf", "Fafnir", "Vidar", "Njord", "Surtr", "Svafnir", "Graf", "Verd", "Mani",
    "Krag", "Vorn", "Gloin", "Dori", "Fili", "Modi", "Onar", "Hreid", "Fjalar", "Gandalf",
    "Vali", "Freyr", "Ofnir", "Grabak", "Vid", "Ur", "Ver", "Mani", "Gorm", "Durin",
    "Nori", "Kili", "Ryser", "Brokk", "Ivaldi", "Austri", "Gram", "Unferth", "Hermod", "Ymir",
    "Ulf", "Bram", "Fundin", "Bifur", "Dwalin", "Dax", "Eitri", "Regin", "Alberic", "Vestri",
    "Thror", "Hrothgar", "Tyr", "Hodur", "Baldur", "Thrud", "Goin", "Sol", "Kael", "Regin"
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
    "Sunforge", "Aethergrip", "Goldbrow", "Starshaft", "Lightstrider", "Highshale", "Dawnbreaker", "Skyquarry", "Cloudminer", "Halohewer",
    "Hellvein", "Soulbound", "Cinderheart", "Abysswalker", "Voiddigger", "Gravecoal", "Nightmantle", "Pitshaper", "Fireshield", "Demonbane",
    "Ironfoot", "Stonecutter", "Blackwood", "Steelbound", "Hardy", "Hammerhand", "Rockbearer", "Anvilback", "Deepdwell", "Mountainborn",
    "Gloryvein", "Saintstone", "Angelpick", "Puregold", "Brightbeam", "Solarshard", "Zenithelm", "Radiantrun", "Ethervein", "Holyhollow",
    "Shadowstitch", "Dreadmine", "Terrorgrin", "Darkdepth", "Bottomless", "Brimstone", "Sulfurbreath", "Obsidian", "Magmaflow", "Ashwalker",
    "Earthshaker", "Coreblessed", "Gemseeker", "Oreheaver", "Tunnelking", "Cavecrawl", "Slatecraft", "Flinteye", "Gravelgut", "Dustlung",
    "Seraphim", "Divinebit", "Celestiam", "Arkstone", "Gracefull", "Purity", "Lumina", "Aurum", "Gilded", "Resplendent",
    "Bonecrush", "Cryptic", "Underworld", "Hadesgate", "Styxwater", "Tartarus", "Infernal", "Perdition", "Damnation", "Eternal",
    "Veinvigil", "Shaftmaster", "Lowland", "Hollowman", "Bedrock", "Tecton", "Richter", "Seismic", "Tremor", "Faultline"

};


    private int idcount = 0;
    private Dictionary<string, Player> players = new Dictionary<string, Player>();
    private Random rand = new Random();
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

        Inventory main_inventory = new Inventory();
        Wallet wallet = new Wallet(0, 1000);
        HealthSystem health = new HealthSystem();
        Player character = new Player(name, main_inventory, wallet, health, null);
        players.Add(name, character); // spawn after creation 
        return character;
    }


}