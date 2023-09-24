using System;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Rules.Chess;

namespace Chess2000.BoardGame.Pieces.Chess;

public abstract class ChessPiece : IPiece
{
    public abstract bool IsFriend(ChessPieceColorVisitor piece);
    public abstract bool CanRock();

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}