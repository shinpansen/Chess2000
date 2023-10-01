using System.Net.Mime;
using Chess2000.BoardGame.Movements;
using Chess2000.BoardGame.Pieces.Visitors;
using Chess2000.BoardGame.Squares;

namespace Chess2000.BoardGame.Pieces.Chess;

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