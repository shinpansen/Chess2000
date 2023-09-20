using System.Net.Mime;

namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class BlackPiece : ChessPiece
{
    public override bool IsFriend(BlackPiece piece) => true;
    public override bool IsFriend(WhitePiece piece) => false;
}