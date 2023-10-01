using Chess2000.BoardGame.Location;

namespace Chess2000.BoardGame.Squares;

public interface ISquare
{
    public ISquareLocation GetLocation();
}
