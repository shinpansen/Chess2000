using BoardGame.Movements;
using BoardGame.Pieces.Visitors;
using BoardGame.Squares;

namespace BoardGame.Pieces.Chess;

public abstract class WhitePiece : ChessPiece
{
    protected WhitePiece(ISquare square) : base(square)
    {
    }

    protected WhitePiece(ISquare square, IMovement lastMove) : base(square, lastMove)
    {
    }

    protected WhitePiece(string location) : base(location)
    {
    }

    public override bool Visit(BooleanPieceVisitor visitor)
    {
        return visitor.Visit(this);
    }
}