using System.Net.Mime;
using Chess2000.BoardGame.Data;
using Chess2000.BoardGame.Location.Chess;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class BlackPiece : ChessPiece
{
    protected BlackPiece(ISquare square) : base(square)
    {
    }

    protected BlackPiece(ISquare square, IData data) : base(square, data)
    {
    }

    protected BlackPiece(string location) : base(location)
    {
    }

    public override IData Visit(PiecesVisitor visitor)
    {
        return visitor.Visit(this);
    }
}