using System.Net.Mime;
using BoardGame.Movements;
using BoardGame.Pieces.Visitors;
using BoardGame.Squares;

namespace BoardGame.Pieces.Chess;

public abstract class BlackPiece : ChessPiece
{
    protected BlackPiece(ISquare square) : base(square)
    {
    }

    protected BlackPiece(ISquare square, IMovement lastMove) : base(square, lastMove)
    {
    }

    protected BlackPiece(string location) : base(location)
    {
    }

    public override bool Visit(BooleanPieceVisitor visitor)
    {
        return visitor.Visit(this);
    }
}