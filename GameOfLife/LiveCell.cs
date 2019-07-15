namespace GameOfLife
{
    public class LiveCell : Cell
    {
        public override Cell Tick(Neighbours neighbours)
        {
            var aliveNeighbours = neighbours.CountAlive();
            
            return aliveNeighbours < 2 || aliveNeighbours > 3 
                ? new DeadCell() as Cell
                : this;
        }
    }
}