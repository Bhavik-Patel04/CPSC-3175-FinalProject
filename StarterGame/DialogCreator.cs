using System;
using System.Collections.Generic;

public class DialogCreator
{


    private Dictionary<string, Dictionary<string, List<string>>> dialog = new Dictionary<string, Dictionary<string, List<string>>>()
    {


        ["merchant"] = new Dictionary<string, List<string>>()
        {
            ["generic"] = new List<string>()
            {
                "I have items, if you have coin...",
                "Psst.. I havesomthing for you...",
                "I have goods if you have the gold for it...",
                "Will trade for gold...",
                "Gold is the only price for my items...",
                "Ye who walk alone, do ye need previsions?..."
               
            },
            ["trade"] = new List<string>()
            {
                "Yes, spend, spend , buy ,buy..",
                "See anything you like?",
                "You may need that...",
                "I have the best goods on the market!",
                "Anything?",
                "Pick your poison..."
            },
            ["notrade"] = new List<string>()
            {
                "Try again later, im fresh out...",
                "Business has been good.. but not for you..."
            },
            ["thanks"] = new List<string>()
            {
                "Come again...",
                "Thank You for you business...",
                "May the stone shelter you from the gods..."
            }

        },

        ["beggar"] = new Dictionary<string, List<string>>()
        {
            ["generic"] = new List<string>()
            {
                "Spare a bit of coin?",
                "I’ve nothing left… help me.",
                "Just a scrap will do.",
                "I won’t forget your kindness.",
                "Please… I’m fading here.",
                "A single coin, that’s all.",
                "You look like one who’s survived… share it.",
                "I’ve walked too far to die here.",
                "Anything… I’ll take anything.",
                "Help me endure a little longer."
            },

            ["thanks"] = new List<string>()
            {
                "You have my thanks.",
                "I won’t forget you charity",
                "May the stone shelter you and weather you from the storm of the gods"
            },
            
        },

        ["neutral"] = new Dictionary<string, List<string>>()
        {
            ["generic"] = new List<string>()
            {
                "You still breathing?",
                "Careful where you step.",
                "The tunnels shift again.",
                "Stay sharp.",
                "Not many make it this far."
            },
            ["trade"] = new List<string>()
            {
                "Coin first. Words later.",
                "Everything has a price.",
                "No coin, no answer.",
                "Your need is my profit."
            },
             ["notrade"] = new List<string>()
            {
                "Some other time..",
                "I have nothing to my name...",
                "No thanks, i dont wish to trade my possesions...",
                "I'll take the gold, but I have nothing...",
                "Id rather have a job..."
            },

        },


       
    };



    public List<Speak> MakeDialogSet(string character_type)
    {
        List<Speak> tmp = new List<Speak>();
        if (character_type == "beggar")
        {
            tmp.Add(new SpeakTo(dialog["beggar"]));
            return tmp;
        }

        if (character_type == "merchant")
        {
            tmp.Add(new SpeakTo(dialog["merchant"]));
            tmp.Add(new SpeakTrade(dialog["merchant"]));
            return tmp;
        }

        if (character_type == "person")
        {
            tmp.Add(new SpeakTo(dialog["neutral"]));
            tmp.Add(new SpeakTrade(dialog["neutral"]));
            return tmp;
        }
        tmp.Add(new SpeakTo(dialog["neutral"]));
        return tmp;
    }


}
