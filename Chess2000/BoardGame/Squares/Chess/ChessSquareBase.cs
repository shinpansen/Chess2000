using Chess2000.BoardGame.Pieces.Chess;
using Microsoft.Xna.Framework;

namespace Chess2000.BoardGame.Squares.Chess;

public class ChessSquareBase : ChessSquare
{
    public ChessSquareBase(ChessSquareLocation location) : base(location)
    {
    }

    public ChessSquareBase(ChessSquareLocation location, ChessPiece piece) : base(location, piece)
    {
    }
}