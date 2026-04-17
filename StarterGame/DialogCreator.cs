using System;
using System.Collections.Generic;

public class DialogCreator
{


    private Dictionary<string, Dictionary<string, List<string>>> dialog = new Dictionary<string, Dictionary<string, List<string>>>()
    {
        ["hostile"] = new Dictionary<string, List<string>>()
        {
            ["generic"] = new List<string>()
            {
                "Out of my way.",
                "Piss off, wretch.",
                "Keep your distance.",
                "You're not worth the breath.",
                "Try me, and see how it ends.",
                "I've buried better than you.",
                "Walk away while you still can.",
                "I’m not the one to beg from.",
                "Another word and you’ll regret it.",
                "Don’t test me.",
                "You looking for a fight, begon!",
            },
            ["theft"] = new List<string>()
            {
                "Didn’t even feel that, did you?",
                "Check your pockets.",
                "Too slow.",
                "Eyes up next time.",
                "Easy mark."
            }


        },

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
            ["thanks"] = new List<string>()
            {
                "May the gods favor your journy...",
                "Thank you.. Please do business with me again.",
                "May the stone shelter you and weather you from the storm of the gods",
                "Appricate the gold",
                "Anything else?...",
            },

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
            ["rejected"] = new List<string>()
            {
                "Then leave me to rot…",
                "You’re no better than the rest.",
                "Cold… all of you."
            },
            ["notenough"] = new List<string>()
            {
                "Would you like it back, you seem to not be doing so well youself…",
                "You’re no better than the others",
                "Cold… all of you.",
                "I curse you for this...",
                "What am I to do with this, piss on it...",
                "The gods see you... They know your character...",
                ".. * mumble *.. * mumble *.. chanting..",
                "Wicked is the world..."
            },
            ["theft"] = new List<string>()
            {
                "Didn’t even feel that, did you?",
                "Check your pockets...",
                "Too slow!, Keep up!",
                "Eyes up next time, sucker!",
                "Easy mark!",
                "Better luck nextime...",
                "Got it..."
            }
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
            }
        },

        ["cryptic"] = new Dictionary<string, List<string>>()
        {
            ["warning"] = new List<string>()
            {
                "The deep remembers.",
                "Not all paths lead upward.",
                "You’ve been marked.",
                "The stone listens.",
                "Light fades quickly here.",
                "Look up.. On occasion..",
                "Do you feel the rumbling in the stone..",
                "Ahead my son..."
            }
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
            return tmp;
        }
        tmp.Add(new SpeakTo(dialog["neutral"]));
        return tmp;
    }


}
