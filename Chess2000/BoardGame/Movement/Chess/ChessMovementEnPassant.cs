using System;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Movement.Chess;

public class ChessMovementEnPassant: ChessMovementBase
{
    public ChessMovementEnPassant(ChessPiece piece, ChessSquare target) : base(piece, target)
    {
    }
}