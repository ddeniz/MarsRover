using Core;
using Core.Helper;
using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("X,y example input 5 5");
            Console.WriteLine("Plateau :");

            var sizeInput = Console.ReadLine();
            Plateau plateau = ParserHelper.ParsePlateau(sizeInput);

            while (true)
            {
                Console.WriteLine("Directions (N,S,W,E) example input 1 2 N");
                Console.WriteLine("Position :");
            
                string possitionİnput = Console.ReadLine();

                Console.WriteLine("Commands (R,L,M) example input LMLMLMLMM");
                Console.WriteLine("Command :");
                
                var roverCommandInput = Console.ReadLine();

                Direction direction = ParserHelper.ParseDirection(possitionİnput);
                Point point = ParserHelper.ParsePoint(possitionİnput);
                
                Position currentpostion = new Position(point, plateau);                
                Rover rover = new Rover(currentpostion, direction);
                rover.ExecuteCommands(roverCommandInput.ToUpper());

                Console.WriteLine($"Value:{rover.Position.GetPoint().X} {rover.Position.GetPoint().Y} {rover.Direction.ToString()[0]}");
                
                Console.WriteLine("Do you want to add another rover ? (Y/N)");

                var addRoverInput = Console.ReadLine();

                if (!addRoverInput.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
            }

        }




    }
}
