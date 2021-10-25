using Core;
using Core.Enum;
using NUnit.Framework;
using System;

namespace MarsRover.Test
{
    public class MarsRoverTests
    {

        [Test]
        [TestCase(5, 5, 5, 6)]
        [TestCase(5, 5, 8, 3)]
        [TestCase(5, 5, 9, 9)]
        public void Position_WhenPointNotValid_GivesError(int maxX, int maxY, int positionX, int positionY)
        {
            Plateau plateau = new Plateau(maxX, maxY);
            Assert.Throws<IndexOutOfRangeException>(() => { new Position(new Point(positionX, positionY), plateau); });
        }


        [Test]
        [TestCase(5, 5, 3, 3, 6, 3)]
        [TestCase(5, 5, 3, 3, 3, 6)]
        [TestCase(5, 5, 3, 3, 6, 6)]
        public void PositionSetPoint_WhenPointNotValid_False(int maxX, int maxY, int positionX, int positionY, int newPositionX, int newPositionY)
        {
            Plateau plateau = new Plateau(maxX, maxY);
            Position position = new Position(new Point(positionX, positionY), plateau);
            Assert.IsFalse(position.SetPoint(new Point(newPositionX, newPositionY)));
        }

        [Test]
        [TestCase(5, 5, 3, 3, 1, 1)]
        [TestCase(5, 5, 3, 3, 3, 4)]
        [TestCase(5, 5, 3, 3, 2, 3)]
        public void PositionSetPoint_WhenPointValid_True(int maxX, int maxY, int positionX, int positionY, int newPositionX, int newPositionY)
        {
            Plateau plateau = new Plateau(maxX, maxY);
            Position position = new Position(new Point(positionX, positionY), plateau);
            Assert.IsTrue(position.SetPoint(new Point(newPositionX, newPositionY)));
        }

        [Test]
        [TestCase(Direction.North, Rotation.Left, Direction.West)]
        [TestCase(Direction.North, Rotation.Right, Direction.East)]
        [TestCase(Direction.West, Rotation.Left, Direction.South)]
        [TestCase(Direction.West, Rotation.Right, Direction.North)]
        [TestCase(Direction.South, Rotation.Left, Direction.East)]
        [TestCase(Direction.South, Rotation.Right, Direction.West)]
        [TestCase(Direction.East, Rotation.Left, Direction.North)]
        [TestCase(Direction.East, Rotation.Right, Direction.South)]
        public void RoverRotate_WhenValidData_RotateCorrectly(Direction direction, Rotation rotation, Direction expectedOutput)
        {
            Plateau plateau = new Plateau(5, 5);
            Position currentpostion = new Position(new Point(3, 3), plateau);
            Rover rover = new Rover(currentpostion, direction);
            Assert.AreEqual(rover.Rotate(direction, rotation), expectedOutput);
        }

        [Test]
        [TestCase(5, 5, 1, 2, Direction.North, 1, 3)]
        [TestCase(5, 5, 1, 2, Direction.South, 1, 1)]
        [TestCase(5, 5, 1, 2, Direction.West, 0, 2)]
        [TestCase(5, 5, 1, 2, Direction.East, 2, 2)]
        public void RoverMove_WhenValidData_RotateCorrectly(int maxX, int maxY, int positionX, int positionY, Direction direction, int expectedPositionX, int expectedPositionY)
        {
            Plateau plateau = new Plateau(maxX, maxY);
            Position currentpostion = new Position(new Point(positionX, positionY), plateau);
            Rover rover = new Rover(currentpostion, direction);
            rover.Move(currentpostion);
            Assert.AreEqual(rover.Position.GetPoint().X, expectedPositionX);
            Assert.AreEqual(rover.Position.GetPoint().Y, expectedPositionY);
        }


        [Test]
        [TestCase(5, 5, 1, 2, Direction.North, "LMLMLMLMM", "1 3 N")]
        [TestCase(5, 5, 3, 3, Direction.East, "MMRMMRMRRM", "5 1 E")]
        public void RoverExecuteCommands_WhenValidData_ExecuteCorrectly(int maxX, int maxY, int positionX, int positionY, Direction direction, string commends, string expectedOutput)
        {
            Plateau plateau = new Plateau(maxX, maxY);
            Position currentpostion = new Position(new Point(positionX, positionY), plateau);
            Rover rover = new Rover(currentpostion, direction);
            rover.ExecuteCommands(commends);
            var actualOutput = $"{rover.Position.GetPoint().X} {rover.Position.GetPoint().Y} {rover.Direction.ToString()[0]}";
            Assert.AreEqual(expectedOutput, actualOutput);
        }



    }
}