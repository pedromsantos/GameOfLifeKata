namespace GameOfLife
{
    public abstract class Cell
    {
        public abstract Cell Tick(Neighbours neighbours);
    }
}