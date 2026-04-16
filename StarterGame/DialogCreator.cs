using System;
using System.Collections.Generic;

public class DialogCreator
{


    var dialog = new Dictionary<string, Dictionary<string, List<string>>>()
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
            }
        },

        ["beggar"] = new Dictionary<string, List<string>>()
        {
            ["ask_gold"] = new List<string>()
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
            }

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
            }
             ["notenough"] = new List<string>()
            {
                "Would you like it back, you seem to not be doing so well youself…",
                "You’re no better than the others",
                "Cold… all of you.",
                "I curse you for this..."
            }
        },

        ["neutral"] = new Dictionary<string, List<string>>()
        {
            ["passing"] = new List<string>()
            {
                "You still breathing?",
                "Careful where you step.",
                "The tunnels shift again.",
                "Stay sharp.",
                "Not many make it this far."
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
                "Do you feel the rumbling in the stone.."
            }
        },

        ["greedy"] = new Dictionary<string, List<string>>()
        {
            ["trade"] = new List<string>()
            {
                "Coin first. Words later.",
                "Everything has a price.",
                "Pay, or move along.",
                "No coin, no answer.",
                "Your need is my profit."
            }
        },

        ["thief"] = new Dictionary<string, List<string>>()
        {
            ["taunt"] = new List<string>()
            {
                "Didn’t even feel that, did you?",
                "Check your pockets.",
                "Too slow.",
                "Eyes up next time.",
                "Easy mark."
            }
        }
    };





    public DialogCreator()
	{
	}


    public void MakeDialogSet()
    {

    }


}
