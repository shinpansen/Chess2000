using System;
using System.Collections.Generic;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Rules.Chess;

public class ChessMovementRules : IMovementRules<ChessMovement, ChessSquare, ChessBoard>
{
    public List<ChessMovement> GetAvailableMoves(ChessSquare square, ChessBoard board)
    {
        var movements = new List<ChessMovement>();
        if(square.Piece is null) return movements;

        return movements;
    }
}