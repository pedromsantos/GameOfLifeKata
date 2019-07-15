namespace GameOfLife
{
    public class DeadCell : Cell
    {
        public override Cell Tick(Neighbours neighbours)
        {
            return neighbours.CountAlive() == 3 
                ? new LiveCell() as Cell 
                : this;
        }
    }
}