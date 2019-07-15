using FluentAssertions;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class PositionShould
    {
        private readonly Position _position;

        public PositionShould()
        {
            _position = new Position(3,3);
        }

        [Fact]
        public void CalculatePositionToTheLeft()
        {
            var newPosition = _position.Left();

            newPosition.Should().Be(new Position(2, 3));
        }
        
        [Fact]
        public void CalculatePositionToTheRight()
        {
            var newPosition = _position.Right();

            newPosition.Should().Be(new Position(4, 3));
        }
        
        [Fact]
        public void CalculatePositionAbove()
        {
            var newPosition = _position.Above();

            newPosition.Should().Be(new Position(3, 2));
        }
        
        [Fact]
        public void CalculatePositionAboveLeft()
        {
            var newPosition = _position.AboveLeft();

            newPosition.Should().Be(new Position(2, 2));
        }
        
        [Fact]
        public void CalculatePositionAboveRight()
        {
            var newPosition = _position.AboveRight();

            newPosition.Should().Be(new Position(4, 2));
        }
        
        [Fact]
        public void CalculatePositionBellow()
        {
            var newPosition = _position.Bellow();

            newPosition.Should().Be(new Position(3, 4));
        }
        
        [Fact]
        public void CalculatePositionBellowLeft()
        {
            var newPosition = _position.BellowLeft();

            newPosition.Should().Be(new Position(2, 4));
        }
        
        [Fact]
        public void CalculatePositionBellowRight()
        {
            var newPosition = _position.BellowRight();

            newPosition.Should().Be(new Position(4, 4));
        }
    }
}