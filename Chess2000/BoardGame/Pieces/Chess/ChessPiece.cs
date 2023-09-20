namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class ChessPiece : IPiece
{
    public abstract bool IsFriend(BlackPiece piece);
    public abstract bool IsFriend(WhitePiece piece);
    public abstract bool CanRock();
}