using System;
using Chess2000.BoardGame.Pieces;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Squares;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Movements.Chess;

public class ChessMovementEnPassant : ChessMovementBase
{
    public ChessMovementEnPassant(IPiece piece, ISquare target) : base(piece, target)
    {
    }
}