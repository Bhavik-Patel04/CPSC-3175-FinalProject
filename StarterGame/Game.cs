using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    /*
     * Spring 2026
     */
    public class Game
    {
        private Player _player;
        private Parser _parser;
        private bool _playing;
        private MapGenerator mapGenerator;
        public Game()
        {
            _playing        = false;
            mapGenerator    = new MapGenerator();
            _parser         = new Parser(new CommandWords());
            MapGenerator gen = new MapGenerator();
            Room start = gen.Generate(100);

            MapDebugger.PrintAll(start);

            _player         = new Player(start);
        }

        // This creates a very simple world based 
        // on the landscape of Columbus State University

    /**
     *  Main play routine.  Loops until end of play.
     *  Although this is a basic Game Loop Design pattern
     *  you may not count it as one of your design
     *  patterns in the final project.
     */
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
