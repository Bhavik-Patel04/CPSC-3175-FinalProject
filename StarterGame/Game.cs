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


            MapGenerator gen        = new MapGenerator();
            Room start              = gen.Generate();



            _player                 = creator.createRandomPerson(); // main player 
            _player.SpawnWarp(start);
            _player.NormalMessage($"Ahh you have awken...{_player.name}");
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
            return "Welcome to the World of CSU!\n\n The World of CSU is a new, incredibly boring adventure game.\n\nType 'help' if you need help." + _player.CurrentRoom.Description();
        }

        public string Goodbye()
        {
            return "\nThank you for playing, Goodbye. \n";
        }

    }
}
