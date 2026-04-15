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

                    // death and restart screen 
                    if (!_player.health.isAlive())
                    {
                        _player.ErrorMessage("You have faild to reclaim yourself...");
                        _player.WarningMessage("press enter...");
                        string ok = Console.ReadLine();

                        // retart or respawn
                        if (!_player.health.useLife())              // decrement and check
                        {
                            // new game start here - generate new map
                            Room start          = mapGenerator.Generate();
                            _player             = creator.createRandomPerson();  
                            _player.SpawnWarp(start);
                        }
                        else
                        {
                            mapGenerator.GetRandomRoomByLevel(0);   // respawn at the bottom 
                            _player.health.respawn();               // respawn health to max health 
                        }
                    }



                    // main controller 
                    _player.NormalMessage("\n" + _player.CurrentRoom.Description());
                    Console.Write("\n>");
                    Command command = _parser.ParseCommand(Console.ReadLine());
                    Console.Clear();
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
            return $"Ahh... so you awaken once more, {_player.name}... drunk on more than just ale.\n" +
                   "Do you not feel it? The earth stirs beneath you. She whispers still.\n" +
                   "Far beyond these halls, the Mountain trembles — not with age, but with wrath.\n" +
                   "The paths above are choked... bound in the roots of the Abyss.\n" +
                   "Yet there are passages, hidden and half-forgotten — ways to where the old gods hoard their fading power.\n" +
                   "Carve your path through stone and shadow. The gods linger above.\n" +
                   "But heed this: let not the hunger below take hold of your soul.\n" +
                   "Seize what fate remains to you... or be buried with the rest.\n" +
                   "The tunnels shift. The deep closes in.\n" +
                   "Do not linger in doubt.\n" +
                   "Go forth.\n\n";
        }

        public string Goodbye()
        {
            return "\nThank you for playing, Goodbye. \n";
        }

    }
}
