namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class ChessPiece : IPiece
{
    public bool IsFriend(ChessPiece piece)
    {
        if (piece.GetType() == typeof(BlackPiece))
            return IsFriend((BlackPiece)piece);
        return IsFriend((WhitePiece)piece);
    }
    public abstract bool IsFriend(BlackPiece piece);
    public abstract bool IsFriend(WhitePiece piece);
    public abstract bool CanRock();
}