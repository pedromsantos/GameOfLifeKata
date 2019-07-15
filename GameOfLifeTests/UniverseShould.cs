using System.Collections.Generic;
using FluentAssertions;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class UniverseShould
    {
        [Fact]
        public void A_universe_with_three_neighbour_cells_keeps_all_cells_alive()
        {
            var seed = new Dictionary<Position, Cell>
            {
                {new Position(0,0), new LiveCell()},
                {new Position(0,1), new LiveCell()},
                {new Position(1,0), new LiveCell()},
            };

            var newUniverse = new Universe(seed).Tick();
            
            newUniverse.Should().Be(new Universe(seed));
        }
    }
}