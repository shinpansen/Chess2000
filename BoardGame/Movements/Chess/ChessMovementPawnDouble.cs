using BoardGame.Pieces;
using BoardGame.Pieces.Chess;
using BoardGame.Squares;
using BoardGame.Squares.Chess;

namespace BoardGame.Movements.Chess;

public class ChessMovementPawnDouble : ChessMovementBase, IChessMovementPawnDouble
{
    public ChessMovementPawnDouble(IPiece piece, ISquare target) : base(piece, target)
    {
    }

    public override bool Equals(IMovement? other)
    {
        if (other is not ChessMovementPawnDouble otherMovement) return false;
        return otherMovement.Piece.Equals(this.Piece) &&
            otherMovement.Target.GetLocation().Equals(this.Target.GetLocation());
    }
}