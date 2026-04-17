using System.Collections;
using System.Collections.Generic;

namespace StarterGame
{
    /*
     * Fall 2025
     */
    public class HelpCommand : Command
    {
        private CommandWords _words;

        public HelpCommand() : this(new CommandWords()){}

        // Designated Constructor
        public HelpCommand(CommandWords commands) : base()
        {
            _words = commands;
            this.Name = "help";
        }

        override
        public bool Execute(Player player)
        {
            if (this.HasSecondWord())
            {
                player.messenger.WarningMessage("\nI cannot help you with " + this.SecondWord);
            }
            else
            {
                player.messenger.InfoMessage("\nYou are lost. You are alone. You wander around the university, \n\nYour available commands are " + _words.Description());
            }
            return false;
        }
    }
}
