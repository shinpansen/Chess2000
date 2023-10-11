using BoardGame.SquaresLocation;
using BoardGame.SquaresLocation.Chess;

namespace BoardGame.Squares.Chess;

public class ChessSquare : ISquare
{
    private ISquareLocation _location;
    
    public ChessSquare(ChessSquareLocation location)
    {
        _location = location;
    }

    public ISquareLocation GetLocation()
    {
        return _location;
    }

    public override string ToString()
    {
        return _location.ToString() ?? string.Empty;
    }
}
