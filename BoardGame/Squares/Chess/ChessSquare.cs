using Chess2000.BoardGame.Location;
using Chess2000.BoardGame.Location.Chess;

namespace Chess2000.BoardGame.Squares.Chess;

public class ChessSquare : ISquare
{
    private ISquareLocation _location { get; set; }
    
    public ChessSquare(ChessSquareLocation location)
    {
        _location = location;
    }

    public ISquareLocation GetLocation()
    {
        return _location;
    }
}
