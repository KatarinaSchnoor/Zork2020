using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork2020
{
    class Program
    {
        static void Main( string[] args )
        {
            World world = new World();
            
            //Telling where it is and aren't possible to go

            Console.WriteLine("Welcome to Zorkish 2020!");

            
            //Checking for commands from the player
            while ( true )
            {
                Console.WriteLine("You are in: " + world.currentArea.name);
                Console.WriteLine("Enter a command: go / examine / quit");

                string command = Console.ReadLine();

                //now it is possible to enter to commands at one, where it is put in an array (example go north)
                string[] commands = command.Split(' ');

                //Checking for the first part of the array
                switch ( commands[0] )
                {
                    case "go":

                        //if they haven't put in a direction

                        string dir;

                        if ( commands.Length < 2 )
                        {
                            //need to know in which direction we want to go, and if it is possible
                            Console.WriteLine("Please enter which direction you want to go in");
                            Console.WriteLine("The possible ways to go are: north (n), south (s), east(e), and west (w)");
                            dir = Console.ReadLine();
                        }
                        else
                        {
                            dir = commands[1];
                        }
                        
                        bool succes = false;

                        switch ( dir )
                        {
                            case "east":
                            case "e":
                                succes = world.Go(Directions.East);
                                
                                break;

                            case "west":
                            case "w":
                                succes = world.Go(Directions.West);

                                break;

                            case "north":
                            case "n":
                                succes = world.Go(Directions.North);

                                break;

                            case "south":
                            case "s":
                                succes = world.Go(Directions.South);

                                break;

                            default:
                                Console.WriteLine("I'm sorry, I didn't understand");
                                break;
                        }

                        if ( !succes )
                        {
                            Console.WriteLine("Sorry you cannot move in that direction");
                        }

                        //try to "Go" in that direction

                        break;

                    case "examine":

                        Console.WriteLine(world.currentArea.description);
                        break;

                    case "quit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("I'm sorry, I didn't understand");
                        break;
                }
            }

        }
    }
}
