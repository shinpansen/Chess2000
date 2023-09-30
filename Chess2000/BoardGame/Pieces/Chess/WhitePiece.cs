using Chess2000.BoardGame.Data;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class WhitePiece : ChessPiece
{
    protected WhitePiece(ISquare square) : base(square)
    {
    }

    protected WhitePiece(ISquare square, IData data) : base(square, data)
    {
    }

    protected WhitePiece(string location) : base(location)
    {
    }

    public override IData Visit(PiecesVisitor visitor)
    {
        return visitor.Visit(this);
    }
}