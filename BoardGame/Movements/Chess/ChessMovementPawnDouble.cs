using BoardGame.Pieces;
using BoardGame.Pieces.Chess;
using BoardGame.Squares;
using BoardGame.Squares.Chess;

namespace BoardGame.Movements.Chess;

public class ChessMovementPawnDouble : ChessMovementBase
{
    public ChessMovementPawnDouble(IPiece piece, ISquare target) : base(piece, target)
    {
    }
}