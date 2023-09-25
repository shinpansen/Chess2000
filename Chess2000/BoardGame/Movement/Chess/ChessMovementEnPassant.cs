using System;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Movement.Chess;

public class ChessMovementEnPassant: ChessMovementBase
{
    public ChessMovementEnPassant(ChessSquare source, ChessSquare target) : base(source, target)
    {
    }
}