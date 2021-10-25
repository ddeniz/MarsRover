using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper
{
    public static class ParserHelper
    {
        public static Plateau ParsePlateau(string sizeInput)
        {
            Plateau plateau = null;
            if (!string.IsNullOrWhiteSpace(sizeInput))
            {
                var gridSize = sizeInput.Split(' ');

                if (gridSize.Length == 2)
                {
                    if (int.TryParse(gridSize[0], out int maxX))
                    {
                        if (int.TryParse(gridSize[1], out int maxY))
                        {
                            plateau = new Plateau(maxX, maxY);
                        }
                    }
                }
            }
            return plateau;
        }

        public static Direction ParseDirection(string roverPositionInput)
        {
            var roverPositionArray = roverPositionInput.Split(' ');

            if (roverPositionArray.Length == 3)
            {
                string direction = roverPositionArray[2].ToUpper();


                switch (direction)
                {
                    case "N":
                        return Direction.North;
                    case "S":
                        return Direction.South;
                    case "W":
                        return Direction.West;
                    case "E":
                        return Direction.East;
                    default:
                        break;
                }
            }

            return Direction.North;
        }

        public static Point ParsePoint(string roverPositionInput)
        {
            var roverPositionArray = roverPositionInput.Split(' ');

            if (roverPositionArray.Length == 3)
            {
                return new Point(int.Parse(roverPositionArray[0]), int.Parse(roverPositionArray[1]));
            }

            return null;
        }
    }
}
