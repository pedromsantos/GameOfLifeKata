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
            _position.Left().Should().Be(new Position(2, 3));
        }
        
        [Fact]
        public void CalculatePositionToTheRight()
        {
            _position.Right().Should().Be(new Position(4, 3));
        }
        
        [Fact]
        public void CalculatePositionAbove()
        {
            _position.Above().Should().Be(new Position(3, 2));
        }
        
        [Fact]
        public void CalculatePositionAboveLeft()
        {
            _position.AboveLeft().Should().Be(new Position(2, 2));
        }
        
        [Fact]
        public void CalculatePositionAboveRight()
        {
            _position.AboveRight().Should().Be(new Position(4, 2));
        }
        
        [Fact]
        public void CalculatePositionBellow()
        {
            _position.Bellow().Should().Be(new Position(3, 4));
        }
        
        [Fact]
        public void CalculatePositionBellowLeft()
        {
            _position.BellowLeft().Should().Be(new Position(2, 4));
        }
        
        [Fact]
        public void CalculatePositionBellowRight()
        {
            _position.BellowRight().Should().Be(new Position(4, 4));
        }
    }
}