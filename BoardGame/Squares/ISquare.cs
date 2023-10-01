using BoardGame.Location;

namespace BoardGame.Squares;

public interface ISquare
{
    public ISquareLocation GetLocation();
}
