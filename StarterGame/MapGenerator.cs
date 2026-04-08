using StarterGame;
using System;
using System.CodeDom.Compiler;

public class MapGenerator
{

    private overworld = new Dictionary<string, Room>();
	public MapGenerator()
	{
	}


	public Room Generate()
	{

        Room outside            = new Room("the main entrance of the university", "outside");
        Room scctparking        = new Room("the parking lot at SCCT");
        Room boulevard          = new Room("the boulevard", "on");
        Room universityParking  = new Room("the parking lot at University Hall");
        Room parkingDeck        = new Room("the parking deck");
        Room scct               = new Room("the SCCT building");
        Room theGreen           = new Room("the green in from of Schuster Center");
        Room universityHall     = new Room("University Hall");
        Room schuster           = new Room("the Schuster Center");

        outside.SetExit("west", boulevard);

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




}
