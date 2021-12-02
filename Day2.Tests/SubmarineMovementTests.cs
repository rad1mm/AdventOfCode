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
            MoveParameters newMove = new MoveParameters(Direction.Forward, horizontalLength);
            submarine.Move(newMove);

            Assert.That(submarine.Position.Horizontal, Is.EqualTo(expectedHorizontalPosition));
        }
    }
}
