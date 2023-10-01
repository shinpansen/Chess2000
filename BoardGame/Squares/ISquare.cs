using BoardGame.SquaresLocation;

namespace BoardGame.Squares;

public interface ISquare
{
    public ISquareLocation GetLocation();
}
