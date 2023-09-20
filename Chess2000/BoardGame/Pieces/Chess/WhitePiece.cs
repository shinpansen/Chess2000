namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class WhitePiece : ChessPiece
{
    public override bool IsFriend(BlackPiece piece) => false;
    public override bool IsFriend(WhitePiece piece) => true;
}