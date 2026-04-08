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

        public Game()
        {
            _playing = false;
            _parser = new Parser(new CommandWords());
            _player = new Player(CreateWorld());
        }

        // This creates a very simple world based 
        // on the landscape of Columbus State University
        public Room CreateWorld()
        {

            

            // outside west to bulivard
            //



            Room outside = new Room("the main entrance of the university", "outside");
            Room scctparking = new Room("the parking lot at SCCT");
            Room boulevard = new Room("the boulevard", "on");
            Room universityParking = new Room("the parking lot at University Hall");
            Room parkingDeck = new Room("the parking deck");
            Room scct = new Room("the SCCT building");
            Room theGreen = new Room("the green in from of Schuster Center");
            Room universityHall = new Room("University Hall");
            Room schuster = new Room("the Schuster Center");

            outside.SetExit("west", boulevard);
                 // link
            boulevard.SetExit("east", outside);
            boulevard.SetExit("south", scctparking);
            boulevard.SetExit("west", theGreen);
            boulevard.SetExit("north", universityParking);

            scctparking.SetExit("west", scct);
            scctparking.SetExit("north", boulevard);

            scct.SetExit("east", scctparking);
            scct.SetExit("north", schuster);

            schuster.SetExit("south", scct);
            schuster.SetExit("north", universityHall);
            schuster.SetExit("east", theGreen);

            theGreen.SetExit("west", schuster);
            theGreen.SetExit("east", boulevard);

            universityHall.SetExit("south", schuster);
            universityHall.SetExit("east", universityParking);

            universityParking.SetExit("south", boulevard);
            universityParking.SetExit("west", universityHall);
            universityParking.SetExit("north", parkingDeck);

            parkingDeck.SetExit("south", universityParking);

            return outside;
        }

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
