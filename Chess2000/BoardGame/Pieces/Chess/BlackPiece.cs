using System.Net.Mime;
using Chess2000.BoardGame.Rules.Chess;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class BlackPiece : ChessPiece
{
    protected BlackPiece(ISquare square) : base(square)
    {
    }
    
    public override bool IsFriend(ChessPieceColorVisitor visitor)
    {
        return visitor.Visit(this);
    }
}