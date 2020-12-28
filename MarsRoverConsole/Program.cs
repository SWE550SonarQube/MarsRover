using System;
using System.Collections.Generic;

namespace MarsRoverConsole
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine("Welcome to Mars Rover Interface *******------*********");
                Console.WriteLine("\n");
                Console.WriteLine("Please specify the limit of plateau");

                var plateauLimit = Console.ReadLine();
                var rovers = new List<Rover>();
                var proceed = true;
                while (proceed)
                {
                    var rover = new Rover(plateauLimit);

                    Console.WriteLine("Enter Rover's position");

                    var position = Console.ReadLine();

                    rover.SetCurrentPosition(position);

                    Console.WriteLine("Enter Rover's direction command");

                    var command = Console.ReadLine();

                    rover.SetCommand(command);

                    rovers.Add(rover);

                    Console.WriteLine("Please press S button to start discovery");

                    Console.WriteLine("Press N button to add new vehicle");

                    var keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.S)
                    {
                        proceed = false;
                    }

                    Console.Clear();
                }

                rovers.ForEach(rover => { Console.WriteLine("Current location of Rover: " + rover.CurrentPosition); });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}