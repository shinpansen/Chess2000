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
    private ChessSquare _square { get; set; }
    private ChessBoard _board { get; set; }

    public ChessMovementRules(ChessSquare square, ChessBoard board)
    {
        _square = square;
        _board = board;
    }

    public List<ChessMovement> GetAvailableMoves()
    {
        if(_square.Piece is null) new List<ChessMovement>();
        
        return _square.Piece.GetAvailableMovements(this);
    }

    public List<ChessMovement> GetAvailableMoves(BlackPawn pawn)
    {
        var movementProvider = new PawnMovementProvider(_square, _board);
        return movementProvider.GetAvailableMoves(pawn);
    }

    public List<ChessMovement> GetAvailableMoves(WhitePawn pawn)
    {
        var movementProvider = new PawnMovementProvider(_square, _board);
        return movementProvider.GetAvailableMoves(pawn);
    }
}