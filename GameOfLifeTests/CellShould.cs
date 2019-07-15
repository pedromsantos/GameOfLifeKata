using FluentAssertions;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class CellShould
    {
        private readonly LiveCell _cell;
        private readonly Neighbours _neighbours;

        public CellShould()
        {
            _cell = new LiveCell();
            _neighbours = new Neighbours();
        }

        [Fact]
        public void die_with_fewer_than_two_live_neighbours_by_under_population()
        {
            _neighbours.Add(new LiveCell())
                .Add(new DeadCell())
                .Add(new DeadCell());

            var newCell = _cell.Tick(_neighbours);

            newCell.Should().BeOfType<DeadCell>();
        }
        
        [Fact]
        public void die_with_more_than_three_live_neighbours_by_over_population()
        {
            _neighbours.Add(new LiveCell())
                .Add(new LiveCell())
                .Add(new LiveCell())
                .Add(new LiveCell());

            var newCell = _cell.Tick(_neighbours);

            newCell.Should().BeOfType<DeadCell>();
        }
        
        [Fact]
        public void stay_alive_with_two_or_three_live_neighbours()
        {
            _neighbours.Add(new LiveCell())
                .Add(new LiveCell())
                .Add(new LiveCell());

            var newCell = _cell.Tick(_neighbours);

            newCell.Should().BeOfType<LiveCell>();
        }
        
        [Fact]
        public void revive_a_dead_cell_with_exactly_three_live_neighbours()
        {
            var cell = new DeadCell();
            _neighbours.Add(new LiveCell())
                .Add(new LiveCell())
                .Add(new LiveCell());

            var newCell = cell.Tick(_neighbours);

            newCell.Should().BeOfType<LiveCell>();
        }
    }
}
