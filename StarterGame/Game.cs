using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace StarterGame
{
    /*
     * Spring 2026
     */
    public class Game
    {
        private Player              _player;
        private Parser              _parser;
        private bool                _playing;
        private MapGenerator        mapGenerator;
        private CharacterCreator    creator;
        public Game()
        {
            _playing                = false;
            mapGenerator            = new MapGenerator();
            _parser                 = new Parser(new CommandWords());
            creator                 = new CharacterCreator();


            // generate map and insert player into it
            Room start              = mapGenerator.Generate();
            _player                 = creator.createRandomPerson(); // main player 
            _player.SpawnWarp(start);
            
        }




        public void Play()
        {

            // Enter the main command loop.  Here we repeatedly read commands and
            // execute them until the game is over.
            if(_playing)
            {
                bool finished = false;
                while (!finished)
                {
                    
                    creator.update(); // internal updater for players 


                    if (!_player.health.isAlive())
                    {
                        // draw death screen 
                        _player.ErrorMessage("You have faild...");
                        _player.WarningMessage("press any key and enter...");
                        string ok = Console.ReadLine();

                        // retart or respawn
                        if (!_player.health.hasLives())
                        {
                            // new game start here - generate new map
                            Room start          = mapGenerator.Generate();
                            _player             = creator.createRandomPerson();  
                            _player.SpawnWarp(start);
                        }
                        else
                        {
                            // respawn here 
                            mapGenerator.GetRandomRoomByLevel(0); // respawn at the bottom 
                        }

                    }
                    // main controller 
                    Console.Write("\n>");
                    Command command = _parser.ParseCommand(Console.ReadLine());
                    if (command == null)
                    {
                        _player.ErrorMessage("I don't understand...");
                    }
                    else
                    {
                        finished = command.Execute(_player);
                    }
                }
            }

        }


        public void Start()
        {
            _playing = true;
            _player.InfoMessage(Welcome());
        }

        public void End()
        {
            _playing = false;
            _player.InfoMessage(Goodbye());
        }

  

        public string Welcome()
        {
            return $"Ahh, so you have awaken.. Drunken again, {_player.name}...\n"+
                   "Do you not feel the Earth? Do you not hear her word?\n"+
                   "The Mountain shakes with wrath and anger in the great distance and in the Heavens.\n" +
                   "The paths to the Heavens are tangled with the roots of the Abyss,\n"+
                   "Ive heard tale of passages to above, to where the olds gods covet their powers.\n" +
                   "Forge you way through the mountain. The gods lay above.\n" +
                   "Do not let the hunger of the deep claim your soul.\n"+
                   "Claim your desteny with the gods... \n"+
                   "Ye may never get another chance.\n"+
                   "The passages to the old tunnels are shifting around you.. \n"+
                   "as you ponder the meaning to your own questions... Go forth! "+
                   "\n"+"\n"+
                   _player.CurrentRoom.Description();
        }

        public string Goodbye()
        {
            return "\nThank you for playing, Goodbye. \n";
        }

    }
}
