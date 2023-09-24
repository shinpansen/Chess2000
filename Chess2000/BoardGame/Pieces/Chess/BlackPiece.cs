using System.Net.Mime;
using Chess2000.BoardGame.Rules.Chess;

namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class BlackPiece : ChessPiece
{
    public override bool IsFriend(ChessPieceColorVisitor visitor)
    {
        return visitor.Visit(this);
    }
}