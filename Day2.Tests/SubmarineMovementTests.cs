using System;
using DomainLogic;
using NUnit.Framework;

namespace Day2.Tests
{
    [TestFixture]
    public class SubmarineMovementTests
    {
        [Test]
        [TestCase(5)]
        [TestCase(30)]
        [TestCase(20000)]
        public void WhenMovesForward_AddsToHorizontalPosition_TotalHorizontalPositionIncreasesByLength(int horizontalLength)
        {
            Submarine submarine = new Submarine();
            int expectedHorizontalPosition = submarine.Position.Horizontal + horizontalLength;
            submarine.Move(new MoveParameters(Direction.Forward, horizontalLength));

            Assert.That(submarine.Position.Horizontal, Is.EqualTo(expectedHorizontalPosition));
        }

        [Test]
        public void WhenAimIsZero_MovesForward_DepthDoesntChange()
        {
            Submarine submarine = new Submarine();
            int expectedVerticalPosition = submarine.Position.Vertical;
            submarine.Move(new MoveParameters(Direction.Forward, 5));

            Assert.That(submarine.Position.Vertical, Is.EqualTo(expectedVerticalPosition));
        }

        [Test]
        [TestCase(5)]
        public void WhenMovesDown_AimIsIncreased_TotalAimIsIncreasedByDownLength(int lengthDown)
        {
            Submarine submarine = new Submarine();
            int expectedAim = submarine.Position.Aim + lengthDown;
            submarine.Move(new MoveParameters(Direction.Down, lengthDown));

            Assert.That(submarine.Position.Aim, Is.EqualTo(expectedAim));
        }

        [Test]
        [TestCase(5)]
        public void WhenMovesUp_AimIsDecreased_TotalAimIsDecreasedByUpLength(int lengthUp)
        {
            Submarine submarine = new Submarine();
            submarine.Move(new MoveParameters(Direction.Forward, 5));
            submarine.Move(new MoveParameters(Direction.Down, 5));
            submarine.Move(new MoveParameters(Direction.Forward, 8));
            int expectedAim = submarine.Position.Aim - lengthUp;
            submarine.Move(new MoveParameters(Direction.Up, lengthUp));

            Assert.That(submarine.Position.Aim, Is.EqualTo(expectedAim));
        }

        [Test]
        public void WhenMovesForward_AimIsDown_VerticalAndHorizontalPositionsIncrease()
        {
            Submarine submarine = new Submarine();
            submarine.Move(new MoveParameters(Direction.Forward, 5));
            submarine.Move(new MoveParameters(Direction.Down, 5));
            int expectedHorizontalPosition = submarine.Position.Horizontal + 8;
            int expectedVerticalPosition = submarine.Position.Vertical + submarine.Position.Aim * 8;
            submarine.Move(new MoveParameters(Direction.Forward, 8));

            Assert.That(submarine.Position.Horizontal, Is.EqualTo(expectedHorizontalPosition));
            Assert.That(submarine.Position.Vertical, Is.EqualTo(expectedVerticalPosition));
        }

        [Test]
        public void test()
        {
            Submarine submarine = new Submarine();
            submarine.Move(new MoveParameters(Direction.Forward, 5));
            submarine.Move(new MoveParameters(Direction.Down, 5));
            submarine.Move(new MoveParameters(Direction.Forward, 8));
            submarine.Move(new MoveParameters(Direction.Up, 3));
            submarine.Move(new MoveParameters(Direction.Down, 8));
            submarine.Move(new MoveParameters(Direction.Forward, 2));

            Assert.That(submarine.Position.Vertical, Is.EqualTo(60));
        }
    }

    
}
