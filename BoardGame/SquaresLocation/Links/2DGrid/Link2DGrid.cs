namespace BoardGame.SquaresLocation.Links._2DGrid;

public class Link2DGrid : ISquareLink
{
    public bool Equals(ISquareLink other)
    {
        return other.ToString().Equals(this.ToString());
    }
}
