using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Pieces.Visitors;
using Chess2000.BoardGame.Squares;

namespace Chess2000.BoardGame.Pieces.Chess;

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