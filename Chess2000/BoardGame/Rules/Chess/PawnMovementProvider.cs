using System;
using System.Collections.Generic;
using Chess2000.BoardGame.Board.Chess;
using Chess2000.BoardGame.Movement.Chess;
using Chess2000.BoardGame.Pieces.Chess;
using Chess2000.BoardGame.Rules;
using Chess2000.BoardGame.Squares.Chess;

namespace Chess2000.BoardGame.Rules.Chess;

public class PawnMovementProvider : ChessMovementProvider
{
    public PawnMovementProvider(ChessSquare square, ChessBoard board) : base(square, board)
    {
    }

    public List<ChessMovement> GetAvailableMoves(BlackPawn pawn)
    {
        return GetAvailableMoves(-1);
    }

    public List<ChessMovement> GetAvailableMoves(WhitePawn pawn)
    {
        return GetAvailableMoves(1);
    }

    private List<ChessMovement> GetAvailableMoves(short direction)
    {
        var movements = new List<ChessMovement>();

        //Basic forward move
        if(Board.TryGetSquare(Col, Row + direction, out var t1) && t1.Piece is null)
            movements.Add(new ChessMovementBase(Square, t1));
        
        //Eating opponent on the left
        if(Board.TryGetSquare(Col-1, Row + direction, out var t2) && t2.Piece is not null && !IsFriend(t2)) 
            movements.Add(new ChessMovementBase(Square, t2));

        //Eating opponent on the right
        if(Board.TryGetSquare(Col-1, Row + direction, out var t3) && t3.Piece is not null && !IsFriend(t3)) 
            movements.Add(new ChessMovementBase(Square, t3));

        return movements;
    }
}