using Chess2000.BoardGame.Rules.Chess;

namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class WhitePiece : ChessPiece
{
    public override bool IsFriend(ChessPieceVisitor visitor)
    {
        return visitor.Visit(this);
    }
}