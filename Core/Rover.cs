using Core.Enum;
using Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Rover : IRover
    {
        public Rover(IPosition position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }


        public IPosition Position { get; set; }
        public Direction Direction { get; set; }

        public void ExecuteCommand(Command command)
        {

            switch ((char)command)
            {
                case 'L':
                    Rotate(Direction,Rotation.Left);
                    break;
                case 'R':
                    Rotate(Direction, Rotation.Right);
                    break;
                case 'M':
                    Move(Position);
                    break;
            }
        }

        public Direction Rotate(Direction currentDirection, Rotation desiredRotation)
        {
            int degreeHeading = (int)currentDirection + (int)desiredRotation;

            currentDirection = (Direction)degreeHeading;
            if (degreeHeading < 0)
            {
                currentDirection = Direction.West;
            }

            if (degreeHeading > 270)
            {
                currentDirection = Direction.North;
            }
            this.Direction = currentDirection;
            return currentDirection;
        }

        public IPosition Move(IPosition currentPosition)
        {


            if (currentPosition == null)
            {
                return currentPosition;
            }
            var currentPoint = currentPosition.GetPoint();
            switch (this.Direction)
            {
                case Direction.North:
                    currentPoint.Y += 1;
                    break;
                case Direction.East:
                    currentPoint.X += 1;
                    break;
                case Direction.South:
                    currentPoint.Y -= 1;
                    break;
                case Direction.West:
                    currentPoint.X -= 1;
                    break;
            }
            currentPosition.SetPoint(currentPoint);
            this.Position = currentPosition;
            return currentPosition;
        }

        public void ExecuteCommands(string command)
        {
            for (int i = 0; i < command.Length; i++)
            {
                ExecuteCommand((Command)command[i]);
            }
        }


    }
}
